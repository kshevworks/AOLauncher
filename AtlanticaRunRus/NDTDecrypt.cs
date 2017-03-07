using System;
using System.IO;
using System.Runtime.InteropServices;

namespace AtlanticaRunRus
{
    class NDTDecrypt
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct NdtFileHeader
        {
            public UInt32 MagicBytes;
            public UInt32 Version;
            public UInt32 FileSize;
            public byte Key;
            public byte Undefined1;
            public byte Undefined2;
            public byte Undefined3;
            public UInt32 Undefined4;
            public UInt32 Undefined5;
        }

        public byte[] Start(string path)
        {
                byte[] input = File.ReadAllBytes(path);
                return Decrypt(input);
        }

        byte[] Decrypt(byte[] input)
        {
            int inputLength = input.Length;
            int outputLength = inputLength - 24;
            byte[] output = new byte[outputLength];

            // extract header
            byte[] headerArray = new byte[24];
            Array.Copy(input, headerArray, 24);
            NdtFileHeader header;
            FromArray(headerArray, out header);

            if (header.Version == 0x00010001)
            {
                // decode the data using the Key from the header
                for (int i = 0; i < outputLength; i++)
                {
                    byte c = input[i + 24];
                    c -= header.Key;
                    if (i + 1 != outputLength)
                    {
                        byte next = input[i + 1 + 24];
                        c ^= next;
                    }
                    output[i] = c;
                }
            }
            else if (header.Version == 0x00030001)
            {
                int[] shufflingMap = new int[] { 1, 3, 2, 3, 1, 5, 4, 2, 1, 4, 2, 8, 4, 2, 6, 8, 2, 6, 4 };
                int shufflingMapLength = shufflingMap.Length;
                int numberOfDwords = outputLength / 4;
                Array.Copy(input, 24, output, 0, outputLength);

                for (int i = numberOfDwords - 1; i >= 0; i--)
                {
                    // calculate which Dword to swap with
                    int shuffleBy = shufflingMap[i % shufflingMapLength];
                    int j = (i + shuffleBy) % numberOfDwords;

                    UInt32 iDword = GetUInt32(output, i * 4, 4);
                    UInt32 jDword = GetUInt32(output, j * 4, 4);
                    SetUInt32(jDword, output, i * 4, 4);
                    SetUInt32(iDword, output, j * 4, 4);
                }

                UInt32 adjustedKey = header.Key - (UInt32)0x57D3CEFF;
                UInt32 sum = 0;
                UInt32 carryOver = 0;
                for (int i = 0; i < numberOfDwords; i++)
                {
                    UInt32 iDword = GetUInt32(output, i * 4, 4);
                    UInt32 decodedValue = adjustedKey + iDword + sum + carryOver;
                    SetUInt32(decodedValue, output, i * 4, 4);
                    sum += header.Key;
                    carryOver = iDword;
                }
            }

            return output;
        }

        UInt32 GetUInt32(byte[] array, int index, int length)
        {
            UInt32 result = 0;
            for (int i = length; i > 0; i--)
            {
                result = result << 8;
                result += array[index + i - 1];
            }
            return result;
        }

        void SetUInt32(UInt32 value, byte[] array, int index, int length)
        {
            for (int i = 0; i < length; i++)
            {
                array[index + i] = (byte)(value % 256);
                value = value / 256;
            }
        }

        byte[] Encrypt(byte[] input, byte key)
        {
            int inputLength = input.Length;
            int outputLength = inputLength + 24;
            byte[] output = new byte[outputLength];

            // output header header
            NdtFileHeader header = new NdtFileHeader();
            header.MagicBytes = 0x0052434e; // NCR
            header.Version = 0x00010001;    // v. 1.0.1
            header.FileSize = (uint)outputLength;
            header.Key = key;
            byte[] headerArray = new byte[24];
            ToArray(header, headerArray);
            Array.Copy(headerArray, output, 24);

            // encode the data using the Key
            for (int i = inputLength - 1; i >= 0; i--)
            {
                byte c = input[i];
                if (i != inputLength - 1)
                {
                    byte next = output[i + 1 + 24];
                    c ^= next;
                }
                c += header.Key;
                output[i + 24] = c;
            }

            return output;
        }

        private void FromArray<T>(byte[] input, out T output)
        {
            // Pin the managed memory while, copy it out the data, then unpin it
            GCHandle handle = GCHandle.Alloc(input, GCHandleType.Pinned);
            output = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
        }

        private void ToArray<T>(T input, byte[] output)
        {
            // Pin the managed memory while, copy it out the data, then unpin it
            GCHandle handle = GCHandle.Alloc(output, GCHandleType.Pinned);
            Marshal.StructureToPtr(input, handle.AddrOfPinnedObject(), false);
            handle.Free();
        }
    }
}

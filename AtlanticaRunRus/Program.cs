using System;
using System.Threading;
using System.Windows.Forms;

namespace AtlanticaRunRus
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, @"Global\" + "3660cb88-083f-4452-af74-4c5f641946f7"))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Программа уже запущена!");
                    return;
                }

                //Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
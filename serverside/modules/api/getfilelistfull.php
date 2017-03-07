<?php


if (!file_exists($dir."/filelist.json")){
    $list = array();


    $f = scandir($dir);


    foreach ($f as $file) {
        if (preg_match('/\d+/', $file)) {
            $list[$file] = md5_file($dir . "/" . $file);
        }

    }
    file_put_contents($dir."/filelist.json", json_encode($list));
}

echo file_get_contents($dir."/filelist.json");

?>
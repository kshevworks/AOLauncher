<?php

if (!file_exists($patchdir."/filelist.json")){
    $list = array();


    $f = scandir($patchdir);


    foreach ($f as $file) {
        if (preg_match('/\d+/', $file)) {
            $list[$file] = md5_file($patchdir . "/" . $file);
        }

    }
    file_put_contents($patchdir."/filelist.json", json_encode($list));
}

echo file_get_contents($patchdir."/filelist.json");

?>
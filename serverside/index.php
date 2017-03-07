<?php
$ver = file_get_contents("modules/api/version");
$loc_ver = file_get_contents("modules/api/loc");
$dir = "files/full/".$ver;
$patchdir = "files/".$ver;

$query_string = str_replace("q=","",trim($_SERVER['QUERY_STRING']));;
$query_string = urldecode($query_string);
$query = explode("/",$query_string);


switch ($query_string){
    case "":
        echo "В разработке";
        break;
    case "api/getversion":
        require_once ("modules/api/getversion.php");
        break;
    case "api/getfilelistfull":
        require_once("modules/api/getfilelistfull.php");
        break;
    case "api/getfilelist":
        require_once("modules/api/getfilelist.php");
        break;
    case "launcher/rightwindow":
        require_once("modules/launcher/rwind.php");
        break;
    case "launcher/centerwindow":
        require_once("modules/launcher/cwind.php");
        break;
    case "api/getfile/".$query[2]:
        require_once ("modules/api/getfile.php");
        break;
    case "api/getfilefull/".$query[2]:
        require_once ("modules/api/getfilefull.php");
        break;





    default: require_once ("404.php");
}

?>
<?php


$launcher_items = json_decode(file_get_contents('http://at.valofe.com/api/game/launcheritems',true));




function makeBlock($arr,$i){
    echo '<div class="news news'.$i.'"><a href="'.$arr->href_url.'" target="_self"><img src="'.$arr->img_url.'"/></a></div>';

}

?>
<html>
<head>
    <meta charset="UTF-8">
    <title>RightWindow</title>
    <style>
        body{
            background: url(http://127.0.0.1/aousrus/modules/launcher/img/rwind.png) no-repeat;
            background-color: white;
        }
        img{
            border-style:solid;
            border-color: #303030;
            border-width: 2px;
        }

    </style>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script>
        var newsIndex = 0;
        function NewsRotator() {

            $(".news").hide();
            $(".news" + newsIndex).fadeIn('slow');

            var newsCount = 3;
            newsIndex++;
            if(newsIndex > newsCount) {
                newsIndex = 0;
            }
        }

        $(document).ready(function() {
            NewsRotator();
            setInterval(NewsRotator, 7500);
        });
    </script>
</head>
<body>
<div style="margin-top:30px; margin-left: 5px">
    <?php makeBlock($launcher_items[0],0);?>
    <?php makeBlock($launcher_items[1],1);?>
    <?php makeBlock($launcher_items[2],2);?>
    <?php makeBlock($launcher_items[3],3);?>
</div>
</body>
</html>

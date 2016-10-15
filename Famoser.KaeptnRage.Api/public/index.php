<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <base href="https://kaeptnrage.famoser.ch"/>
    <meta name="description" content="a crossplatform rage © solution">
    <meta name="copyright" content="famoser.ch">
    <meta name="author" content="famoser.ch">
    <meta name="robots" content="noindex,nofollow">


    <title>Kaeptn Rage</title>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="css/styles.css"/>
</head>
<body>
<header>
    <div class="container">
        <div class="row">
            <div class="col-md-12 header">
                <h1 id="title">KaeptnRage</h1>
                <aside>a crossplatform rage © solution</aside>
                <hr/>
            </div>
        </div>
    </div>
</header>
<section>
    <div class="container">
        <div class="row content">
            <?php

            function custom_decode($text)
            {
                $replace = array("ae" => "ä", "oe" => "ö", "ue" => "ü");
                foreach ($replace as $key => $val) {
                    $text = str_replace($key, $val, $text);
                }
                return $text;
            }

            $files = glob(__DIR__ . '/sounds/*.*');
            $first = true;
            foreach ($files as $file) {
                $filename = basename($file);
                $midPos = strrpos($filename, " - ");
                if ($midPos == -1)
                    continue; //skip invalid filenames
                $author = substr($filename, 0, $midPos);
                $blockquote = substr($filename, $midPos + 3);
                $blockquote = substr($blockquote, 0, strrpos($blockquote, ".")); ?>

                <div class="sound col-md-4">
                    <div class="sound-inner">
                        <audio src="sounds/<?= $filename ?>" controls></audio>
                        <blockquote>
                            <p>
                                <?= custom_decode($blockquote) ?></p>
                            <small>by <cite><?= custom_decode($author) ?></cite></small>
                        </blockquote>
                    </div>
                </div>
            <?php } ?>

        </div>
    </div>
</section>
<!--
<script type="application/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
<script type="application/javascript" src="js/fittext.js"></script>

<script>$("#title").fitText();</script>
-->
</body>
</html>
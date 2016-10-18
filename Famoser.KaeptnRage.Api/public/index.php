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
$content = array();
$authors = array();
foreach ($files as $file) {
    $localContent = array();
    $filename = basename($file);
    $midPos = strrpos($filename, " - ");
    if ($midPos == -1)
        continue; //skip invalid filenames
    $author = substr($filename, 0, $midPos);
    $blockquote = substr($filename, $midPos + 3);
    $blockquote = substr($blockquote, 0, strrpos($blockquote, "."));

    $localContent["author"] = $author;
    $localContent["blockquote"] = $blockquote;
    $localContent["filename"] = $filename;
    $content[] = $localContent;

    if (!in_array($author, $authors))
        $authors[] = $author;
}
?>

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
                <aside>a crossplatform rage © solution | download for <a href="https://github.com/famoser/KaeptnRage/blob/master/Builds/Android/Current/KaeptnRage.apk?raw=true">Android</a></aside>
                <hr/>
            </div>
        </div>
    </div>
</header>
<section>
    <div class="container">
        <div class="row">
            <div class="col-md-12 select-buttons">
                <button class="button select-button selected" data-filter="*">alli</button>
                <?php foreach ($authors as $author) { ?>
                    <button class="button select-button" data-filter=".<?= $author ?>"><?= $author ?></button>
                <?php } ?>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row content sound-items">
            <?php foreach ($content as $item) { ?>
                <div class="sound col-md-4 <?= custom_decode($item["author"]) ?>">
                    <div class="sound-inner">
                        <audio src="sounds/<?= $item["filename"] ?>" controls></audio>
                        <blockquote>
                            <p>
                                <?= custom_decode($item["blockquote"]) ?></p>
                            <small>by <cite><?= custom_decode($item["author"]) ?></cite></small>
                        </blockquote>
                    </div>
                </div>
            <?php } ?>
        </div>
    </div>
</section>
<script type="application/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
<script src="https://unpkg.com/isotope-layout@3.0/dist/isotope.pkgd.min.js"></script>
<script type="application/javascript">
    $isoGrid = $('.sound-items');
    $isoGrid.isotope({
        // set itemSelector so .grid-sizer is not used in layout
        itemSelector: '.sound',
        percentPosition: true,
        layoutMode: 'masonry'
        /*masonry: {
         // use element for option
         columnWidth: '.grid-sizer'
         }*/
    });

    $(".select-button").on("click", function (e) {
        e.preventDefault();
        $(".select-button").removeClass("selected");
        $(this).addClass("selected");
        $isoGrid.isotope({filter: $(this).attr("data-filter")});
    })
</script>
<!--
<script type="application/javascript" src="js/fittext.js"></script>

<script>$("#title").fitText();</script>
-->
</body>
</html>
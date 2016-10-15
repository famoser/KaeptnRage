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
    <h1>KaeptnRage</h1>
    <aside>a crossplatform rage © solution</aside>
</header>
<section>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <?php
                $files = glob(__DIR__ . '/sounds/*.*');
                $first = true;
                foreach ($files as $file) {
                    $filename = basename($file);
                    $midPos = strrpos($filename, " - ");
                    if ($midPos == -1)
                        continue; //skip invalid filenames
                    $author = substr($filename, 0, $midPos);
                    $blockquote = substr($filename, $midPos + 3); ?>
                    <?php if (!$first) echo "<hr>"; else $first = false; ?>

                    <div class="sound">
                        <audio src="sounds/<?= $filename ?>" controls></audio>
                        <blockquote>
                            <p><?= $blockquote ?></p>
                            <small>by <cite><?= $author ?></cite></small>
                        </blockquote>
                    </div>
                <?php } ?>

            </div>
        </div>
    </div>
</section>

<script>(function (i, s, o, g, r, a, m) {
        i['GoogleAnalyticsObject'] = r;
        i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date();
        a = s.createElement(o), m = s.getElementsByTagName(o)[0];
        a.async = 1;
        a.src = g;
        m.parentNode.insertBefore(a, m)
    })(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');
    ga('create', 'UA-46163202-2', 'auto');
    ga('send', 'pageview');</script>
</body>
</html>
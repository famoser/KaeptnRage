<?php

include __DIR__ ."/Classes/FileEntity.php";
include __DIR__ ."/Classes/FilesResponse.php";

$files = glob(__DIR__ . '/public/sounds/*.*');
$res = new FilesResponse();
foreach ($files as $file)
{
    $entity = new FileEntity();
    $entity->FileName = basename($file);
    $entity->ChangeDate = date("c", filectime($file));
    $res->Files[] = $entity;
}

echo json_encode($res);

?>
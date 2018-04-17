<?php
header('Content-Type: application/json');

if (!array_key_exists("number", $_POST) || !array_key_exists("date", $_POST) || !array_key_exists("code", $_POST)) die();
$csvLine = $_POST["number"] . " " . $_POST["date"] . " " . $_POST["code"];
file_put_contents('data.txt', $csvLine.PHP_EOL , FILE_APPEND | LOCK_EX);

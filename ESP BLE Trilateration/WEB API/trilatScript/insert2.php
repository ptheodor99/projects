<?php
	$host = "localhost";
	$user = "root";
	$pw = "";
	$db = "trilat";
	
	$conn = mysqli_connect($host, $user, $pw, $db);
	
	$value = $_GET["val"];
	
	$value = (float)$value;
	$query = "INSERT INTO esp2 (value, timestamp) VALUES ($value, NOW())";
	
	mysqli_query($conn, $query);
	
	echo "OK";
?>
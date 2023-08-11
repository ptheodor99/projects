<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$id = $_GET['id'];
	
	$ids = $_GET['ids'];
	
	$ids = explode(',', $ids);
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	for($i = 0; $i <= sizeof($ids); $i++){
		$query = "INSERT INTO materiestudenti (codStudent, codMaterie) VALUES ($ids[$i], $id)";
		mysqli_query($connection, $query);
	}
	
?>
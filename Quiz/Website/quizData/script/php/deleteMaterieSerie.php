<?php

	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$id = $_GET['id'];
	$serie = $_GET['serie'];
	$materie = $_GET['materie'];
	
	$conn = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	$query = "DELETE FROM asocmaterii WHERE idProfesor = $id AND idMaterie = $materie AND idSerie = $serie";
	
	mysqli_query($conn, $query);
?>
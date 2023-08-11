<?php

	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$prof = $_GET['prof'];
	$serie = $_GET['serie'];
	$materie = $_GET['materie'];
	
	$conn = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	$query = "INSERT INTO asocmaterii (idProfesor, idMaterie, idSerie) VALUES ($prof, $materie, $serie)";

	mysqli_query($conn, $query);
	
?>
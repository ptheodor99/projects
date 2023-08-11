<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$id = $_GET['id'];
	
	$conn = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	$query = "DELETE FROM profesori WHERE idProfesor = $id";
	
	mysqli_query($conn, $query);
	
?>
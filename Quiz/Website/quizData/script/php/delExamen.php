<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$id = $_GET['id'];
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	$query = "DELETE FROM examen WHERE idExamen = " . $id;
	
	mysqli_query($connection, $query);

?>
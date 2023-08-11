<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$numeStud = $_GET['numeStud'];
	$emailStud = $_GET['emailStud'];
	$grupaStud = $_GET['grupaStud'];
	$serieStud = $_GET['serieStud'];
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	$query = "INSERT INTO studenti (numeStudent, grupa, serie, email) VALUES (" . 
	"'" . $numeStud . "', '" . $grupaStud . "', '" . $serieStud . "', '" . $emailStud . "')";
	mysqli_query($connection, $query);
	
?>
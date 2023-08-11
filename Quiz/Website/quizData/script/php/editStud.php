<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$numeStud = $_GET['numeStud'];
	$emailStud = $_GET['emailStud'];
	$grupaStud = $_GET['grupaStud'];
	$serieStud = $_GET['serieStud'];
	$id = $_GET['id'];
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);

	
	if($numeStud != ""){
		$query = "UPDATE studenti SET numeStudent = '" . $numeStud . "' WHERE idStudent = " . $id;
		mysqli_query($connection, $query);
	}
	
	if($emailStud != ""){
		$query = "UPDATE studenti SET email = '" . $emailStud . "' WHERE idStudent = " . $id;
		mysqli_query($connection, $query);
	}
	
	if($grupaStud != ""){
		$query = "UPDATE studenti SET grupa = '" . $grupaStud . "' WHERE idStudent = " . $id;
		mysqli_query($connection, $query);
	}
	
	if($serieStud != ""){
		$query = "UPDATE studenti SET serie = '" . $serieStud . "' WHERE idStudent = " . $id;
		mysqli_query($connection, $query);
	}
	
?>
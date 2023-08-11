<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$sel = $_GET['sel'];
	$G1 = $_GET['G1'];
	$G2 = $_GET['G2'];
	$G3 = $_GET['G3'];
	$G4 = $_GET['G4'];
	$RU = $_GET['RU'];
	$enunt = $_GET['enunt'];
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	$query = "SELECT idMaterie FROM materie WHERE codProfesor = " . $_SESSION['id'];
	
	$result = mysqli_query($connection, $query);
	
	$row = mysqli_fetch_assoc($result);
	
	$id = $row['idMaterie'];
	
	if($sel == "RU"){
		$query = "INSERT INTO intrebari (codMaterie, textIntrebare, raspSA, raspCorect) VALUES ($id, '$enunt', '$RU', 5)";
		mysqli_query($connection, $query);
	}
	else{
		$rc = $sel[1];
		$query = "INSERT INTO intrebari(codMaterie, textIntrebare, raspG1, raspG2, raspG3, raspG4, raspCorect) VALUES ($id, 
		'$enunt', '$G1', '$G2', '$G3', '$G4', $rc)";
		mysqli_query($connection, $query);
	}
?>
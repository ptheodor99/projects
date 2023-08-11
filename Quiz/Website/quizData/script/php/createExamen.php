<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$ids = $_GET['ids'];
	$ids = explode(',', $ids);
	
	$numeExamen = $_GET['numeExamen'];
	$examStart = $_GET['examStart'];
	$examEnd = $_GET['examEnd'];
	$codMaterie = $_GET['codMaterie'];
	$punctaj = $_GET['punctaj'];
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	$query = "INSERT INTO examen (TS_Start, TS_Stop, denumireExamen, punctaj, codMaterie) VALUES ('" . $examStart . "', '" . $examEnd . 
	"', '" . $numeExamen . "', $punctaj, " . $codMaterie . ")";
	
	mysqli_query($connection, $query);
	
	$query = "SELECT MAX(idExamen) AS max FROM examen";
	
	$result = mysqli_query($connection, $query);
	
	$row = mysqli_fetch_assoc($result);
	
	$id = $row['max'];
	
	for($i = 0; $i < sizeof($ids); $i++){
		$query = "INSERT INTO examenintrebari (codExamen, codIntrebare) VALUES (" . $id . ", " . $ids[$i] . ")";
		mysqli_query($connection, $query);
	}
?>
<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	$conn = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	$numeProf = $_GET['numeProf'];
	$emailProf = $_GET['emailProf'];
	$parolaProf = $_GET['parolaProf'];
	$materieProf = $_GET['materieProf'];
	$serieProf = $_GET['serieProf'];
	$id = -1;
	
	$query =  "INSERT INTO profesori (numeProfesor, email, parola) VALUES ('$numeProf', '$emailProf' , '$parolaProf')";
	mysqli_query($conn, $query);
	
	$query = "SELECT idProfesor FROM profesori ORDER BY idProfesor DESC LIMIT 1";
	
	$res = mysqli_query($conn, $query);
	
	$row = mysqli_fetch_assoc($res);
	$id = $row["idProfesor"];
	
	$query = "INSERT INTO asocmaterii (idProfesor, idMaterie, idSerie) VALUES ($id, $materieProf, $serieProf)";
	mysqli_query($conn, $query);
	
	
?>
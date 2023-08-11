<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$id = $_GET['id'];
	$nume = $_GET['nume'];
	$email = $_GET['email'];
	$pass = $_GET['pass'];
	
	$serieVeche = $_GET['serieVeche'];
	$materieVeche = $_GET['materieVeche'];
	$serieNoua = $_GET['serieNoua'];
	$materieNoua = $_GET['materieNoua'];
	
	$conn = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	if($nume != ""){
		$query = "UPDATE profesori SET numeProfesor = '$nume' WHERE idProfesor = $id";
		mysqli_query($conn, $query);
	}
	
	if($email != ""){
		$query = "UPDATE profesori SET email = '$email' WHERE idProfesor = $id";
		mysqli_query($conn, $query);
	}
	
	if($parola != ""){
		$query = "UPDATE profesori SET parola = '$parola' WHERE idProfesor = $id";
		mysqli_query($conn, $query);
	}
	
	if($serieVeche != -2){
		$query = "UPDATE asocmaterii SET idMaterie = $materieNoua, idSerie = $serieNoua WHERE idProfesor = $id AND 
					idMaterie = $materieVeche AND idSerie = $serieVeche";
		mysqli_query($conn, $query);
	}
?>
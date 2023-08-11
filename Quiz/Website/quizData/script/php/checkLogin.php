<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$email = $_GET['email'];
	$pass = $_GET['pass'];
	
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);

	$query = "SELECT * FROM profesori WHERE email = '" . $email . "'" . " AND parola = " . "'" . $pass . "'";

	$result = mysqli_query($connection, $query);
	
	if(mysqli_num_rows($result) > 0){
		echo 'OK';
		$_SESSION['loggedIn'] = true;
		
		$row = mysqli_fetch_assoc($result);
		
		$_SESSION['id'] = $row['idProfesor'];
		$_SESSION['statut'] = $row['statut'];
	}
	else
		echo 'NOK';
?>
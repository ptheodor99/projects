<?php

	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	
	$conn = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	echo'
	<input type="text" id="addNumeProfesor" placeholder = "Nume..."><br>
	<input type="text" id="addEmailProfesor" placeholder = "Email..."><br>
	<input type="password" id="addParolaProfesor" placeholder = "Parola..."><br>
	<select id="selectSerie"><option value="-1">Serie</option>';
	
	$query = "SELECT * FROM serii";
	
	$res = mysqli_query($conn, $query);
	
	while($row = mysqli_fetch_assoc($res)){
		echo '<option value="' . $row['idSerie'] . '">' . $row['serie'] . '</option>';
	}
	echo'</select>';
	echo '<select id="selectMaterie"><option value="-1">Materie</option>';
	
	$query = "SELECT * FROM materii";
	
	$res = mysqli_query($conn, $query);
	
	while($row = mysqli_fetch_assoc($res)){
		echo '<option value="' . $row['idMaterie'] . '">' . $row['numeMaterie'] . '</option>';
	}
	
	echo'</select><br>';
	
	echo '<button onclick="addProf()">Adauga</button>';
?>
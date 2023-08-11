<?php

	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	
	$conn = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	echo '<input type="text" id="searchProf" placeholder="Cauta..." onkeyup="matchProf()"><br>';
	echo '<select id="selectProf"><option value="-1">Profesor</option>';
	
	$query = "SELECT idProfesor, numeProfesor FROM profesori WHERE numeProfesor != 'admin'";
	
	$res = mysqli_query($conn, $query);
	
	while($row = mysqli_fetch_assoc($res)){
		echo '<option value="' . $row['idProfesor'] . '">' . $row['numeProfesor'] . "</option>";
	}
	
	echo '</select>';

	$query = "SELECT * FROM serii";

	$res = mysqli_query($conn, $query);
	
	echo '<select id="selectSerie"><option value="-1">Serie</option>';
	
	while($row = mysqli_fetch_assoc($res)){
		echo '<option value="' . $row['idSerie'] . '">' . $row['serie'] . "</option>";
	}

	echo '</select><br>';
	
	$query = "SELECT * FROM materii";

	$res = mysqli_query($conn, $query);
	
	echo '<select id="selectMaterie"><option value="-1">Materie</option>';
	
	while($row = mysqli_fetch_assoc($res)){
		echo '<option value="' . $row['idMaterie'] . '">' . $row['numeMaterie'] . "</option>";
	}

	echo '</select><br>';
	
	echo '<button onclick="bindMaterie()">Adauga</button>';
	
?>
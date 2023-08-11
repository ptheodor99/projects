<?php

	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$id = $_GET['id'];
	
	$conn = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	$query = "SELECT DISTINCT serii.idSerie AS idSerie, serii.serie AS serie FROM serii 
				JOIN asocmaterii ON asocmaterii.idSerie = serii.idSerie 
				WHERE idProfesor = $id";

	$res = mysqli_query($conn, $query);

	echo '<select id="selectSerieExistenta"><option value="-1">Serie</option>';

	while($row = mysqli_fetch_assoc($res)){
		echo '<option value = "' . $row['idSerie'] . '">' . $row['serie'] . '</option>';
	}

	echo '</select>';
	
	$query = "SELECT DISTINCT materii.idMaterie AS idMaterie, materii.numeMaterie AS numeMaterie FROM materii 
				JOIN asocmaterii ON asocmaterii.idMaterie = materii.idMaterie 
				WHERE idProfesor = $id";

	$res = mysqli_query($conn, $query);

	echo '<select id="selectMaterieExistenta"><option value="-1">Serie</option>';

	while($row = mysqli_fetch_assoc($res)){
		echo '<option value = "' . $row['idMaterie'] . '">' . $row['numeMaterie'] . '</option>';
	}

	echo '</select>';
	
	echo '<button onclick="deleteMaterieSerie()">Sterege materie si serie</button>';
	
	echo '<br><br><span style="font-size: 1.5rem;">Se inlocuieste cu:</span><br>';

	$query = "SELECT * FROM serii";

	$res = mysqli_query($conn, $query);

	echo '<select id="selectSerieInlocuire"><option = value="-1">Serie</option>';

	while($row = mysqli_fetch_assoc($res)){
		echo '<option value="' . $row['idSerie'] . '">' . $row['serie'] . '</option>';
	}

	echo '</select>';

	$query = "SELECT * FROM materii";

	$res = mysqli_query($conn, $query);

	echo '<select id="selectMaterieInlocuire"><option = value="-1">Materie</option>';

	while($row = mysqli_fetch_assoc($res)){
		echo '<option value="' . $row['idMaterie'] . '">' . $row['numeMaterie'] . '</option>';
	}

	echo '</select>';
?>
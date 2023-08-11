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
	
	echo '</select><br>';

	echo '<input type = "text" id="nume" placeholder="Nume..."><br>
	<input type="text" id="email" placeholder="Email..."><br>
	<input type="password" id="pass" placeholder="Parola..."><br>';

	echo '<div id="materieProf"><button onclick="generateMaterieProf();">Modifica materie</button></div>';
	
	
	echo '<button onclick="editProf();">Modifica</button>';
	
?>
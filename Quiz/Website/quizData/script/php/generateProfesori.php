<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	

	$query = "SELECT * FROM profesori WHERE numeProfesor != 'admin'";

	$result = mysqli_query($connection, $query);
	
	if($_SESSION['loggedIn'] == false){
		echo 'X,Va rugam sa efectuati logarea';
		die();
	}
	
	if($_SESSION['statut'] != 'admin'){
		echo 'X,Nu aveti acces deoarece nu sunteti administrator';
		die();
	}
	
	
	echo '<table id="tabel-profi">';

	echo '<tr>
			<th>Nume</th>
			<th>Email</th>
			<th>Materii</th>

		</tr>';


	
	while($row = mysqli_fetch_assoc($result)){
		echo '<tr>';
		
		echo '<td>' . $row['numeProfesor'] . '</td>';
		echo '<td>' . $row['email'] . '</td>';
		
		$querySerii = "SELECT DISTINCT serii.serie AS serie, serii.idSerie AS idSerie FROM materii
		JOIN asocmaterii ON asocmaterii.idMaterie = materii.idMaterie 
		JOIN serii ON serii.idSerie = asocmaterii.idSerie
		WHERE asocmaterii.idProfesor = " . $row["idProfesor"];
		
		$resulitSerii = mysqli_query($connection, $querySerii);
		
		echo '<td><ul>';
		while($rowSerii = mysqli_fetch_assoc($resulitSerii)){
			echo '<li>' . $rowSerii["serie"] . "<br>";
			
			$queryMaterii = "SELECT materii.numeMaterie as numeMaterie FROM materii 
			JOIN asocmaterii ON asocmaterii.idMaterie = materii.idMaterie 
			JOIN serii ON serii.idSerie = asocmaterii.idSerie
			WHERE asocmaterii.idProfesor = " . $row["idProfesor"] . " AND 
			asocmaterii.idSerie = " . $rowSerii["idSerie"];
			
			
			$resultMaterii = mysqli_query($connection, $queryMaterii);
			
			echo '<ul>';
			
				while($rowMaterii = mysqli_fetch_assoc($resultMaterii)){
					echo '<li>' . $rowMaterii["numeMaterie"] . '</li>';
				}
			
			echo '</ul>';
			
			echo '</li>';
		}
		echo '</ul></td>';
		
		
		echo '</tr>';
	}
	
	
	
	
	

	echo '</table>';
	
	echo '<div id="generateAddProfForm">';
	echo '<button onclick="generateAddProfForm()">Adauga Profesor</button>';
	echo '<button onclick="generateDelProfForm()">Sterge Profesor</button>';
	echo '<button onclick="generateModificaProfForm()">Modifica Profesor</button>';
	echo '<button onclick="generateAddMaterieProfForm()">Adauga Materie la Profesor</button>';
	echo '</div>';
?>
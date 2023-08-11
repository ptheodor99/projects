<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$ord = $_GET['ord'];
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);

	$query = "SELECT * FROM studenti";
	
	if($ord != "")
		$query = $query . " " . $ord;

	$result = mysqli_query($connection, $query);
	
	if($_SESSION['loggedIn'] == false){
		echo 'X,Va rugam sa efectuati logarea';
		die();
	}
	
	echo '<div id="sortare">
	
	<select id="sortStudenti">
	
	<option value="">Implicit</option>
	<option value="ORDER BY grupa ASC">grupa crescator</option>
	<option value="ORDER BY grupa DESC">grupa descrescator</option>
	<option value="ORDER BY serie ASC">serie crescator</option>
	<option value="ORDER BY serie DESC">serie descrescator</option>
	</select>
	<button onclick="generateStudenti();">Sorteaza</button>
	</div>';
	
	
	echo '<table id="tabel-profi" style="margin-top: 1rem;">';

	echo '<tr>
			<th>Nume</th>
			<th>Grupa</th>
			<th>Serie</th>
			<th>Email</th>
			<th>Modifica</th>
			<th>Sterge</th>
		</tr>';


	
	while($row = mysqli_fetch_assoc($result)){
		echo '<tr>';
		
		echo '<td>' . $row['numeStudent'] . '</td>';
		echo '<td>' . $row['grupa'] . '</td>';
		echo '<td>' . $row['serie'] . '</td>';
		echo '<td>' . $row['email'] . '</td>';
		echo '<td><button id="edit,' . $row['idStudent'] . '"' . ' onclick="editStud(this.id);">Modifica</button></td>';
		echo '<td><input type="checkbox" id="delete' . $row['idStudent'] . '"></td>';
		echo '</tr>';
	}
	
	echo '<tr>
			<td><input type="text" id="numeStud" placeholder="Nume..."></td>
			<td><input type="text" id="grupaStud" placeholder="Grupa..."></td>
			<td><input type="text" id="serieStud" placeholder="Serie..."></td>
			<td><input type="text" id="emailStud" placeholder="Email..."></td>
			<td><button id="add" onclick="addStud();">Adauga</button></td>
			<td><button id="del" onclick="delStud();">Sterge</button></td>
		</tr>';
	
	
	

	echo '</table>';
	
	$query = 'SELECT MIN(idStudent) AS min, MAX(idStudent) AS max FROM studenti';
	
	$result = mysqli_query($connection, $query);
	
	$row = mysqli_fetch_assoc($result);
	
	$min = $row['min'];
	$max = $row['max'];
	
	
	echo'<input id="minMax" type="hidden" value="' . $min . ',' . $max . '">';
?>
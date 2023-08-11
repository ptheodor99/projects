<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	
	
	echo '<div class="page-inscrieri">';
		echo'<div class="page-inscrieri-left">';
			
			echo '<input type="text" id="searchStudent" onkeyup="searchStudent();" placeholder = "Nume..." style="width: 50%;">';
			
			$query = "SELECT * FROM studenti";
			
			$result = mysqli_query($connection, $query);
			
			while($row = mysqli_fetch_assoc($result)){
				echo '<div class="student" id="' . $row['numeStudent'] . '">';
				echo'<div class="enroll"><input type="checkbox" id="' . $row['idStudent'] . '"></div>';
				echo'<div><span>' . $row['numeStudent'] . '&nbsp;</span><span>' . $row['grupa'] . '<span></span>' . $row['serie'] . '</span></div>';
				echo'<div><span>Inscris la :</span><ul>';
				
					$q = "SELECT materie.numeMaterie AS numeMaterie FROM materie
						JOIN materiestudenti ON materie.idMaterie = materiestudenti.codMaterie
						JOIN studenti ON studenti.idStudent = materiestudenti.codStudent
						WHERE studenti.idStudent = " . $row['idStudent'];
						
					$r = mysqli_query($connection, $q);
					
					while($rw = mysqli_fetch_assoc($r)){
						echo '<li>' . $rw['numeMaterie'] . '</li>';
					}
				
				echo'</ul></div>';				
				echo'</div>';
				
			}
		
		echo '</div>';
		echo'<div class="page-inscrieri-right">';
			$query = "SELECT * FROM materie";
			
			$result = mysqli_query($connection, $query);
			
			while($row = mysqli_fetch_assoc($result)){
				echo'<div class="materie"><div>';
					
					echo '<span>' . $row['numeMaterie'] . '</span></div>';
					echo '<div><button id="mat,' . $row['idMaterie'] . '" onclick="enrolStud(this.id);">Inscrie</button>';
				
				echo'</div></div>';
			}
		
		
		echo'</div>';
		
		$query = "SELECT MIN(idStudent) AS min, MAX(idStudent) AS max FROM studenti";
		
		$result = mysqli_query($connection, $query);
		
		$row = mysqli_fetch_assoc($result);
		
		echo '<input type="hidden" id="minMax" value="' . $row['min'] . ',' . $row['max'] . '">';
	echo'</div>';
	
?>
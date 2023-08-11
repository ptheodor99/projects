<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	$query = "SELECT examenstudent.TS_Start AS rezStart, examenstudent.TS_Stop AS rezStop, examenstudent.punctaj AS punctaj, 
	studenti.numeStudent AS numeStudent, studenti.grupa AS grupa, studenti.serie AS serie, examen.TS_Start AS examStart, 
	examen.TS_Stop AS examStop, examen.denumireExamen AS numeExam, materie.numeMaterie AS numeMaterie 
	FROM examenstudent
	JOIN studenti ON examenstudent.codStudent = studenti.idStudent
	JOIN examen ON examenstudent.codExamen = examen.idExamen
	JOIN materie ON examen.codMaterie = materie.idMaterie";
	
	if($_SESSION['statut'] != 'admin'){
		$q = "SELECT idMaterie FROM materie WHERE codProfesor = " . $_SESSION['id'];
		$r = mysqli_query($connection, $q);
		$rw = mysqli_fetch_assoc($r);
		$id = $rw['idMaterie'];
		
		$query = $query . " WHERE materie.idMaterie = $id";
	}
	
	$result = mysqli_query($connection, $query);
	
	
	echo '<div class="page-rezultate">';
	
		$queryG1 = "SELECT examen.idExamen AS idExamen, examen.denumireExamen AS denumireExamen FROM examen";
		
		if($_SESSION['statut'] != 'admin'){
			$queryG1 = $queryG1 . " JOIN materie ON examen.codMaterie = materie.idMaterie
			WHERE codProfesor = " . $_SESSION['id'];
		}
	
		$resultG1 = mysqli_query($connection, $queryG1);
		
		$examsG1 = "";
		$averagesG1 = "";
		
		while($rowG1 = mysqli_fetch_assoc($resultG1)){
			$examsG1 = $examsG1 . $rowG1['denumireExamen'] . ",";
			
			$q = "SELECT AVG(punctaj) AS avg FROM examenstudent WHERE codExamen = " . $rowG1['idExamen'];
			
			$r = mysqli_query($connection, $q);
			
			$rw = mysqli_fetch_assoc($r);
			
			$averagesG1 = $averagesG1 . $rw['avg'] . ",";
		}
	
		$examsG1 = substr($examsG1, 0, -1);
		$averagesG1 = substr($averagesG1, 0, -1);
	
		echo'<input id="examsG1" type="hidden" value="' . $examsG1 . '">
		<input id="averagesG1" type="hidden" value="' . $averagesG1 . '">';
		
		
		echo'<div class="G1"><canvas id="G1"></canvas></div>';
		
	
	
	
	
		echo'<ol>';
			while($row = mysqli_fetch_assoc($result)){
				echo"<li>";
				echo"Studentul <b>" . $row['numeStudent'] . "</b> de la seria <b>" . $row['serie'] . "</b>, grupa <b>" . $row['grupa'] . 
				"</b> ce a sustinut "; 
				echo"de la <b>" . $row['rezStart'] . "</b> pana la <b>" . $row['rezStop'] . "</b> examenul <b>" . $row['numeExam'] . 
				"</b> desfasurat intre <b>";
				echo $row['examStart'] . "</b> si <b>" . $row['examStop'] . "</b> la materia <b>" . $row['numeMaterie'] . 
				"</b> si a obtinut punctul de <b>";
				echo $row['punctaj'] . "</b> puncte;";
				echo"</li><br>";
			}
		echo'</ol>';
	echo'</div>';
?>
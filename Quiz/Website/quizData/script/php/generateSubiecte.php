<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	$query = "SELECT idMaterie FROM materie WHERE codProfesor = " . $_SESSION['id'];
	
	$result = mysqli_query($connection, $query);
	
	$row = mysqli_fetch_assoc($result);
	
	$idMaterie = $row['idMaterie'];
	
	$query = "SELECT * FROM examen WHERE codMaterie = " . $idMaterie;
	
	$examene = mysqli_query($connection, $query);
	
	echo '<div id="pagina-subiecte">';
	echo '<ul>';
		while($examen = mysqli_fetch_assoc($examene)){
			echo '<li>';
				echo '<span>Examenul <b>' . $examen['denumireExamen'] . '</b> va avea loc de la <b>' . $examen['TS_Start'] . '</b> pana la <b>' .
				$examen['TS_Stop'] . '</b>&emsp;<button id="' . $examen['idExamen'] . '" onclick="delExamen(this.id);">Sterge</button></span><br>';
				
				$query = "SELECT * FROM examenintrebari JOIN intrebari ON examenintrebari.codIntrebare = intrebari.idIntrebare WHERE 
				examenintrebari.codExamen = " . $examen['idExamen'];
				
				$intrebari = mysqli_query($connection, $query);
				
				echo '<ol>';
				while($intrebare = mysqli_fetch_assoc($intrebari)){
					echo '<li>' . $intrebare['textIntrebare'] . '</li>';
				}
				
				
				echo '</ol>';
				
			echo '</li><br>';
		}
	echo '</ul>';
	echo '</div>';
?>
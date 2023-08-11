<?<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$sel = $_GET['sel'];
	$G1 = $_GET['G1'];
	$G2 = $_GET['G2'];
	$G3 = $_GET['G3'];
	$G4 = $_GET['G4'];
	$RU = $_GET['RU'];
	$enunt = $_GET['enunt'];
	$id = $_GET['id'];
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);

	
	if($enunt != ""){
		$query = "UPDATE intrebari SET textIntrebare = '$enunt' WHERE idIntrebare = $id";
		mysqli_query($connection, $query);
	}		
	
	if($G1 != ""){
		$query = "UPDATE intrebari SET raspG1 = '$G1' WHERE idIntrebare = $id";
		mysqli_query($connection, $query);
	}
	
	if($G2 != ""){
		$query = "UPDATE intrebari SET raspG2 = '$G2' WHERE idIntrebare = $id";
		mysqli_query($connection, $query);
	}
	
	if($G3 != ""){
		$query = "UPDATE intrebari SET raspG3 = '$G3' WHERE idIntrebare = $id";
		mysqli_query($connection, $query);
	}
	
	if($G4 != ""){
		$query = "UPDATE intrebari SET raspG4 = '$G4' WHERE idIntrebare = $id";
		mysqli_query($connection, $query);
	}
	
	if($RU != ""){
		$query = "UPDATE intrebari SET raspSA = '$RU' WHERE idIntrebare = $id";
		mysqli_query($connection, $query);
	}
	
	if($sel != ""){
		if($sel == "RU"){
			$query = "UPDATE intrebari SET raspCorect = 5 WHERE idIntrebare = $id";
			mysqli_query($connection, $query);
		}
		else{
			$rc = $sel[1];
			$query = "UPDATE intrebari SET raspCorect = $rc WHERE idIntrebare = $id";
			mysqli_query($connection, $query);
		}
	}
?>
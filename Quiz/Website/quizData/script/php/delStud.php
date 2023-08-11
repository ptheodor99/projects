<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$vals = $_GET['vals'];
	
	$values = explode(',', $vals);
	
	echo $vals;
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	
	
	for($i = 0; $i < sizeof($values); $i++){
		$query = "DELETE FROM studenti WHERE idStudent = " . $values[$i];
		mysqli_query($connection, $query);
	}
?>
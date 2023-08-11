<?php
	
	include "dbConn.php";
	
	$em = $_GET['em'];
	
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);

	$query = "SELECT * FROM profesori WHERE email = '" . $em . "'";

	$result = mysqli_query($connection, $query);
	
	if(mysqli_num_rows($result) <= 0)
		echo "Emailul nu este gasit.";
?>
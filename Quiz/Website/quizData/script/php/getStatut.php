<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	echo $_SESSION['statut'];
?>
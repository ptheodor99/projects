<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	$_SESSION['loggedIn'] = false;
	
	session_stop();
?>
<!DOCTYPE html>
<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	$_SESSION['loggedIn'] = false;
?>

<html>
	<head>
		<link rel="stylesheet" href="style.css" type="text/css">
		<script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
		<script src="../quizData/script/js/script.js"></script>
		<script src="https://cdnjs.cloudflare.com/ajax/libs/jsSHA/2.0.2/sha.js"></script>
	</head>

	<body>
		<header>
			<img src="img/quiz_web.svg">
			<button id="general" onclick="generateGeneral();">General</button>
			<button id="profesori" onclick="generateProfesori();">Profesori</button>
			<button id="studenti" onclick="generateStudenti();">Studenti</button>
			<button id="intrebari" onclick="generateIntrebari();" >Examene</button>
			<button id="subiecte" onclick="generateSubiecte();">Subiecte</button>
			<button id="variante" onclick="generateVariante();">Intrebari</button>
			<button id="examene" onclick="generateRezultate();">Rezultate</button>
			<button id="inscrieri" onclick="generateInscrieri();">Inscrieri</button>
			<button id="logout" onclick="logOut();">LogOut</button>

		</header>
		
		<main id="main">
			
			<div class="login-form">
				<label>Conectati-va la Quiz Web:</label><br>
				<input type="text" id="email" placeholder="Email..." onkeyup="verifyEmail(this.value);"><br>
				<span style="color: red;" id="err-email"></span>
				<input type="password" id="pass" placeholder="Parola..."><br>
				
				<button type="submit" onclick="logIn();">Login</button>
			</div>
			
			
		
		</main>
		
		
		<footer>
			<div>&copy; 10.05.2023 - Quiz Web - Licenta</div>
		</footer>
	
	</body>
</html>

<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);
	
	$query = "";
	
	
	$query = "SELECT * FROM materie WHERE codProfesor = " . $_SESSION['id'];

	
	$result = mysqli_query($connection, $query);
	
	$row = mysqli_fetch_assoc($result);
	
	$codMaterie = $row['idMaterie'];
	
	$query = "SELECT * FROM intrebari WHERE codMaterie = " . $codMaterie;
	
	$result = mysqli_query($connection, $query);
	
	echo'<div id="page-intrebari">';
		echo'<div id="sub-libere">';
			
			while($row = mysqli_fetch_assoc($result)){
				echo'<div class="subiect" id="lib,' . $row['idIntrebare'] . '">';
					echo'<div class="subiect-top">';
						echo $row['textIntrebare'];					
					echo'</div>';
					echo'<div class="subiect-bottom">';
						echo'<span>Raspuns: </span>';
						
						if($row['raspCorect'] == 5){
							echo'<span>' . $row['raspSA'] . '</span>';
						}
						else{
							if($row['raspCorect'] == 1){
								echo '<span style="color: green">' . $row['raspG1'] . '</span>';
								echo '<span style="color: red">' . $row['raspG2'] . '</span>';
								echo '<span style="color: red">' . $row['raspG3'] . '</span>';
								echo '<span style="color: red">' . $row['raspG4'] . '</span>';
							}
							else if($row['raspCorect'] == 2){
								echo '<span style="color: red">' . $row['raspG1'] . '</span>';
								echo '<span style="color: green">' . $row['raspG2'] . '</span>';
								echo '<span style="color: red">' . $row['raspG3'] . '</span>';
								echo '<span style="color: red">' . $row['raspG4'] . '</span>';
							}
							else if($row['raspCorect'] == 3){
								echo '<span style="color: red">' . $row['raspG1'] . '</span>';
								echo '<span style="color: red">' . $row['raspG2'] . '</span>';
								echo '<span style="color: green">' . $row['raspG3'] . '</span>';
								echo '<span style="color: red">' . $row['raspG4'] . '</span>';
							}
							else if($row['raspCorect'] == 4){
								echo '<span style="color: red">' . $row['raspG1'] . '</span>';
								echo '<span style="color: red">' . $row['raspG2'] . '</span>';
								echo '<span style="color: red">' . $row['raspG3'] . '</span>';
								echo '<span style="color: green">' . $row['raspG4'] . '</span>';
							}
						}
						
						echo '<button id="add,' . $row['idIntrebare'] . '" onclick="addSub(this.id);">Adauga</button>';
					echo'</div>';
				echo'</div>';
			}
			
		echo'</div>';
		
		echo'<div id="sub-exam">';
			
			echo'<div class="subiect-bottom"><input type="text" id="numeExamen" placeholder="Nume examen...">
				<button onclick="createExamen();">Creaza</button>
			</div>'; 
			
			echo '<div class="subiect-bottom">
				<div>
					<label>Inceput examen</label>
					<input type="datetime-local" id="examStart">
				</div>
				<div>
					<label>Sfarsit examen</label>
					<input type="datetime-local" id="examEnd">
				</div>
				<div>
					<label>Punctaj examen</labe>
					<input type="text" id="punctaj" placeholder="Punctaj...">
				</div>
			</div>';
			
			$result = mysqli_query($connection, $query);
			
			while($row = mysqli_fetch_assoc($result)){
				echo'<div class="subiect" id="exam,' . $row['idIntrebare'] . '" style="display:none;">';
					echo'<div class="subiect-top">';
						echo $row['textIntrebare'];					
					echo'</div>';
					echo'<div class="subiect-bottom">';
						echo'<span>Raspuns: </span>';
						
						if($row['raspCorect'] == 5){
							echo'<span>' . $row['raspSA'] . '</span>';
						}
						else{
							if($row['raspCorect'] == 1){
								echo '<span style="color: green">' . $row['raspG1'] . '</span>';
								echo '<span style="color: red">' . $row['raspG2'] . '</span>';
								echo '<span style="color: red">' . $row['raspG3'] . '</span>';
								echo '<span style="color: red">' . $row['raspG4'] . '</span>';
							}
							else if($row['raspCorect'] == 2){
								echo '<span style="color: red">' . $row['raspG1'] . '</span>';
								echo '<span style="color: green">' . $row['raspG2'] . '</span>';
								echo '<span style="color: red">' . $row['raspG3'] . '</span>';
								echo '<span style="color: red">' . $row['raspG4'] . '</span>';
							}
							else if($row['raspCorect'] == 3){
								echo '<span style="color: red">' . $row['raspG1'] . '</span>';
								echo '<span style="color: red">' . $row['raspG2'] . '</span>';
								echo '<span style="color: green">' . $row['raspG3'] . '</span>';
								echo '<span style="color: red">' . $row['raspG4'] . '</span>';
							}
							else if($row['raspCorect'] == 4){
								echo '<span style="color: red">' . $row['raspG1'] . '</span>';
								echo '<span style="color: red">' . $row['raspG2'] . '</span>';
								echo '<span style="color: red">' . $row['raspG3'] . '</span>';
								echo '<span style="color: green">' . $row['raspG4'] . '</span>';
							}
						}
						
						echo '<button id="rem,' . $row['idIntrebare'] . '" onclick="removeSub(this.id);">Scoate</button>';
					echo'</div>';
				echo'</div>';
			}
			
		echo'</div>';
	echo'</div>';
	
	$query = "SELECT MIN(idIntrebare) AS min, MAX(idIntrebare) AS max FROM intrebari";
	
	$result = mysqli_query($connection, $query);
	
	$row = mysqli_fetch_assoc($result);
	
	$min = $row['min'];
	$max = $row['max'];
	
	echo'<input type="hidden" value="' . $min . ',' . $max . '" id="minMax">';
	echo'<input type="hidden" value="' . $codMaterie . '" id="codMaterie">';
	
?>
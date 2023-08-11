<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	include "dbConn.php";
	
	$connection = mysqli_connect($dbServer, $dbUser, $dbPass, $dbName);

	$query = "SELECT * FROM intrebari";
	
	if($_SESSION['statut'] != "admin"){
		$q = "SELECT idMaterie FROM materie WHERE codProfesor = " . $_SESSION['id'];
		
		$r = mysqli_query($connection, $q);
		
		$rw = mysqli_fetch_assoc($r);
		
		$query = $query . " WHERE codMaterie = " . $rw['idMaterie'];
	}
	
	$result = mysqli_query($connection, $query);

	echo '<div class="page-variante">';
		echo '<div class="page-variante-left">';
			
			while($row = mysqli_fetch_assoc($result)){
				echo'<div class="subiect" id="' . $row['idIntrebare'] . '">';
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
						
						echo '<button id="edit,' . $row['idIntrebare'] . '" onclick="editVarianta(this.id);">Modifica</button>';
						echo '<button id="del,' . $row['idIntrebare'] . '" onclick="delVarianta(this.id);">Sterge</button>';
					echo'</div>';
				echo'</div>';
			}
			
		echo'</div>';
			
	
		
			echo'<div class="page-variante-right">';
				echo '<div>';
					echo'<textarea rows="5" cols="75" placeholder="Textul intrebarii..." id="enunt"></textarea>';
			
				echo '</div>';
				echo '<div class="page-variante-right-bottom">';
					echo'<input type="text" id="G1" placeholder="Raspuns grila 1...">
					<input type="text" id="G2" placeholder="Raspuns grila 2...">
					<input type="text" id="G3" placeholder="Raspuns grila 3...">
					<input type="text" id="G4" placeholder="Raspuns grila 4...">
					<input type="text" id="RU" placeholder="Raspuns unic...">
					<select id="correct">
						<option value="" disabled selected>Raspuns corect</option>
						<option value="G1">Grila 1</option>
						<option value="G2">Grila 2</option>
						<option value="G3">Grila 3</option>
						<option value="G4">Grila 4</option>
						<option value="RU">Raspuns unic</option>
					</select>
					<button onclick="addVarianta();">Adauga</button>';
				echo'</div>';
		echo '</div>';
	echo'</div>';
?>
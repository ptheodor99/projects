<?php
	$host = "localhost";
	$user = "root";
	$pw = "";
	$db = "trilat";
	$esp1;
	$esp2;
	$esp3;
	$eps = 2;
	
	function dbToUnit($v){
		$v = -$v;
		
		$v = $v - 55;
		$v = $v / 5;
		$v = $v * 4;
		
		return $v;
	}
	
	function eq($constant, $var){
		if($var >= $constant - 4 && $var <= $constant + 4)
			return true;
		else
			return false;
	}
	
	function getDist($x1, $y1, $x2, $y2){
		return sqrt(($x2 - $x1) ** 2 + ($y2 - $y1) ** 2);
	}
	
	$conn = mysqli_connect($host, $user, $pw, $db);
	
	$query = "SELECT * FROM locations";
	
	$res = mysqli_query($conn, $query);
	
	$row = mysqli_fetch_assoc($res);
	
	$esp1X = $row["esp1X"];
	$esp1Y = $row["esp1Y"];
	$esp2X = $row["esp2X"];
	$esp2Y = $row["esp2Y"];
	$esp3X = $row["esp3X"];
	$esp3Y = $row["esp3Y"];
	
	$roomX = $row["roomX"];
	$roomY = $row["roomY"];
	
	$house = array(array());
	
	$rooms = array();
	array_push($rooms, "No Room");
	$k = 1;
	
	for($i = 0; $i <= $roomX; $i++){
		for($j = 0; $j <= $roomY; $j++){
			$house[$i][$j] = 0;
		}
	}
	
	$query = "SELECT * FROM rooms";
	
	$res = mysqli_query($conn, $query);
	
	while($row = mysqli_fetch_assoc($res)){
		array_push($rooms, $row["name"]);
		
		for($i = $row["X0"]; $i <= $row["X1"]; $i++){
			for($j = $row["Y0"]; $j <= $row["Y1"]; $j++){
				$house[$i][$j] = $k;
			}
		}
		
		$k++;
	}
	
	/*for($i = 0; $i <= $roomX; $i++){
		for($j = 0; $j <= $roomY; $j++){
			echo $house[$i][$j] . "&nbsp;&nbsp;";
		}
		echo "<br>";
	}*/
	
	$query = "SELECT value FROM esp1 ORDER BY id DESC LIMIT 1";
	
	$res = mysqli_query($conn, $query);
	
	$row = mysqli_fetch_assoc($res);
	
	$esp1 = $row["value"];
	
	$query = "SELECT value FROM esp2 ORDER BY id DESC LIMIT 1";
	
	$res = mysqli_query($conn, $query);
	
	$row = mysqli_fetch_assoc($res);
	
	$esp2 = $row["value"];
	
	$query = "SELECT value FROM esp3 ORDER BY id DESC LIMIT 1";
	
	$res = mysqli_query($conn, $query);
	
	$row = mysqli_fetch_assoc($res);
	
	$esp3 = $row["value"];
	
	$esp1 = dbToUnit($esp1);
	$esp2 = dbToUnit($esp2);
	$esp3 = dbToUnit($esp3);
	
	if($esp1 < 0)
		$esp1 = 0;
	
	if($esp2 < 0)
		$esp2 = 0;
	
	if($esp3 < 0)
		$esp3 = 0;

	$roomIn = $rooms[0];
	
	
	for($i = 0; $i <= $roomX; $i++){
		$found = false;
		for($j = 0; $j <= $roomY; $j++){
			$d1 = getDist($esp1X, $esp1Y, $i, $j);
			$d2 = getDist($esp2X, $esp2Y, $i, $j);
			$d3 = getDist($esp3X, $esp3Y, $i, $j);
			
			/*echo "i: " . $i . "&emsp; j: " . $j . "<br>";
			echo "esp1: " . $esp1 . "&emsp; d1: " . $d1 . "<br>";
			echo "esp2: " . $esp2 . "&emsp; d2: " . $d2 . "<br>";
			echo "esp3: " . $esp3 . "&emsp; d3: " . $d3 . "<br>";
			echo "------------------------------------------<br>";*/
			
			if(eq($esp1, $d1) && eq($esp2, $d2) && eq($esp3, $d3)){
				$roomIn = $rooms[$house[$i][$j]];
				$found = true;
				//echo $i . " " . $j;
				break;
			}
		}
		
		if($found == true)
			break;
	}
	
	echo $roomIn;
?>
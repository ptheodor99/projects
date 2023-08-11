async function verifyEmail(email){
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			document.getElementById("err-email").innerHTML = this.responseText;
		}
	}
	req.open('GET', '../quizData/script/php/verifyEmail.php?em=' + email);
	req.send();
	
}

function encrypt(a){
	var hashObj = new jsSHA("SHA-256", "TEXT", {numRounds: 1});
	hashObj.update(a);
	a = hashObj.getHash("HEX");
	return a;
}

function logIn(){
	var email = document.getElementById('email').value;
	var pass = document.getElementById('pass').value; 
	
	pass = encrypt(pass);
	
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			var rez = this.responseText;
			
			if(rez == "NOK"){
				alert("Datele de logare nu sunt valide");
			}
			else{
				generateGeneral();
			}
		}
	}
	req.open('GET', '../quizData/script/php/checkLogin.php?email=' + email + '&pass=' + pass);
	req.send();
}

function generateGeneral(){
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			var rez = this.responseText;
			
			if(rez == 'NOK')
				alert("Va rog sa efectuati prima data logarea");
			else{
				document.getElementById("main").innerHTML = rez;
				document.getElementById("general").style.display = "block";
				document.getElementById("logout").style.display = "block";
				getStatut(function(response){
					if(response == 'admin'){
						document.getElementById("profesori").style.display = "block";
						document.getElementById("inscrieri").style.display = "block";
					}
				});

				document.getElementById("studenti").style.display = "block";
				getStatut(function(response){
					if(response != 'admin'){
						document.getElementById("intrebari").style.display = "block";
						document.getElementById("variante").style.display = "block";
						document.getElementById("subiecte").style.display = "block";
					}
				});
								
				document.getElementById("examene").style.display = "block";
			}
		}
	}
	req.open('GET', '../quizData/script/php/generateGeneral.php');
	req.send();
}

function logOut(){
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			location.reload();
		}
	}
	req.open('GET', '../quizData/script/php/logOut.php');
	req.send();	
}

function getStatut(callback){

	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			var rez = this.responseText;
			callback(rez);
		}
	}
	req.open('GET', '../quizData/script/php/getStatut.php');
	req.send();
	

}

function generateProfesori(){
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			var rez = this.responseText;
			
			if(rez[0] == 'X'){
				alert(rez.split(',')[1]);
			}
			else{
				document.getElementById("main").innerHTML = this.responseText;
			}
		}
	}
	req.open('GET', '../quizData/script/php/generateProfesori.php');
	req.send();
}

function addProf(){
	var numeProf = document.getElementById("addNumeProfesor").value;
	var emailProf = document.getElementById("addEmailProfesor").value;
	var parolaProf = document.getElementById("addParolaProfesor").value;
	var serieProf = document.getElementById("selectSerie").value;
	var materieProf = document.getElementById("selectMaterie").value;
	
	if(numeProf == ""){
		alert("Numele profesorului nu poate fi gol");
		return ;
	}
	else if(emailProf == ""){
		alert("Emailul profesorului nu poate fi gol");
		return ;
	}
	else if(parolaProf == ""){
		alert("Parola profesorului nu poate fi goala");
		return ;		
	}
	else if(serieProf == -1){
		alert("Trebuie selectata o serie");
		return ;
	}
	else if(materieProf == -1){
		alert("Trebuie selectata o materie");
		return ;
	}
	else{
		
		parolaProf = encrypt(parolaProf);
		
		var req = new XMLHttpRequest();
		req.onreadystatechange = function(){
			if(this.readyState == 4 && this.status == 200){
				generateProfesori();
			}
		}
		req.open('GET', '../quizData/script/php/addProf.php?numeProf=' + numeProf + '&emailProf=' + emailProf + '&parolaProf=' + parolaProf + '&materieProf=' + materieProf + '&serieProf=' + serieProf);
		req.send();
	}
}

function delProf(){
	var id = document.getElementById("selectProf").value;
	
	if(id == -1){
		alert("Trebuie sa selectati un profesor");
		return ;
	}
	else{	
		var req = new XMLHttpRequest();
		req.onreadystatechange = function(){
			if(this.readyState == 4 && this.status == 200){
				generateProfesori();
			}
		}
		req.open('GET', '../quizData/script/php/delProf.php?id=' + id);
		req.send();
	}
}

function editProf(){
	var idProf = document.getElementById("selectProf").value;
	var nume = document.getElementById("nume").value;
	var email = document.getElementById("email").value;
	var pass = document.getElementById("pass").value;
	var serieVeche = -2;
	var materieVeche = -2
	var serieNoua = -2
	var materieNoua = -2;
	
	if(pass != ""){
		pass = encrypt(pass);
	}

	try{
		serieVeche = document.getElementById("selectSerieExistenta").value;
	}
	catch(err){}
	
	try{
		materieVeche = document.getElementById("selectMaterieExistenta").value;
	}	
	catch(err){}
	
	try{
		serieNoua = document.getElementById("selectSerieInlocuire").value;
	}	
	catch(err){}
	
	try{
		materieNoua = document.getElementById("selectMaterieInlocuire").value;
	}	
	catch(err){}
	
	if(serieVeche == -1 || materieVeche == -1){
		alert("Daca ati deschis acest meniu va rog alegeti seria si materie");
		return ;
	}
	
	if(serieVeche >= 0 && serieNoua == -1){
		alert("Va rugam selectati si seria cu care se va inlocui");
		return ;
	}
	
	if(materieVeche >= 0 && materieNoua == -1){
		alert("Va rugam selectati si materia cu care se va inlocui");
		return ;
	}
	
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			generateProfesori();
		}
	}
	req.open('GET', '../quizData/script/php/editProf.php?id=' + idProf + '&nume=' + nume + '&email=' + email + '&pass=' + pass + '&serieVeche=' + serieVeche + '&materieVeche=' + materieVeche + '&serieNoua=' + serieNoua + '&materieNoua=' + materieNoua);
	req.send();		
}

function generateStudenti(){
	var ord = "";
	
	try{
		ord = document.getElementById("sortStudenti").value;
	}
	catch(err){}
	
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			var rez = this.responseText;
			
			if(rez[0] == 'X'){
				alert(rez.split(',')[1]);
			}
			else{
				document.getElementById("main").innerHTML = this.responseText;
			}
		}
	}
	req.open('GET', '../quizData/script/php/generateStudenti.php?ord=' + ord);
	req.send();
}

function addStud(){
	var numeStud = document.getElementById("numeStud").value;
	var emailStud = document.getElementById("emailStud").value;
	var grupaStud = document.getElementById("grupaStud").value;
	var serieStud = document.getElementById("serieStud").value;
	
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			generateStudenti();
		}
	}
	req.open('GET', '../quizData/script/php/addStud.php?numeStud=' + numeStud + '&emailStud=' + emailStud + '&grupaStud=' + grupaStud + '&serieStud=' + serieStud);
	req.send();
}

function editStud(id){
	var numeStud = document.getElementById("numeStud").value;
	var emailStud = document.getElementById("emailStud").value;
	var grupaStud = document.getElementById("grupaStud").value;
	var serieStud = document.getElementById("serieStud").value;
	ids = id.split(',');
	id = ids[1];
	
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			generateStudenti();
		}
	}
	req.open('GET', '../quizData/script/php/editStud.php?numeStud=' + numeStud + '&emailStud=' + emailStud + '&grupaStud=' + grupaStud + '&serieStud=' + serieStud + '&id=' + id);
	req.send();
}

function delStud(){
	var minMax = document.getElementById("minMax").value;
	let values = minMax.split(",");	
	
	let min = parseInt(values[0]);
	let max = parseInt(values[1]);
	
	var ids = "";
	
	for(let i = min; i <= max; i++){
		try{
		var val = document.getElementById("delete" + i).checked;
		
		if(val == true)
			ids = ids + i + ',';
		}
		catch(err){}
	}

	ids = ids.slice(0, ids.length - 1);
	
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			generateStudenti();
		}
	}
	req.open('GET', '../quizData/script/php/delStud.php?vals=' + ids);
	req.send();
}

function generateIntrebari(){
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			document.getElementById("main").innerHTML = this.responseText;
		}
	}
	req.open('GET', '../quizData/script/php/generateIntrebari.php');
	req.send();	
}

function addSub(idd){
	var id = idd.split(',')[1];
	
	document.getElementById("lib," + id).style.display = "none";
	document.getElementById("exam," + id).style.display = "block";
}

function removeSub(idd){
	var id = idd.split(',')[1];
	
	document.getElementById("lib," + id).style.display = "block";
	document.getElementById("exam," + id).style.display = "none";
}

function createExamen(){
	var ids = "";
	
	var minMax = document.getElementById("minMax").value;
	var codMaterie = document.getElementById("codMaterie").value;
	var punctaj = document.getElementById("punctaj").value;
	
	minMax = minMax.split(',');
	
	var min = minMax[0];
	var max = minMax[1];
	
	for(var i = min; i <= max; i++){
		try{
			if(document.getElementById("exam," + i).style.display == "block")
				ids = ids + i + ',';
		}
		catch(err){}
	}
	
	ids = ids.slice(0, ids.length - 1);
	
	var examStart = document.getElementById("examStart").value;
	
	var examEnd = document.getElementById("examEnd").value;
	
	var numeExamen = document.getElementById("numeExamen").value;
	
	var ok = true;
	
	
	
	if(numeExamen == ""){
		ok = false;
		alert("Numele examenului nu poate fi gol");
	}
	else if(examEnd == "" || examStart == ""){
		ok = false;
		alert("Datele examenului nu pot fi goale");
	}
	else if(examEnd < examStart){
		ok = false;
		alert("Data de inceput nu poate fi ulterioara datei de sfarsit");
	}
	else if(ids == ""){
		ok = false;
		alert("Trebuie selectata cel putin o intrebare");
	}
	else if(punctaj == ""){
		ok = false;
		alert("Trebuie specificat punctajul");
	}
	
	if(ok == true){
		var req = new XMLHttpRequest();
		req.onreadystatechange = function(){
			if(this.readyState == 4 && this.status == 200){
				generateIntrebari();
			}
		}
		req.open('GET', '../quizData/script/php/createExamen.php?ids=' + ids + '&numeExamen=' + numeExamen + '&examStart=' + examStart + '&examEnd=' + examEnd + '&codMaterie=' + codMaterie + '&punctaj=' + punctaj);
		req.send();
	
	}
}

function generateSubiecte(){
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			document.getElementById("main").innerHTML = this.responseText;
		}
	}
	req.open('GET', '../quizData/script/php/generateSubiecte.php');
	req.send();req.send();
}

function delExamen(id){
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			generateSubiecte();
		}
	}
	req.open('GET', '../quizData/script/php/delExamen.php?id=' + id);
	req.send();req.send();	
}

function generateVariante(){
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){	
			document.getElementById("main").innerHTML = this.responseText;			
		}
	}
	req.open('GET', '../quizData/script/php/generateVariante.php');
	req.send();	
}

function addVarianta(){
	var enunt = document.getElementById("enunt").value;
	var G1 = document.getElementById("G1").value;
	var G2 = document.getElementById("G2").value;
	var G3 = document.getElementById("G3").value;
	var G4 = document.getElementById("G4").value;
	var RU = document.getElementById("RU").value;
	var selected = document.getElementById("correct").value;
	
	var ok = true;
	
	if(enunt == ""){
		ok = false;
		alert("Trebuie sa specificati enuntul intrebarii");
	}
	else if(selected == ""){
		ok = false;
		alert("Trebuie selectata o varianta corecta");
	}
	else{
		if(selected != "RU"){
			if(G1 == "" || G2 == "" || G3 == "" || G4 == ""){
				ok = false;
				alert("Raspunsul grilelor nu poate fi gol");
			}
		}
		else{
			if(RU == ""){
				ok = false;
				alert("Raspunsul unic nu poate fi gol");
			}
		}
	}
	
	if(ok == true){
		var req = new XMLHttpRequest();
		req.onreadystatechange = function(){
			if(this.readyState == 4 && this.status == 200){	
				generateVariante();		
			}
		}
		req.open('GET', '../quizData/script/php/addVarianta.php?sel=' + selected + '&G1=' + G1 + '&G2=' + G2 + '&G3=' + G3 + '&G4=' + G4 + '&RU=' + RU + '&enunt=' + enunt);
		req.send();		
	}
}

function editVarianta(idd){
	var id = idd.split(',')[1];
	
	var enunt = document.getElementById("enunt").value;
	var G1 = document.getElementById("G1").value;
	var G2 = document.getElementById("G2").value;
	var G3 = document.getElementById("G3").value;
	var G4 = document.getElementById("G4").value;
	var RU = document.getElementById("RU").value;
	var selected = document.getElementById("correct").value;
	
	var ok = true;
	
	if(selected == "RU" && RU == ""){
		ok = false;
		alert("Daca este selectat raspunul unic este obligatoriu sa fie completat campul acestuia");
	}
	
	if(ok == true){
		var req = new XMLHttpRequest();
		req.onreadystatechange = function(){
			if(this.readyState == 4 && this.status == 200){	
				generateVariante();		
			}
		}
		req.open('GET', '../quizData/script/php/editVarianta.php?sel=' + selected + '&G1=' + G1 + '&G2=' + G2 + '&G3=' + G3 + '&G4=' + G4 + '&RU=' + RU + '&enunt=' + enunt + '&id=' + id);
		req.send();		
	}
}

function delVarianta(idd){
	var id = idd.split(',')[1];
	
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){	
			generateVariante();		
		}
	}
	req.open('GET', '../quizData/script/php/delVarianta.php?id=' + id);
	req.send();			
}

function generateRezultate(){
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){	
			document.getElementById("main").innerHTML = this.responseText;
			generateG1();
		}
	}
	req.open('GET', '../quizData/script/php/generateRezultate.php');
	req.send();	
}

function generateG1(){
	var canvas = document.getElementById('G1');
	var examsG1 = document.getElementById('examsG1').value.split(',');
	var averagesG1 = document.getElementById('averagesG1').value.split(',');
			
			new Chart(canvas, {
			  type: 'bar',
			  data: {
				labels: examsG1, 
				datasets: [{
				  label: 'Media notelor',
				  data: averagesG1,
				  backgroundColor: 'rgba(0, 123, 255, 0.5)', 
				  borderColor: 'rgba(0, 123, 255, 1)', 
				  borderWidth: 1
				}]
			  },
			  options: {
				scales: {
				  y: {
					beginAtZero: true,
					max: 100 
				  }
				}
			  }
			});	
}

function generateInscrieri(){
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){	
			document.getElementById("main").innerHTML = this.responseText;			
		}
	}
	req.open('GET', '../quizData/script/php/generateInscrieri.php');
	req.send();	
}

function enrolStud(idd){
	var id = idd.split(',')[1];
	
	var minMax = document.getElementById("minMax").value.split(',');
	
	var min = minMax[0];
	var max = minMax[1];
	
	var ids = "";
	
	for(var i = min; i <= max; i++){
		try{
			if(document.getElementById(i).checked == true)
				ids = ids + i + ',';
		}
		catch(err){}
	}
	
	ids = ids.slice(0, ids.length - 1);
	
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){	
			generateInscrieri();		
		}
	}
	req.open('GET', '../quizData/script/php/enrolStud.php?id=' + id + '&ids=' + ids);
	req.send();	
}

function generateAddProfForm(){
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			document.getElementById("generateAddProfForm").innerHTML = this.responseText;
		}
	}
	req.open('GET', '../quizData/script/php/generateAddProfForm.php');
	req.send();	
}

function generateDelProfForm(){
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			document.getElementById("generateAddProfForm").innerHTML = this.responseText;
		}
	}
	req.open('GET', '../quizData/script/php/generateDelProfForm.php');
	req.send();
}

function matchProf(){

		var searchValue = document.getElementById("searchProf").value.toLowerCase();
		var options = document.getElementById('selectProf').options;
		for (var i = 0; i < options.length; i++) {
		  var optionText = options[i].text.toLowerCase();
		  if (optionText.includes(searchValue)) {
			options[i].style.display = 'block';
		  } else {
			options[i].style.display = 'none';
		  }
		}
	  
}

function generateModificaProfForm(){
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			document.getElementById("generateAddProfForm").innerHTML = this.responseText;
		}
	}
	req.open('GET', '../quizData/script/php/generateModificaProfForm.php');
	req.send();
}

function generateAddMaterieProfForm(){
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			document.getElementById("generateAddProfForm").innerHTML = this.responseText;
		}
	}
	req.open('GET', '../quizData/script/php/generateAddMaterieProfForm.php');
	req.send();
}

function bindMaterie(){
	var prof = document.getElementById("selectProf").value;
	var serie = document.getElementById("selectSerie").value;
	var materie = document.getElementById("selectMaterie").value;

	if(prof == -1){
		alert("Trebuie selectat un profesor");
		return ;
	}

	if(serie == -1){
		alert("Trebuie selectata o serie");
		return ;
	}

	if(materie == -1){
		alert("Trebuie selectata o materie");
		return ;
	}

	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			generateProfesori();
		}
	}
	req.open('GET', '../quizData/script/php/bindMaterie.php?prof=' + prof + '&serie=' + serie + '&materie=' + materie);
	req.send();
}

function generateMaterieProf(){
	var id = document.getElementById("selectProf").value;

	if(id == -1){
		alert("Trebuie selectat un profesor");
		return ;
	}

	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			document.getElementById("materieProf").innerHTML = this.responseText;
		}
	}
	req.open('GET', '../quizData/script/php/generateMaterieProf.php?id=' + id);
	req.send();
}

function deleteMaterieSerie(){
	var id = document.getElementById("selectProf").value;
	var serie = document.getElementById("selectSerieExistenta").value;
	var materie = document.getElementById("selectMaterieExistenta").value;
	
	if(id == -1){
		alert("Va rugam selectati un profesor");
		return ;
	}
	
	if(serie == -1 || materie == -1){
		alert("Va rugam selectati o serie si o materie pentru stergere");
		return ;
	}
	
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(){
		if(this.readyState == 4 && this.status == 200){
			generateProfesori();
		}
	}
	req.open('GET', '../quizData/script/php/deleteMaterieSerie.php?id=' + id + '&serie=' + serie + '&materie=' + materie);
	req.send();
}

function searchStudent(){
	var toSearch = document.getElementById("searchStudent").value.toLowerCase();
	var divs = document.querySelectorAll('div[class^="student"]');
	
	for(var i = 0; i < divs.length; i++){
		var name = divs[i].id.toLowerCase();
		if(name.includes(toSearch)){
			divs[i].style.display = "block";
		}
		else{
			divs[i].style.display = "none";
		}
	}
}
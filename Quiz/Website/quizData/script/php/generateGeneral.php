<?php
	session_set_cookie_params(0);
	ob_start();
	session_start();
	
	
	
	echo '<div class="page-general">';
	echo'<img src="img/quiz_web.svg">
	<p>&emsp;O metodă binecunoscută prin care sunt evaluate cunoștințele dobândite de către studenți este testul docimologic. Pentru ca rezultatele să poată fi monitorizate cu ușurință a fost creată această platforma web. Mai mult decât atât, profesorii pot crea examene atât parțiale, cât și finale. Intrebările aferente examenelor pot fi modificate în orice moment, impreună cu răspunsurile corespunzătoare.</p>

	<span>Așadar, prin intermediul acestei platforme cadrele universitare au posibilitatea de a gestiona prin adăugarea/ștergerea/modificarea:</span>
	
	<ul>
		<li>studenților ce pot să susțină examenele aferente</li>
		<li>materiilor pentru care sunt întocmite examenele</li>
		<li>întrebărilor și răspunsurilor ce stau la baza examenelor</li>
		<li>examenelor propriu-zise	</li>
	</ul>
	';
	
	echo'</div>';
?>

Views -> Home -> Index   og   
	Tekst p� siden �ndre st�rrelse efter sk�rmst�rrelse
	Henter gifs fra internettet via img elementer
	Katte gif'en reagere n�r musen holdes over, og knappen derp� f�re til log ind siden.
	N�r siden er under 500px dukker der en ny gif op
	Ajax? knappen laver et ajax call gennem controlleren "HomeController" med funktionen AjaxCall()
	Click for 10 facts knappen printer 14 facts fra en txt fil i js mappen, via et ajax call i site.js med funktionen Ajax()
	Compliments :) knappen printer 1 af 10 forskellige komplimenter, funktionen er skrevet i site.js med funktionen Compliment()

wwwroot -> css -> site
	Der er �ndret p� farven af input felter p� logind og registrer siderne
	Alt udseende der er p� Home page er skrevet inde i dette script

wwwroot -> js -> site
	Funktioner til compliment knap, ajax? knap og facts knap der er p� homepage
	Der bruges en random funktion til at bestemme hvilken kompliment der bliver printet p� siden.

	Et fors�g p� at lave en validation funktion til input felter p� OurPicUploads side, disse er dog lavet til required inde p� modellen OurPicUploads

Views -> Home -> Privacy
	

Views -> OurPicUploads -> ShowOurPicUploads
	2 foreach loops der g�r gennem databasen for hver bruger der er oprettet og printer alle denne brugers billeder.
	Dette g�res ved at bruge en ViewModel kaldet Display i ViewModel mappen, som sammenligner userId med det gemte 
	profileID, der gemmes i databasen fra hvilken user der oploader et billede. 
	Der er dertil sat en delete buttion p�, som f�re til den autogenerede delete page.

ViewModel -> Display
	En viewmodel der laver en mellem tabel 

Models -> OurPicUploads

Controllers -> HomeController

Controllers -> OurPicUploadsController


wwwroot -> css -> snake



wwwroot -> js -> snake

wwwroot -> Pics

LogIn system
Vi har brugt det allerede implementerede logIn system.

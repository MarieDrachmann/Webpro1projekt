
N�r systemet starte, kommer man ind p� homepage, herfra skal man f�rst registrere sig som bruger, for derefter at logge ind.
Herefter kan man se to yderligere knapper i navigationsbaren, Upload pics og show the pics, hvor man henholdsvis kan uploade billeder 
eller se alle billeder og hvilke brugere der har lagt billeder op med titler og beskrivelser. Man kan ogs� g� til en liste under hvert af
billederne hvor man kan se alle informationer der er i databasen omkring billederne. 
Der er en delete knap hvor man kan fjerne billeder fra databasen. 

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

Views -> Shared -> _Layout
Der er lavet en if metode her, hvor man kun kan se upload pics! og Show them pic!lol knapperne hvis man er logget ind. _

ViewModel -> Display
	En viewmodel der laver en mellem tabel der holder foreign keys til brugertabel og billedtabel i database

Models -> OurPicUploads
	Model for hvad et objekt skal indholde n�r et billede oploades.
	Der er skrevet RegEx ind over hvert felt for at undg� at der kommes bestemte karaktertegn ind i inputfelterne og 
	videre ind i databasen.
	Felterne er lavet required fordi de skal udfyldes f�rend noget kan uploades. 
	PicFile er ikke mappet, da denne ikke l�gges i databasen, men derimod ind i en mappe, Pics i wwwroot folderen.

Controllers -> HomeController
	Har en funktion til AjaxCall()

Controllers -> OurPicUploadsController
	funktionen ShowOurPicUploads() opretter Display viewmodel 
	funktionen Create(OurPicUploads ourPicUpload) som l�gger information ind i databasen om hvor billeder kan findes via 
	url adresse til Pics folder. Den laver navnet om p� billederne. Tjekker om billederne har den rigtige filformat.
	Man kan kun uploade billeder n�r picupload feltet er udfyldt og at modelstate er valid.

wwwroot -> css -> snake



wwwroot -> js -> snake

wwwroot -> Pics
	Indeholder de oploadede billeder

LogIn system
	Vi har brugt det allerede implementerede logIn system.

Cross-Site-Scripting
	Bliver implementeret automatisk af MVC template

SQLInjection
	Bliver implementeret automatisk af MVC template
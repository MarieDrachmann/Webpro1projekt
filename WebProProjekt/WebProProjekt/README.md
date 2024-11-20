
Når systemet startes, kommer man ind på homepage, herfra skal man først registrere sig som bruger, 
for derefter at logge ind.
Herefter kan man se to yderligere knapper i navigationsbaren, Upload pics og show the pics, 
hvor man henholdsvis kan uploade billeder eller se alle billeder og hvilke brugere der har 
lagt billeder op med titler og beskrivelser. 
Man kan også gå til en liste under hvert af billederne hvor man kan se alle informationer 
der er i databasen omkring billederne. 
Der er en delete knap hvor man kan fjerne billeder fra databasen. 

Applikation hvor brugere kan uploade billeder med titel og beskrivelse.
	Views -> OurPicUploads -> ShowOurPicUploads
	2 foreach loops der går gennem databasen for hver bruger der er oprettet og printer alle 
	denne brugers billeder.
	Dette gøres ved at bruge en ViewModel kaldet Display i ViewModel mappen, som sammenligner 
	userId med det gemte profileID, der gemmes i databasen fra hvilken user der oploader et billede. 
	Der er dertil sat en delete buttion på, som føre til den autogenerede delete page.
	for at fremvise billeder er der lavet en viewmodel (Display) der laver en mellem tabel der 
	holder foreign keys til brugertabel og billedtabel i database
	Controllers -> OutPicUploadsController
	funktionen ShowOurPicUploads() opretter Display viewmodel 
	funktionen Create(OurPicUploads ourPicUpload) som lægger information ind i databasen om hvor billeder kan findes via 
	url adresse til Pics folder. Den laver navnet om på billederne. Tjekker om billederne har den rigtige filformat.
	Man kan kun uploade billeder når picupload feltet er udfyldt og at modelstate er valid.


Kun brugere som er logget ind må kunne uploade og se hinandens uploads.
	Views -> Shared -> _Layout
	Der er lavet en if metode her, hvor man kun kan se upload pics! og Show them pic!lol 
	knapperne hvis man er logget ind.

Formular til registrering af brugere
	Implementeret af systemet selv.

Formular til login
	Implementeret af systemet selv.

Formularer skal bruge JavaScript og RegEx til at validere brugerinput
	Lavet af Marie Drachmann {
	Models -> OurPicUploads
	Model for hvad et objekt skal indholde når et billede oploades.
	Der er skrevet RegEx ind over hvert felt for at undgå at der kommes bestemte karaktertegn ind i inputfelterne og 
	videre ind i databasen.
	Felterne er lavet required fordi de skal udfyldes førend noget kan uploades. 
	PicFile er ikke mappet, da denne ikke lægges i databasen, men derimod ind i en mappe, 
	Pics i wwwroot folderen.
	}

I skal sikre jer mod Cross-Site Scripting (CXX)
	Er implementeret i create metode og edit metode i OurPicController, dog virker edit metoden ikke 
	så man ikke ikke ændre i billederne når de først er oploaded.

I skal sikre jer mod SQL Injection
	Fordi at der bliver brugt LinQ og og Entity Framework i koden, bliver koden sikret når den genereres

Man skal kunne se en liste over brugere et sted
	Views -> OurPicUploads -> ShowOurPicUploads
	Når siden er startet op kan man gå ind på "Show them pics! lol" her vil der i toppen af siden være 
	en liste over alle brugere i databasen, også dem der ikke har lagt et billede op.
	
Noget skal være responsivt
Views -> Home -> Index   
	Tekst på siden ændre størrelse efter skærmstørrelse
	Når siden er under 500px dukker der en ny gif op
	Compliments :) knappen printer 1 af 10 forskellige komplimenter, funktionen er skrevet i site.js med funktionen Compliment()

I skal selv skrive både noget CSS og Javascript, men der må gerne suppleres med jQuery, Bootstrap & Fontawesome
	Views -> Home -> Index
	Lavet af Marie Drachmann {
	Henter gifs fra internettet via img elementer
	Katte gif'en reagere når musen holdes over, og knappen derpå føre til log ind siden.
	Der er ændret på farven af input felter på logind og registrer siderne
	Alt udseende der er ændret fra originalen der er på Home page er skrevet inde i dette script
	}

Der skal laves et ajax kald
	Ajax? knappen laver et ajax call gennem controlleren "HomeController" med funktionen AjaxCall()
	Click for 10 facts knappen printer 14 facts fra en txt fil i js mappen, via et ajax call i 
	site.js med funktionen Ajax()



ViewModel -> Display
	


Controllers -> HomeController
	Har en funktion til AjaxCall()

Controllers -> OurPicUploadsController
	

wwwroot -> css -> snake



wwwroot -> js -> snake

wwwroot -> Pics
	Indeholder de oploadede billeder







Lav en model - Se det som at oprette en tabel via construters
ved at k�re migrations via package manager consoler (�bnes gennem tools -> NuGetmanager -> Package manager console)
	Her i skriver man da: Add-Migration navnP�Migration
N�r der er lavet en migration kan man lave en console der skal g�re hvad en console g�r. 
	(l�s op p� det. https://www.tutorialspoint.com/asp.net_mvc/index.htm)



Databasen bliver sat op i scriptet Program.cs med den her:
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
Databasen er den der allerede er implementeret i programmet.


Tilf�jet en knap i topbaren til at kunne g� ind p� sin egen side til uploads af billeder.
Tilf�jede en ny klasse i HomeController.cs navngivet efter den nye fil (upload), inde i _layout.cshtml blev der tilf�jet en knap i 
topbaren der f�rste til hjemmesiden og giver navnet p� den fil som skal g�es til n�r knappen trykkes p�.

Der er oprettet en model der hedder users der tager argumenter som id, email og password.
Man kan lave en controller n�r man har en model ved at h�jreklikke p� controller mappen, sige add -> new scaffoled item... 
-> MVC Controller with views, using Entity Framework -> sige hvilken model den skal oprettes ud fra og hvilken database
der h�re til, husk et navn ogs�.

Controlleren skal kobles op med det der bliver skrevet ind p� login siden.

Der er lavet ajax via den site.js hvor den henter 10 facts fra et txt dokument.
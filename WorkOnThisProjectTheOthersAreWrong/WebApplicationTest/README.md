Lav en model - Se det som at oprette en tabel via construters
ved at køre migrations via package manager consoler (åbnes gennem tools -> NuGetmanager -> Package manager console)
	Her i skriver man da: Add-Migration navnPåMigration
Når der er lavet en migration kan man lave en console der skal gøre hvad en console gør. 
	(læs op på det. https://www.tutorialspoint.com/asp.net_mvc/index.htm)



Databasen bliver sat op i scriptet Program.cs med den her:
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
Databasen er den der allerede er implementeret i programmet.


Tilføjet en knap i topbaren til at kunne gå ind på sin egen side til uploads af billeder.
Tilføjede en ny klasse i HomeController.cs navngivet efter den nye fil (upload), inde i _layout.cshtml blev der tilføjet en knap i 
topbaren der første til hjemmesiden og giver navnet på den fil som skal gåes til når knappen trykkes på.

Der er oprettet en model der hedder users der tager argumenter som id, email og password.
Man kan lave en controller når man har en model ved at højreklikke på controller mappen, sige add -> new scaffoled item... 
-> MVC Controller with views, using Entity Framework -> sige hvilken model den skal oprettes ud fra og hvilken database
der høre til, husk et navn også.

Controlleren skal kobles op med det der bliver skrevet ind på login siden.

Der er lavet ajax via den site.js hvor den henter 10 facts fra et txt dokument.
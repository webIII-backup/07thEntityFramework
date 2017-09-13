using System;
using BeerhallEF.Models;
using System.Linq;

namespace BeerhallEF.Data
{
    public class BeerhallDataInitializer
    {
        private readonly ApplicationDbContext _context;

        public BeerhallDataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitializeData()
        {
            if (!_context.Locations.Any())
            {
                Location bavikhove = new Location { Name = "Bavikhove", PostalCode = "8531" };
                Location roeselare = new Location { Name = "Roeselare", PostalCode = "8800" };
                Location puurs = new Location { Name = "Puurs", PostalCode = "2870" };
                Location leuven = new Location { Name = "Leuven", PostalCode = "3000" };
                Location oudenaarde = new Location { Name = "Oudenaarde", PostalCode = "9700" };
                Location affligem = new Location { Name = "Affligem", PostalCode = "1790" };
                Location gent = new Location { Name = "Gent", PostalCode = "9000" };
                Location[] gemeenten =
                    { bavikhove, roeselare, puurs, leuven, oudenaarde, affligem,gent };
                _context.Locations.AddRange(gemeenten);
                _context.SaveChanges();

                Brewer bavik = new Brewer("Bavik", bavikhove, "Rijksweg 33");
                _context.Brewers.Add(bavik);
                bavik.AddBeer("Bavik Pils", 0.4m);
                bavik.AddBeer("Wittekerke", 1.0m );
                bavik.AddBeer("Wittekerke Speciale", 1.8m);
                bavik.AddBeer("Wittekerke Rosé", 1.3m);
                bavik.AddBeer("Ezel Wit",1.8m);
                bavik.AddBeer("Ezel Bruin", 2.5m);
                bavik.Turnover = 20000000;
                bavik.DateEstablished = new DateTime(1990, 12, 26);
                bavik.ContactEmail = "info@bavik.be";
                bavik.Description =
                    "Brouwerij De Brabandere kan terugblikken op een rijke geschiedenis, maar kijkt met evenveel vertrouwen naar de toekomst. De droom die stichter Adolphe De Brabandere op het eind van de negentiende eeuw koestert wanneer hij in Bavikhove de fundamenten legt van zijn brouwerij, is realiteit geworden in de succesvolle onderneming van vandaag.Met een rijk assortiment bieren dat gesmaakt wordt door kenners tot ver buiten onze landsgrenzen.Brouwen was, is, en blijft een kunst bij Brouwerij De Brabandere. Beschouw onze talrijke karaktervolle bieren gerust als erfgoed: gemaakt met traditioneel vakmanschap, met authentieke ingrediënten en… veel liefde. Het creëren van een unieke smaaksensatie om te delen met vrienden, dat drijft ons dag in dag uit.  Zonder compromissen.";

                Brewer palm = new Brewer("Palm Breweries");
                _context.Brewers.Add(palm);
                palm.AddBeer("Estimanet", 1.2m);
                palm.AddBeer("Steenbrugge Blond", 1.5m);
                palm.AddBeer("Palm", 0.9m);
                palm.AddBeer("Dobbel Palm", 1.7m);
                palm.Turnover = 500000;

                Brewer duvelMoortgat = new Brewer("Duvel Moortgat", puurs, "Breendonkdorp 28");
                _context.Brewers.Add(duvelMoortgat);
                duvelMoortgat.AddBeer("Duvel", 1.05m);
                duvelMoortgat.AddBeer("Vedett",1.25m);
                duvelMoortgat.AddBeer("Maredsous",2.0m);
                duvelMoortgat.AddBeer("Liefmans Kriekbier",1.5m);
                duvelMoortgat.AddBeer("La Chouffe", 1.3m);
                duvelMoortgat.AddBeer("De Koninck", 1.4m);

                Brewer inBev = new Brewer("InBev", leuven, "Brouwerijplein 1");
                _context.Brewers.Add(inBev);
                inBev.AddBeer("Jupiler", 0.9m);
                inBev.AddBeer("Stella Artois",0.9m);
                inBev.AddBeer("Leffe",1.9m);
                inBev.AddBeer("Belle-Vue",1.39m);
                inBev.AddBeer("Hoegaarden",1.1m);

                Brewer roman = new Brewer("Roman", oudenaarde, "Hauwaart 105");
                _context.Brewers.Add(roman);
                roman.AddBeer("Sloeber", 2.5m);
                roman.AddBeer("Black Hole", 2.6m);
                roman.AddBeer("Ename", 1.5m);
                roman.AddBeer("Romy Pils",0.6m);

                Brewer deGraal = new Brewer("De Graal");
                _context.Brewers.Add(deGraal);

                Brewer deLeeuw = new Brewer("De Leeuw");
                _context.Brewers.Add(deLeeuw);

                _context.SaveChanges();



                Category cat1 = new Category("Groep1");
                Category cat2 = new Category("Groep2");
                _context.Categories.AddRange(new Category[] { cat1, cat2 });
                cat1.Add(roman);
                cat1.Add(palm);
                cat2.Add(roman);
                cat1.Add(bavik);
                _context.SaveChanges();

                 //bavik.AddCourse(new OnsiteCourse("Bierbrouwen gevorderd", Language.Nederlands, bavik, 3,
                //    DateTime.Today.AddDays(-50)));
                bavik.AddCourse(new OnsiteCourse("Bierbrouwen basis", Language.Nederlands, bavik, 3,
                    DateTime.Today.AddDays(50)));
                bavik.AddCourse(new OnlineCourse("Brewing beer Advanced", Language.English, bavik,
                    "http://www.bavik.com/courses/2"));
                _context.SaveChanges();
            }
        }

    }

}


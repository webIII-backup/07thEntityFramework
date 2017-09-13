using BeerhallEF.Data;
using BeerhallEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeerhallEF
{
    class Program
    {
    
        private static IEnumerable<Brewer> _brewers;
        private static Brewer _brewer;

        public static void Main(string[] args)
        {

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                new BeerhallDataInitializer(context).InitializeData();
                Console.WriteLine("Database created");
            }

            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                #region "Linq to entities"
                QueryData(context);
                #endregion

                #region "DbContext en updates"
                SavingData(context);
                #endregion
            }            

            Console.ReadKey();
        }

        private static void QueryData(ApplicationDbContext context)
        {
            /*----------------------Basic Query------------------------------*/

            Console.WriteLine("\n---Loading all brewers, ordered by name---");
            _brewers = null;
            PrintBrewers();

            Console.WriteLine("\n---Loading the brewer with id 1---");
            //SingleOrDefault, Single, FirstOrDefault, First (zie tips)
            _brewer = null;
            if (_brewer != null)
                Console.WriteLine($"Brewer with id 1: {_brewer.Name}");

            Console.WriteLine("\n---Filtering the brewers:  brewers whose name starts with b---");
            _brewers = null;
            PrintBrewers();

            Console.WriteLine("\n---Filtering the brewers:  brewers from Leuven--");
            _brewers = null;
            PrintBrewers();

            Console.WriteLine("\n---Filtering the brewers: brewers with more than 4 beers, ordered by name---");
            _brewers = null;
            PrintBrewers();

            Console.WriteLine("\n----Filtering the brewers: brewers with a beer starting with the letter B. ---");
            _brewers = null;
            PrintBrewers();


            /*----------------------Loading related data------------------------------*/
            Console.WriteLine("\n---All beers from brewer with id 1---");
            _brewer = null;
            PrintBeers(_brewer.Beers);

            Console.WriteLine("\n---All brewers from Leuven, print the name and the number of beers---");
            _brewers = null;
            foreach (Brewer br in _brewers)
                Console.WriteLine(br.Name + " " + br.Beers.Count);

            //Better Performance with projections
            Console.WriteLine("\n---All brewers from Leuven, print the name and the number of beers - Use projections---");
            var brewers2 = context.Brewers
                .Where(b => b.Location.Name == "Leuven")
                .Select(b => new { Name = b.Name, NumberOfBeers = b.Beers.Count })
                .ToList();
            foreach (var br in brewers2)
                Console.WriteLine(br.Name + " " + br.NumberOfBeers);

            Console.WriteLine("\n---Loading multiple relationships: all brewers, print name, location and number of beers--");
            _brewers = null;
            foreach (Brewer br in _brewers)
                Console.WriteLine(
                    $"{br.Name,-20} {(br.Location != null ? br.Location.Name : ""),20} {br.Beers.Count,20:N0}");


            Console.WriteLine("\n---Including multiple levels: All brewers from the first category---");
            var category = new Category("test");
            _brewers = category.Brewers;
            PrintBrewers();

            Console.WriteLine("\n---Explicit loading: all english courses from bavik--");
            _brewer = context.Brewers
                .FirstOrDefault(b => b.Name == "Bavik");

            //load the english courses

            foreach (var c in _brewer.Courses)
            {
                Console.WriteLine(c.Title);
            }

            Console.WriteLine("\n---Explicit loading: all courses from bavik--");
            _brewer = context.Brewers
                .FirstOrDefault(b => b.Name == "Bavik");

            //load all courses

            foreach (var c in _brewer.Courses)
            {
                Console.WriteLine(c.Title);
            }



            /*----------------------Client versus server evaluation------------------------------*/
            Console.WriteLine("\n---All brewers with NrOfBeers > 4--");
            _brewers = null;
            _brewers.ToList().ForEach(b => Console.WriteLine($"{b.Name}: {b.NrOfBeers}"));

            Console.WriteLine("\n---Overerving--");
            _brewer = context.Brewers.SingleOrDefault(b => b.Name == "Bavik");
            var courses = _brewer.Courses.OfType<OnlineCourse>().ToList();
            courses.ForEach(c => Console.WriteLine(c.Title));
        }


        private static void SavingData(ApplicationDbContext context)
        {
            /*----------------------Basic Save------------------------------*/
            Console.WriteLine("\n---Add: Create Brewer Gentse Gruut, Rembert Dodoensdreef, 9000 Gent ---");
            Brewer gruut = new Brewer("Gentse Gruut")
            {
                Street = "Rembert Dodoensdreef",
                Location = null
            };

            Console.WriteLine("\n---Add in ICollection : add Course 'Hoppe'---");
            _brewer = context.Brewers.Single(b => b.BrewerId == 1);
            Course course = new OnlineCourse("Hoppe", Language.Nederlands, _brewer, "http://hoppe@hogent.be");


            Console.WriteLine("\n---Update : Give Gentse Gruut a new address in Roeselare---");
            Location roeselare = context.Locations.SingleOrDefault(g => g.PostalCode == "8800");
            gruut = context.Brewers.FirstOrDefault(b => b.Name == "Gentse Gruut");


            Console.WriteLine("\n---Delete : remove Gentse Gruut---");
            Console.WriteLine("Number of brewers before delete: " + context.Brewers.Count());
            gruut = context.Brewers.First(b => b.Name == "Gentse Gruut");
            Console.WriteLine("Number of brewers after delete: " + context.Brewers.Count());

            Console.WriteLine("\n---Transactions, multiple operations in 1 save, change the turnover of the first to brewers---");
            Brewer brewer1 = context.Brewers.Single(b => b.BrewerId == 1);
            Brewer brewer2 = context.Brewers.Single(b => b.BrewerId == 2);

            /*----------------------Related data------------------------------*/
            Console.WriteLine("\n---Create Brewer De Koninck, Mechelsesteenweg 291, 2018 Antwerpen--");
            Console.WriteLine("Number of cities before insert:" + context.Locations.Count());
            Brewer dekoninck = new Brewer("De Koninck", new Location() { PostalCode = "2018", Name = "Antwerpen" }, "Mechelsesteenweg 291");
            Console.WriteLine("Number of cities after insert:" + context.Locations.Count());

            Console.WriteLine("\n---Removing relationships: Remove the first Beer from Bavik - Delete --");
            _brewer = context.Brewers.Single(b => b.Name == "Bavik");
            Beer beer = _brewer.Beers.First();

        }

        private static void PrintBrewers()
        {
            _brewers.ToList().ForEach(b => Console.WriteLine($"{b.Name}"));
        }

        private static void PrintBeers(IEnumerable<Beer> beers)
        {
            beers.ToList().ForEach(b => Console.WriteLine($"{b.Name:-20}  {b.Price}"));
        }
    }
}



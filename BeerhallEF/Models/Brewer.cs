using System;
using System.Collections.Generic;

namespace BeerhallEF.Models
{
    public class Brewer
    {
        #region Properties

        public int BrewerId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ContactEmail { get; set; }

        public DateTime? DateEstablished { get; set; }

        public int? Turnover { get; set; }

        public string Street { get; set; }

        public ICollection<Beer> Beers { get; private set; }

        public int NrOfBeers => Beers.Count;

        #endregion

        #region Constructors
        protected Brewer()
        {
            Beers = new HashSet<Beer>();
        }
        #endregion

    }
}





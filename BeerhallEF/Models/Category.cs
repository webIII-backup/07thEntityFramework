using System.Collections.Generic;
using System.Linq;

namespace BeerhallEF.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<CategoryBrewer> CategoryBrewers { get; private set; }

        public IEnumerable<Brewer> Brewers => CategoryBrewers.Select(b => b.Brewer);

        protected Category()
        {
            CategoryBrewers = new HashSet<CategoryBrewer>();
        }

        public Category(string name) : this()
        {
            Name = name;
        }

        public void Add(Brewer b)
        {
            CategoryBrewers.Add(new CategoryBrewer(this, b));
        }


    }
}

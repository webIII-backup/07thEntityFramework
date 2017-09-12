namespace BeerhallEF.Models
{
    public class CategoryBrewer
    {
        public int BrewerId { get; set; }
        public Brewer  Brewer { get; set; }

        public int  CategoryId { get; set; }
        public Category Category { get; set; }

        protected CategoryBrewer()
        {
            
        }

        public CategoryBrewer(Category category, Brewer brewer) : this()
        {
            Category = category;
            CategoryId = Category.CategoryId;

            Brewer = brewer;
            BrewerId = Brewer.BrewerId;
        }
    }
}

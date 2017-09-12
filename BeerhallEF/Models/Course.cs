namespace BeerhallEF.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int? Credits { get; set; }
        public Language Language { get; set; }
        public Brewer Brewer { get; set; }

        protected Course()
        {
        }

        public Course(string title, Language language, Brewer brewer) : this()
        {
            Title = title;
            Language = language;
            Brewer = brewer;
        }
    }
}

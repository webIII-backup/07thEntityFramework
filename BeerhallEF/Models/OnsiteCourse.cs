using System;

namespace BeerhallEF.Models
{
    public class OnsiteCourse : Course
    {

        #region Properties
        private DateTime _startDate;

        public int NumberOfDays { get; set; }

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (value <= DateTime.Today)
                    throw new ArgumentException("Startdate must be in the future");
                _startDate = value;
            }
        }

        public TimeSpan? From { get; set; }
        public TimeSpan? Till { get; set; }
        #endregion

        #region Methods
        protected OnsiteCourse()
        {
        }

        public OnsiteCourse(string title, Language language, Brewer brewer, int numberOfDays, DateTime startDate) : this()
        {
            Title = title;
            Language = language;
            Brewer = brewer;
            NumberOfDays = numberOfDays;
            StartDate = startDate;
        } 
        #endregion
    }
}

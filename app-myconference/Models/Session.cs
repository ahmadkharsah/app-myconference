﻿namespace app_myconference.Models
{
    public partial class Session:ObservableObject
    {
        //static
        public int Id { get; set; }
        public string Title { get; set; }
        public string Room { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string StartTimeDisplay => $"{Start:t}";
        public string DayDisplay => $"{Start:MMM} {Start:d}";
        public Speaker Speaker { get; set; } = new Speaker()
        {
            Name = "Ahmad Kharsah",
            Title = "CEO",
            Company = "NourNet",
            Description = "some text here"
        };

        //Dynamic
        [ObservableProperty]
        bool inAgenda;
    }
}

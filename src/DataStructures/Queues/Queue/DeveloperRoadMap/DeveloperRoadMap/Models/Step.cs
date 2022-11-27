using System;
namespace DeveloperRoadMap.Models
{
    public class Step
    {
        public Step()
        {
        }
        public Step(string description)
        {
            Description = description;
        }
        public int Id { get; set; }
        public string Description { get; set; }
    }
}


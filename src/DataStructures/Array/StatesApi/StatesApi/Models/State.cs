using System;
namespace StatesApi.Models
{
    /// <summary>
    /// State Enumeration Listed in Order of Admission
    /// Link For Technique Details: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types
    /// https://en.wikipedia.org/wiki/List_of_U.S._state_and_territory_abbreviations
    /// https://en.wikipedia.org/wiki/List_of_U.S._states_by_date_of_admission_to_the_Union
    /// </summary>
    public record State: Enumeration
    {
        public State(int id, string name, string description) : base(id, name, description)
        {

        }
        public static State Delware = new(id: 1, name: "DL", description: nameof(Delware));
        public static State Pennsylvania = new(id: 2, name: "PA", description: nameof(Pennsylvania));
        public static State NewJersey = new(id: 3, name:"NJ", description: nameof(NewJersey));
        public static State Georgia = new (id: 4, name: "GA", description: nameof(Georgia));
        public static State Connecticut = new(id: 5, name: "CT", description: nameof(Connecticut));
        public static State Massachusetts = new(id: 6, name: "MA", description: nameof(Massachusetts));
        public static State Maryland = new (id: 7, name: "MD", description: nameof(Maryland));
        public static State Michigan = new (id: 26, name: "MI", description:nameof(Michigan));


        /// <summary>
        /// This is a great use case for an array because all of the states will be static they won't be dynamic and its extremely unlikely that they will go beyond 50 values
        /// They can also be indexed in the order the where admitted into the Country
        /// </summary>
        /// <returns></returns>
        public static State[] GetAll()
        {
            return new State[]
            {
                Delware,
                Pennsylvania,
                NewJersey,
                Georgia,
                Connecticut,
                Massachusetts,
                Maryland,
                Michigan,
            };
        }
    }
}


using System;
namespace StatesApi.Models
{
    public class GetStatesQuery
    {
        public IEnumerable<State> GetStates(string name)
        {
            return State.GetAll()
                .Where(state =>
                string.Equals(state.Name, name, StringComparison.OrdinalIgnoreCase )
                || state.Description.Contains(name));
        }
    }
}


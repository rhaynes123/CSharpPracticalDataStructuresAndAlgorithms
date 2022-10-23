using System;
namespace PowerLevelScouter.Models
{
    public record Character(int Id, string Name, int PowerLevel) : IComparable<Character>
    {
        /// <summary>
        /// Compares power level and intends to do so in a descending order.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Character? other)
        {
            if (other is null || other == default)
            {
                return -1;
            }
            if(PowerLevel == other.PowerLevel)
            {
                return 0;
            }
            if(PowerLevel > other.PowerLevel)
            {
                return -1;
            }
            if (PowerLevel < other.PowerLevel)
            {
                return 1;
            }
            return -1;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}


using System.Linq;

namespace AoC2021.Day6
{
    internal class Solution
    {
        private readonly List<long> _days;
        public Solution()
        {
            var temp = Helper.ReadFile("Day6")
                             .Split(",")
                             .Select(x => int.Parse(x));

            _days = new List<long>();

            for(var i = 0; i <= 8; i++)
                _days.Add((long)temp.Count(x => x == i));
        }
        public long PartOne()
        {
            for(var i = 0; i < 80; i++)
            {
                _days[7] += _days[0];
                _days.Add(_days[0]);
                _days.RemoveAt(0);
            }

            return _days.Sum();
        }

        public long PartTwo()
        {
            for (var i = 0; i < 256; i++)
            {
                _days[7] += _days[0];
                _days.Add(_days[0]);
                _days.RemoveAt(0);
            }

            return _days.Sum();
        }
    }
}

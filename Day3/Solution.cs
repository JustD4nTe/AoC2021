namespace AoC2021.Day3
{
    internal class Solution
    {
        private readonly List<List<bool>> input;

        public Solution()
        {
            input = Helper.ReadFile("Day3")
                          .Split("\n")
                          .Select(x => x.ToCharArray())
                          .Select(x => x.Select(y => y == '1').ToList())
                          .ToList();
        }

        public int PartOne()
        {
            var gammaRate = "";
            var epsilonRate = "";

            for (var i = 0; i < input[0].Count; i++)
            {
                if (input.Where(x => x[i]).Count() > (input.Count / 2))
                {
                    gammaRate += "1";
                    epsilonRate += "0";
                }
                else
                {
                    gammaRate += "0";
                    epsilonRate += "1";
                }
            }

            return Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);
        }

        public int PartTwo()
        {
            var oxygenCopy = input.Select(x => x.ToList()).ToList();
            var co2Copy = input.Select(x => x.ToList()).ToList();

            for (var i = 0; i < input[0].Count; i++)
            {
                var trueCountOxygen = oxygenCopy.Where(x => x[i]).Count();
                var trueCountCo2 = co2Copy.Where(x => x[i]).Count();

                if (oxygenCopy.Count > 1)
                {
                    if (trueCountOxygen >= oxygenCopy.Count / 2.0)
                        oxygenCopy.RemoveAll(x => !x[i]);
                    else
                        oxygenCopy.RemoveAll(x => x[i]);
                }

                if (co2Copy.Count > 1)
                {
                    if (trueCountCo2 >= co2Copy.Count / 2.0)
                        co2Copy.RemoveAll(x => x[i]);
                    else
                        co2Copy.RemoveAll(x => !x[i]);
                }
            }

            var oxygen = Convert.ToInt32(string.Join("", oxygenCopy[0].Select(x => x ? "1" : "0")), 2);
            var co2 = Convert.ToInt32(string.Join("", co2Copy[0].Select(x => x ? "1" : "0")), 2);

             return oxygen * co2;
        }
    }
}

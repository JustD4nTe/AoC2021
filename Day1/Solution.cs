namespace AoC2021.Day1
{
    internal class Solution
    {
        private readonly List<int> input;
        private readonly Dictionary<bool, int> depthMesurement;

        private readonly bool INCREASED;
        private readonly bool DECREASED;

        public Solution()
        {
            input = Helper.ReadFile("Day1")
                    .Split("\n")
                    .Select(x => Convert.ToInt32(x))
                    .ToList();

            INCREASED = true;
            DECREASED = false;

            depthMesurement = new Dictionary<bool, int>
            {
                [INCREASED] = 0,
                [DECREASED] = 0
            };
        }

        public int PartOne()
        {
            for (var i = 0; i < input.Count - 1; i++)
                depthMesurement[input[i] < input[i + 1]]++;

            return depthMesurement[INCREASED];
        }

        public int PartTwo()
        {
            for (var i = 0; i < input.Count - 3; i++)
            {
                var a = input[i] + input[i + 1] + input[i + 2];
                var b = input[i + 1] + input[i + 2] + input[i + 3];

                depthMesurement[a < b]++;
            }

            return depthMesurement[INCREASED];
        }
    }
}

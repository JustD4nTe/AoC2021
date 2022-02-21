namespace AoC2021.Day7
{
    internal class Solution
    {
        private readonly List<int> crabPos;
        public Solution()
        {
            crabPos = Helper.ReadFile("Day7")
                            .Split(",")
                            .Select(x => int.Parse(x))
                            .ToList();
        }
        public long PartOne()
        {
            var buff = new List<int>();

            for(var i = 1; i <= crabPos.Max(); i++)
                buff.Add(crabPos.Aggregate(0, (a, x) => a + Math.Abs(x - i)));

            return buff.Min();
        }

        public long PartTwo()
        {
            var buff = new List<int>();

            for (var i = 1; i <= crabPos.Max(); i++)
                buff.Add(crabPos.Aggregate(0, (a, x) => a + Foo(Math.Abs(x - i))));

            return buff.Min();
        }

        private int Foo(int a)
        {
            var buff = 0;

            for (var i = 0; i < a; i++)
                buff += a - i;

            return buff;
        }
    }
}

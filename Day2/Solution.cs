namespace AoC2021.Day2
{
    internal class Solution
    {
        private record Command(string Instruction, int Value);
        private readonly List<Command> input;

        public Solution()
        {
            input = Helper.ReadFile("Day2")
                          .Split("\n")
                          .Select(x => x.Split(" "))
                          .Select(x => new Command(x[0], int.Parse(x[1])))
                          .ToList();

        }

        public int PartOne()
        {
            var hPos = 0;
            var depth = 0;

            for(var i = 0; i < input.Count; i++)
            {
                switch (input[i].Instruction)
                {
                    case "forward":
                        hPos += input[i].Value;
                        break;
                    case "down":
                        depth += input[i].Value;
                        break;
                    case "up":
                        depth -= input[i].Value;
                        break;
                }
            }

            return hPos * depth;
        }

        public int PartTwo()
        {
            var hPos = 0;
            var depth = 0;
            var aim = 0;

            for (var i = 0; i < input.Count; i++)
            {
                switch (input[i].Instruction)
                {
                    case "forward":
                        hPos += input[i].Value;
                        depth += aim * input[i].Value;
                        break;
                    case "down":
                        aim += input[i].Value;
                        break;
                    case "up":
                        aim -= input[i].Value;
                        break;
                }
            }
            return hPos * depth;
        }
    }
}

namespace AoC2021.Day5
{
    internal class Solution
    {
        record Point(int X, int Y);
        record Line(Point Start, Point End);

        private readonly List<Line> _input;
        private readonly int[][] _map;

        public Solution()
        {
            var temp = Helper.ReadFile("Day5")
                          .Split("\n")
                          .Select(x => x.Split("->"))
                          .ToList();

            _input = new List<Line>();

            var maxCoord = 0;

            foreach (var line in temp)
            {
                var rawStart = line[0].Split(",").Select(x => int.Parse(x)).ToList();
                var rawEnd = line[1].Split(",").Select(x => int.Parse(x)).ToList();

                var foo = new List<int>() { maxCoord };
                foo.AddRange(rawStart);
                foo.AddRange(rawEnd);

                maxCoord = foo.Max();

                var start = new Point(rawStart[0], rawStart[1]);
                var end = new Point(rawEnd[0], rawEnd[1]);

                _input.Add(new Line(start, end));
            }

            _map = new int[maxCoord + 1][];

            for (var i = 0; i < maxCoord + 1; i++)
                _map[i] = new int[maxCoord + 1];
        }
        public int PartOne()
        {
            foreach (var (start, end) in _input)
            {
                if (start.X == end.X)
                    Horizontal(start, end);
                else if (start.Y == end.Y)
                    Vertical(start, end);
            }

            return _map.Sum(x => x.Count(x => x >= 2));
        }

        public int PartTwo()
        {
            foreach (var (start, end) in _input)
            {
                if (start.X == end.X)
                {
                    Horizontal(start, end);
                }
                else if (start.Y == end.Y)
                {
                    Vertical(start, end);
                }
                else if (start.X == start.Y && end.X == end.Y)
                {
                    // 1,1 -> 3,3
                    if (start.X < end.X)
                        SymetricDiagonal(start, end);
                    // 3,3 -> 1,1
                    else
                        SymetricDiagonal(end, start);
                }
                // 9,7 -> 7,9
                else if (start.X > end.X && start.Y < end.Y)
                {
                    CrazyDiagonal(start, end);
                }
                // 7,9 -> 9,7
                else if (start.X < end.X && start.Y > end.Y)
                {
                    CrazyDiagonal(end, start);
                }
                // 5,6 -> 12,13
                else if (start.X < end.X && start.Y < end.Y)
                {
                    Diagonal(start, end);
                }
                // 12,13 -> 5,6
                else
                {
                    Diagonal(end, start);
                }
            }

            for (var j = 0; j < 10; j++)
                Console.WriteLine(string.Join(" ", _map[j]));

            return _map.Sum(x => x.Count(x => x > 1));
        }

        private void Horizontal(Point start, Point end)
        {
            int startY, endY;
            var x = start.X;

            if (start.Y > end.Y)
            {
                startY = end.Y;
                endY = start.Y;
            }
            else
            {
                startY = start.Y;
                endY = end.Y;
            }

            for (var y = startY; y <= endY; y++)
                _map[y][x]++;
        }

        private void Vertical(Point start, Point end)
        {
            int startX, endX;

            if (start.X > end.X)
            {
                startX = end.X;
                endX = start.X;
            }
            else
            {
                startX = start.X;
                endX = end.X;
            }

            var y = start.Y;

            for (var x = startX; x <= endX; x++)
                _map[y][x]++;
        }

        private void SymetricDiagonal(Point start, Point end)
        {
            for (var i = start.X; i <= end.X; i++)
                _map[i][i]++;
        }

        private void CrazyDiagonal(Point start, Point end)
        {
            for (int x = start.X, y = start.Y; x >= end.X || y <= end.Y; x--, y++)
                _map[y][x]++;
        }

        private void Diagonal(Point start, Point end)
        {
            for (int x = start.X, y = start.Y; x <= end.X || y <= end.Y; x++, y++)
                _map[y][x]++;
        }
    }
}
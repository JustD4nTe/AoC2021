using System.Text.RegularExpressions;

namespace AoC2021.Day4
{
    internal class Solution
    {
        private readonly List<int> drawNumbers;
        private readonly List<List<List<int>>> boards;
        private const int BOARD_SIZE = 5;

        public Solution()
        {

            var temp = Helper.ReadFile("Day4")
                             .Replace("\n\n", "\n")
                             .Split("\n")
                             .Select(x => Regex.Replace(x, @"\s+", " "))
                             .Select(x => x.Trim())
                             .ToList();

            drawNumbers = temp[0].Split(",")
                                 .Select(int.Parse)
                                 .ToList();

            boards = new List<List<List<int>>>();

            for (var i = 1; i < temp.Count; i += BOARD_SIZE)
            {
                var board = new List<List<int>>();

                for (var j = 0; j < BOARD_SIZE; j++)
                    board.Add(temp[i + j].Split(" ").Select(int.Parse).ToList());

                boards.Add(board);
            }
        }

        public int PartOne()
        {
            for (var i = 0; i < drawNumbers.Count; i++)
            {
                for (var j = 0; j < boards.Count; j++)
                    MarkNumber(boards[j], drawNumbers[i]);

                for (var j = 0; j < boards.Count; j++)
                {
                    if (IsWinner(boards[j]))
                    {
                        var sumOfUnmarkedNumbers = boards[j].SelectMany(x => x)
                                                            .Where(x => x != -1)
                                                            .Sum();

                        return sumOfUnmarkedNumbers * drawNumbers[i];
                    }
                }
            }

            return -1;
        }

        public int PartTwo()
        {
            for (var i = 0; i < drawNumbers.Count; i++)
            {
                for (var j = 0; j < boards.Count; j++)
                    MarkNumber(boards[j], drawNumbers[i]);

                for (var j = 0; j < boards.Count; j++)
                {
                    if (IsWinner(boards[j]))
                    {
                        // when only one board didn't win
                        if (boards.Count == 1)
                        {
                            var sumOfUnmarkedNumbers = boards[j].SelectMany(x => x)
                                                                .Where(x => x != -1)
                                                                .Sum();

                            return sumOfUnmarkedNumbers * drawNumbers[i];
                        }

                        boards.RemoveAt(j);
                        continue;
                    }
                }
            }

            return -1;
        }

        private static void MarkNumber(List<List<int>> board, int number)
        {
            for (var i = 0; i < board.Count; i++)
            {
                for (var j = 0; j < board[i].Count; j++)
                {
                    if (board[i][j] == number)
                    {
                        board[i][j] = -1;
                        return;
                    }
                }
            }
        }

        private static bool IsWinner(List<List<int>> board)
        {
            for (var i = 0; i < BOARD_SIZE; i++)
            {
                // - 
                if (board[i].All(x => x == -1))
                    return true;

                // |
                if (board.Select(x => x[i]).All(x => x == -1))
                    return true;
            }

            return false;
        }
    }
}

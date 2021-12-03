namespace AoC2021
{
    public static class Helper
    {
        public static string ReadFile(string path)
        {
            using var sr = new StreamReader($"../../../{path}/input.txt");
            return sr.ReadToEnd();
        }
    }
}

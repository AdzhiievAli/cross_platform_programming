using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LabLibrary
{
    public static class LabRunner
    {
        public static void RunLab1(string inputFilePath, string outputFilePath)
        {
            try
            {
                var input = File.ReadAllLines(inputFilePath);
                int n = int.Parse(input[0]);
                int[] animals = input[1].Split(' ').Select(int.Parse).ToArray();

                long combinations = CalculateCombinations(n, animals);
                File.WriteAllText(outputFilePath, combinations.ToString());
            }
            catch (Exception ex)
            {
                File.WriteAllText(outputFilePath, $"Error: {ex.Message}");
            }
        }

        private static long CalculateCombinations(int n, int[] animals)
        {
            long combinations = 0;
            for (int i = 0; i < n - 2; i++)
            {
                for (int j = i + 1; j < n - 1; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        combinations += (long)animals[i] * animals[j] * animals[k];
                    }
                }
            }
            return combinations;
        }

        public static void RunLab2(string inputFilePath, string outputFilePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(inputFilePath);
                int n = int.Parse(lines[0]);
                int[] data = lines[1].Split().Select(int.Parse).ToArray();

                CheckLimit(data);
                int maxPosl = Maxposl(data);
                File.WriteAllText(outputFilePath, maxPosl.ToString());
            }
            catch (Exception ex)
            {
                File.WriteAllText(outputFilePath, $"Error: {ex.Message}");
            }
        }

        private static void CheckLimit(int[] data)
        {
            if (data.Any(x => Math.Abs(x) > 10000))
            {
                throw new ArgumentOutOfRangeException("data", "error data > 10000");
            }
        }

        private static int Maxposl(int[] data)
        {
            int maxPosl = 1;
            int posl = 1;

            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] >= data[i - 1])
                {
                    posl++;
                    if (posl > maxPosl)
                    {
                        maxPosl = posl;
                    }
                }
                else
                {
                    posl = 1;
                }
            }
            return maxPosl;
        }

        public static void RunLab3(string inputFilePath, string outputFilePath)
        {
            try
            {
                var input = File.ReadAllLines(inputFilePath);
                var firstLine = input[0].Split();
                int n = int.Parse(firstLine[0]);
                int m = int.Parse(firstLine[1]);

                if (!WrongN(n) || !WrongM(m))
                {
                    File.WriteAllText(outputFilePath, "error with data");
                    return;
                }

                var pairs = new List<(int, int)>();
                for (int i = 1; i <= m; i++)
                {
                    var line = input[i].Split();
                    int u = int.Parse(line[0]);
                    int v = int.Parse(line[1]);
                    pairs.Add((u, v));
                }

                var result = CheckTable(n, pairs) ? "YES" : "NO";
                File.WriteAllText(outputFilePath, result);
            }
            catch (Exception ex)
            {
                File.WriteAllText(outputFilePath, $"Error: {ex.Message}");
            }
        }
        private static bool WrongN(int n)
        {
            return n > 0;
        }
        private static bool WrongM(int m)
        {
            return m < 100;
        }

        private static bool CheckTable(int n, List<(int, int)> pairs)
        {
            var color = new Dictionary<int, int>();

            foreach (var (u, v) in pairs)
            {
                if (!color.ContainsKey(u) && !color.ContainsKey(v))
                {
                    color[u] = 1;
                    color[v] = 2;
                }
                else if (!color.ContainsKey(u))
                {
                    color[u] = 3 - color[v];
                }
                else if (!color.ContainsKey(v))
                {
                    color[v] = 3 - color[u];
                }
                else if (color[u] == color[v])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

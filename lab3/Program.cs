using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;

public class Program
{
    static void Main()
    {
        try
        {
            string inputFilePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\data\INPUT.TXT"));
            var input = File.ReadAllLines(inputFilePath);
            var firstLine = input[0].Split();
            int n = int.Parse(firstLine[0]);
            int m = int.Parse(firstLine[1]);

            if (!WrongN(n))
            {
                Console.WriteLine("error with data");
            }

            if (!WrongM(m))
            {
                Console.WriteLine("error with data");
            }

            var pairs = new List<(int, int)>();
            for (int i = 1; i <= m; i++)
            {
                var line = input[i].Split();
                int u = int.Parse(line[0]);
                int v = int.Parse(line[1]);
                pairs.Add((u, v));
            }
            string outputFilePath = Path.Combine(AppContext.BaseDirectory, @"..\..\..\data\OUTPUT.TXT");
            var result = CheckTable(n, pairs) ? "YES" : "NO";
            File.WriteAllText(outputFilePath, result);
        }
        catch (Exception)
        {
            Console.WriteLine("error with data n or m ");
        }
    }
    public static bool CheckTable(int n, List<(int, int)> pairs)
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

    public static bool WrongN(int n)
    {
        if (0>=n)
        {   
            return false;
        }
        return true;
    }
    public static bool WrongM(int m)
    {
        if (m >= 100)
        {
            return false;
        }
        return true;
    }


}
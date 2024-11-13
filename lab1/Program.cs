using System;
using System.IO;
using System.Linq;

public class ZooExhibition
{
    public static long CalculateCombinations(int n, int[] animals)
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

    public static void Main()
    {

        string inputFilePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\data\INPUT.TXT"));


        var input = File.ReadAllLines(inputFilePath);

        int n = int.Parse(input[0]);
        int[] animals = input[1].Split(' ').Select(int.Parse).ToArray();

        long combinations = CalculateCombinations(n, animals);


        string outputFilePath = Path.Combine(AppContext.BaseDirectory, @"..\..\..\data\OUTPUT.TXT");
        File.WriteAllText(outputFilePath, combinations.ToString());
    }
}
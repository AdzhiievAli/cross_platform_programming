using System;
using System.IO;
using System.Linq;

namespace Lab1
{
    class Program
    {
        public static long CalculateCombinations(int[] animals)
        {
            int n = animals.Length;
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

        static void Main()
        {
            var input = File.ReadAllLines("INPUT.TXT");
            int n = int.Parse(input[0]);
            int[] animals = input[1].Split(' ').Select(int.Parse).ToArray();

            long combinations = CalculateCombinations(animals);

            File.WriteAllText("OUTPUT.TXT", combinations.ToString());
        }
    }
}

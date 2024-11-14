using System;
using System.IO;
using System.Linq;

public class Poslmax
{
    static void Main()
    {
        try
        {
            string inputFilePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\data\INPUT.TXT"));
            string[] lines = File.ReadAllLines(inputFilePath);
            int n = int.Parse(lines[0]);
            int[] data = lines[1].Split().Select(int.Parse).ToArray();
            CheckLimit(data);
            int maxPosl = Maxposl(data);
            string outptPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\data\OUTPUT.TXT"));
            File.WriteAllText(outptPath, maxPosl.ToString());
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public static void CheckLimit(int[] data)
    {
        if (data.Any(x => Math.Abs(x) > 10000))
        {
            throw new ArgumentOutOfRangeException("data", "error data > 10000");
        }
    }
    public static int Maxposl(int[] data)
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
}

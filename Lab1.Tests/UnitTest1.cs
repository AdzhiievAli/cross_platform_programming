using System;
using System.IO;
using Xunit;
using Lab1;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Lab1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestCombinationsCalculation()
        {
            var animals = new int[] { 2, 1, 1, 1 };
            long result = Program.CalculateCombinations(animals);
            var expected = 7;

            Assert.Equal(expected, result);
        }


        [Fact]
        public void TestProgramWithFileInput()
        {
            var input = "4\n2 1 1 1\n";  
            var inputFilePath = Path.Combine("Data", "INPUT.TXT");
            var outputFilePath = Path.Combine("Data", "OUTPUT.TXT");
            Directory.CreateDirectory("Data");
            File.WriteAllText(inputFilePath, input);
            Program.Main();
            var result = File.ReadAllText(outputFilePath);

            var expected = "7";  

            Assert.Equal(expected, result);
            File.Delete(inputFilePath);
            File.Delete(outputFilePath);
        }
    }
}

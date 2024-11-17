using NUnit.Framework;

[TestFixture]
public class Pars
{
        [TestCase(3, 2, new int[] { 1, 2, 1, 3 }, ExpectedResult = true)]
        [TestCase(3, 3, new int[] { 1, 2, 1, 3, 2 ,3}, ExpectedResult = false)]
        [TestCase(5, 2, new int[] { 2, 1 , 1 ,2 }, ExpectedResult = true)]
        [TestCase(5, 3, new int[] { 1, 2, 2, 3, 3, 5 }, ExpectedResult = true)]
        [TestCase(4, 4, new int[] { 1, 2, 1, 3, 1, 4 , 3 ,4 }, ExpectedResult = false)]
        [TestCase(2, 1, new int[] { 1,2 }, ExpectedResult = true)]
        public bool TableFCheck(int n, int m, int[] pairData)
        {
            var pairs = new List<(int, int)>();
            for (int i = 0; i < m * 2; i += 2)
            {
                pairs.Add((pairData[i], pairData[i + 1]));
            }
            return Program.CheckTable(n, pairs);
        }

        [Test]
        public void NError()
        {
            int n = -1;
            bool result = Program.WrongN(n);
            Assert.IsFalse(result);
        }

        [Test]
        public void NCorrect()
        {
            int n = 10;
            bool result = Program.WrongN(n);
            Assert.IsTrue(result);
        }    

         [Test]
        public void MError()
        {
            int m = 101;
            bool result = Program.WrongM(m);
            Assert.IsFalse(result);
        }

        [Test]
        public void MCorrect()
        {
            int m = 17;
            bool result = Program.WrongM(m);
            Assert.IsTrue(result);
        }        

        
    }
    

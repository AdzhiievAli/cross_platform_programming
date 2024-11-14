using NUnit.Framework;

public class PoslTests
{

    [TestCase(new int[] { 1, 2, 3, 4, 5 }, 5)]  
    [TestCase(new int[] { 7, 8, 9, 1, 1 }, 3)]  
    [TestCase(new int[] { 167, 184, 1957, 87, 14 }, 3)]  
    [TestCase(new int[] { 9000, 9002, 9005, 28, 111 , 115 , 414, 787, 5364,6000,7000 }, 8)] 
    [TestCase(new int[] { 1, 2}, 2)] 
    public void TestMaxpos_par(int[] data, int expectedMaxPosl)
    {
        int result = Poslmax.Maxposl(data);
        Assert.AreEqual(expectedMaxPosl, result); 
    }


    [TestCase(new int[] { 2, 67000, 22, 5, 3 })]
    [TestCase(new int[] { 9999, 10001, })]
    [TestCase(new int[] { -10011, 1, 8, 1 })]
    [TestCase(new int[] { -1000000})]
    [TestCase(new int[] { 10005,-10005 })]
    [TestCase(new int[] { 1010101010 })]
    public void TestError(int[] data)
    {
    var ex = Assert.Throws<ArgumentOutOfRangeException>(() => Poslmax.CheckLimit(data));
    Assert.That(ex.Message, Is.EqualTo("error data > 10000 (Parameter 'data')"));
    }

}


using NUnit.Framework;

[TestFixture]
public class ZooExhibitionTests
{
    [Test]
    public void calc1()
    {
        int n = 4;
        int[] animals = new int[] { 2, 1, 1, 1 };
        long result = ZooExhibition.CalculateCombinations(n, animals);
        Assert.AreEqual(7, result);
    }

    [Test]
    public void calc2()
    {
        int n = 3;
        int[] animals = new int[] { 2, 2, 1, 1 };
        long result = ZooExhibition.CalculateCombinations(n, animals);
        Assert.AreEqual(4, result);
    }

    [Test]
    public void calc3()
    {
        int n = 3;
        int[] animals = new int[] { 2, 2, 2, 1 };
        long result = ZooExhibition.CalculateCombinations(n, animals);
        Assert.AreEqual(8, result);
    }

    [Test]
    public void calc4()
    {
        int n = 3;
        int[] animals = new int[] { 3, 2, 2, 2 };
        long result = ZooExhibition.CalculateCombinations(n, animals);
        Assert.AreEqual(12, result);
    }

    [Test]
    public void calc5()
    {
        int n = 3;
        int[] animals = new int[] { 4, 4, 2, 2 };
        long result = ZooExhibition.CalculateCombinations(n, animals);
        Assert.AreEqual(32, result);
    }

    [Test]
     public void calc6()
    {
        int n = 3;
        int[] animals = new int[] { 4, 4, 4, 4 };
        long result = ZooExhibition.CalculateCombinations(n, animals);
        Assert.AreEqual(64, result);
    }  

    [Test]
     public void calc7()
    {
        int n = 3;
        int[] animals = new int[] { 7, 5, 5, 5 };
        long result = ZooExhibition.CalculateCombinations(n, animals);
        Assert.AreEqual(175, result);
    }  

    [Test]
     public void calc8()
    {
        int n = 3;
        int[] animals = new int[] { 7, 7, 8, 8 };
        long result = ZooExhibition.CalculateCombinations(n, animals);
        Assert.AreEqual(392, result);
    }  

    [Test]
    public void comb_for_test()
    {
        int n = 3;
        int[] animals = new int[] { 100, 100, 100 };

       
        long result = ZooExhibition.CalculateCombinations(n, animals);

        
        Assert.AreEqual(1000000, result);  
    }

    [Test]
    public void comb_for_test2()
    {
       
        int n = 3;
        int[] animals = new int[] { 20, 20 , 20 , 20 };

        
        long result = ZooExhibition.CalculateCombinations(n, animals);

        
        Assert.AreEqual(8000, result); 
    }



}
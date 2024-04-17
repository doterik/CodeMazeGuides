#pragma warning disable IDE1006 // Naming Styles.

namespace CheckNumberInStringTests;

[TestClass]
public class ExtractNumberTests
{
    private readonly string inputString1 = "Hmm.. #567-321 Revenue for last 2 years is 101.45 and $105.85, that's it.";
    private readonly string expectedNumber1 = "2;101.45;105.85";

    private readonly string inputString2 = "Hmm.. #567-321 Revenue for last 2 years is 101.45 and $-105.85, that's it.";
    private readonly string expectedNumber2 = "2;101.45;-105.85";

    private readonly string inputString3 = "This has no numbers.";
    private readonly string expectedNumber3 = string.Empty;

    //----------------- RegEx Source Generators Method -----------------
    [TestMethod]
    public void GivenStringWithNumbers_WhenUsingRegExMethod_ThenReturnResultAreEqual()
    {
        var actualNumber = ExtractNumber.ExtractNumberUsingRegEx(inputString1);
        Assert.AreEqual(expectedNumber1, actualNumber);
    }

    [TestMethod]
    public void GivenStringWithNegativeNumbers_WhenUsingRegExMethod_ThenReturnResultAreEqual()
    {
        var actualNumber = ExtractNumber.ExtractNumberUsingRegEx(inputString2);
        Assert.AreEqual(expectedNumber2, actualNumber);
    }

    [TestMethod]
    public void GivenStringWithoutNumbers_WhenUsingRegExMethod_ThenReturnResultAreEqual()
    {
        var actualNumber = ExtractNumber.ExtractNumberUsingRegEx(inputString3);
        Assert.AreEqual(expectedNumber3, actualNumber);
    }

    //----------------- Linq Method -----------------
    [TestMethod]
    public void GivenStringWithNumbers_WhenUsingLinqMethod_ThenReturnResultAreEqual()
    {
        var actualNumber = ExtractNumber.ExtractNumbersUsingLinq(inputString1);
        Assert.AreEqual(expectedNumber1, actualNumber);
    }

    [TestMethod]
    public void GivenStringWithNegativeNumbers_WhenUsingLinqMethod_ThenReturnResultAreEqual()
    {
        var actualNumber = ExtractNumber.ExtractNumbersUsingLinq(inputString2);
        Assert.AreEqual(expectedNumber2, actualNumber);
    }

    [TestMethod]
    public void GivenStringWithoutNumbers_WhenUsingLinqMethod_ThenReturnResultAreEqual()
    {
        var actualNumber = ExtractNumber.ExtractNumbersUsingLinq(inputString3);
        Assert.AreEqual(expectedNumber3, actualNumber);
    }

    //----------------- StringBuilder Method -----------------
    [TestMethod]
    public void GivenStringWithNumbers_WhenUsingStringBuilderAndCharIsDigitMethod_ThenReturnResultAreEqual()
    {
        var actualNumber = ExtractNumber.ExtractNumberUsingStringBuilder(inputString1);
        Assert.AreEqual(expectedNumber1, actualNumber);
    }

    [TestMethod]
    public void GivenStringWithNegativeNumbers_WhenUsingStringBuilderAndCharIsDigitMethod_ThenReturnResultAreEqual()
    {
        var actualNumber = ExtractNumber.ExtractNumberUsingStringBuilder(inputString2);
        Assert.AreEqual(expectedNumber2, actualNumber);
    }

    [TestMethod]
    public void GivenStringWithoutNumbers_WhenUsingStringBuilderAndCharIsDigitMethod_ThenReturnResultAreEqual()
    {
        var actualNumber = ExtractNumber.ExtractNumberUsingStringBuilder(inputString3);
        Assert.AreEqual(expectedNumber3, actualNumber);
    }

    //----------------- Span Method -----------------
    [TestMethod]
    public void GivenStringWithNumbers_WhenUsingSpanMethod_ThenReturnResultAreEqual()
    {
        var actualNumber = ExtractNumber.ExtractNumberUsingSpan(inputString1);
        Assert.AreEqual(expectedNumber1, actualNumber);
    }

    [TestMethod]
    public void GivenStringWithNegativeNumbers_WhenUsingSpanMethod_ThenReturnResultAreEqual()
    {
        var actualNumber = ExtractNumber.ExtractNumberUsingSpan(inputString2);
        Assert.AreEqual(expectedNumber2, actualNumber);
    }

    [TestMethod]
    public void GivenStringWithoutNumbers_WhenUsingSpanMethod_ThenReturnResultAreEqual()
    {
        var actualNumber = ExtractNumber.ExtractNumberUsingSpan(inputString3);
        Assert.AreEqual(expectedNumber3, actualNumber);
    }
}

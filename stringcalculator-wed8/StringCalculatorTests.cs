
namespace StringCalculator;

public class StringCalculatorTests
{
    StringCalculator _calculator = new StringCalculator();
    [Fact]
    public void EmptyStringReturnsZero()
    {

        var result = _calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("4",4)]
    [InlineData("5",5)]
    [InlineData("1242",1242)]
    public void SingleDigits(string numbers, int expected)
    {

        var result = _calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("4,5", 9)]
    [InlineData("12,340", 352)]
    public void TwoDigits(string numbers, int expected)
    {

        var result = _calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    /*
    [Theory]
    [InlineData("4,5, 45,60", 114)]
    [InlineData("12,340, 1", 353)]
    public void MultipleDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }
    */

    [Theory]
    [InlineData("1\n2",3)]
    [InlineData("1\n10", 11)]
    [InlineData("99\n5", 104)]
    public void NewLineSplitters(string numbers, int expected)
    {

        var result = _calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    /*
    [Fact]
    public void DifferentDelimitters()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("//;\n1;2");

        Assert.Equal(3, result);
    }
    */
}

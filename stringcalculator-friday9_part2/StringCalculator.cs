
namespace StringCalculator;

public class StringCalculator
{
    private readonly ILogger _logger;

    public StringCalculator(ILogger logger)
    {
        _logger = logger;
    }

    public int Add(string numbers)
    {
        //Fewer number of "elements", low "cyclomatic complexity"
        int total =  numbers == "" ? 0 : numbers.Split(',', '\n') // ["1", "2"]
            .Select(int.Parse) // [1,2]
            .Sum();

        //Write the code you wished you had
        _logger.Write(total.ToString());

        return total;
    }

}

public interface ILogger
{
    void Write(string message);
}

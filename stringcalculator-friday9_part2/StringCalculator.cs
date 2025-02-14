﻿
namespace StringCalculator;

public class StringCalculator
{
    private readonly ILogger _logger;
    private readonly IWebService _webService;

    public StringCalculator(ILogger logger, IWebService webService)
    {
        _logger = logger;
        _webService = webService;
    }


    public int Add(string numbers)
    {
        //Fewer number of "elements", low "cyclomatic complexity"
        int total =  numbers == "" ? 0 : numbers.Split(',', '\n') // ["1", "2"]
            .Select(int.Parse) // [1,2]
            .Sum();

        //Write the code you wished you had
        try
        {
            _logger.Write(total.ToString());
        }
        catch (LoggingException ex)
        {

            // Write the code you wish you had
            _webService.LoggingFailed(ex.Message);
        }

        return total;
    }

}

public interface ILogger
{
    void Write(string message);
}

public interface IWebService
{
    void LoggingFailed(string failureMessage);
}

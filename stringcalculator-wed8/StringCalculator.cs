
using System.ComponentModel;

namespace StringCalculator;

public class StringCalculator
{

    //What was done as a group up to #4
    /*
    public int Add(string numbers)
    {
        if (numbers == "") return 0;
        var delimiter = ",";
        if (numbers.StartsWith("//")) 
        {
            delimiter = numbers[2].ToString();
            numbers = numbers.Substring(4);
        } 
        var sum = 0;
        numbers = numbers.Replace("\n", ",");
        var numberList = numbers.Split(',');
        foreach(var number in numberList)
        {
            sum += int.Parse(number);
        }
        return sum;
    }
    */

    // Instructor's example
    public int Add(string numbers)
    {
        if (numbers == "") { return 0; }
        var allowedDelimeters = new List<char> { ',', '\n', '//', ';' };

        /*
        var total = 0;

        foreach(var n in numbers.Split(allowedDelimeters.ToArray()))
        {
            total += int.Parse(n);
        }
        return total;
        */

        return numbers.Split(allowedDelimeters.ToArray()) // { "1", "2", "3")
            .Select(int.Parse) // Map [1,2,3]
            .Sum(); // 6
    }

}

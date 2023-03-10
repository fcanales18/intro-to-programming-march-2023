
using System.IO.Pipes;

namespace CSharpSyntax;

public class Collections
{
    [Fact]
    public void UsingAGenericList()
    {
        //generics change their form based on a type parameter
        //"Parametric Polymorphism
        var favoriteNumbers = new List<int>();
        favoriteNumbers.Add(9);
        favoriteNumbers.Add(10);
        favoriteNumbers.Add(108);

        //Assert.Equal(9, favoriteNumbers[0]);
        //Assert.Equal(10, favoriteNumbers[1]);

        Assert.Equal(3, favoriteNumbers.Count());
        //Assert.Contains(108, favoriteNumbers);
        //-"Roslyn" - "Compiler as a Service"

        //Assert.Equal(9, favoriteNumbers[0]);
    }

    [Fact]
    public void EnumeratingAList()
    {
        var favoriteNumbers = new List<int> { 9, 20, 108 };
        int total = 0;
        for (var x = 0; x < favoriteNumbers.Count; x++)
        {
            total += favoriteNumbers[x];
        }
        Assert.Equal(137, total);
        total = 0;

        foreach(var num in favoriteNumbers)
        {
            total += num;
        }
        Assert.Equal(137, total);
    }

    [Fact]
    public void DoingThingsWithPeople()
    {
        var bob = new Employee()
        {
            Name = "Robert",
            Salary = 82_000M
        };

        var jeff = new Contractor();
        jeff.Name = "Jeffry";
        jeff.HourlyRate = 28.58M;

        var workers = new List<Worker>
        {
            bob,
            jeff,
        };
        foreach(var person in workers)
        {
            person.GetPay();
        }


    }
}

public abstract class Worker
{
    public string Name { get; set; } = string.Empty;
    public abstract decimal GetPay();
}

public class Employee : Worker
{
    public decimal Salary { get; set; }
    public override decimal GetPay()
    {
        return Salary;
    }
}

public class Contractor : Worker
{
    //public string Name { get; set; } = string.Empty;
    public decimal HourlyRate { get; set; }
    public override decimal GetPay()
    {
        return HourlyRate;
    }
}
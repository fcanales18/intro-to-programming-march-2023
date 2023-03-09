using Banking.Domain;
using Banking.UnitTests.TestDoubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests;

public class OverdraftNotAllowed
{

    [Fact]
    public void OverdraftDoesNotDecreaseBalance()
    {
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();

        try
        {
            account.Withdraw(account.GetBalance() + 0.01M);
        }
        catch (OverdraftException)
        {

            //Ignore this...
        }

        Assert.Equal(openingBalance, account.GetBalance());
    }

    [Fact]
    public void OverdraftThrowsException()
    {
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();

        
        Assert.Throws<OverdraftException>(() =>
        {
            account.Withdraw(account.GetBalance() + .01M);
        });
        //below is an example of using delegates and using () => { }. Above is the shorter and cleaner way
        //var exceptionHelper = new ExceptionHelpers();

        /*
        var rightExceptionThrow = ExceptionHelpers.Throws<OverdraftException>(() =>
        {
            account.Withdraw(account.GetBalance() + .01M);
        });

        Assert.True(rightExceptionThrow);
        */
    }
}

public class ExceptionHelpers
{
    public static bool Throws<TException>(Action suspectCode) where TException : Exception // Generic Constraint
    {
        var rightExceptionThrown = false;
        try
        {
            //run some code here. Execute some code here
            suspectCode();
        }
        catch (TException)
        {
            rightExceptionThrown = true;
        }

        return rightExceptionThrown;
    }

    public static string FormatName(string first, string last)
    {
        return $"{last}, {first}";
    }
}

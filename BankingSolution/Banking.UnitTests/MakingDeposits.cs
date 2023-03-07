using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests;

public class MakingDeposits
{
    [Theory]
    [InlineData(100.00)]
    public void DeposistsIncreasesTheBalance(decimal amountToDeposit)
    {
        //Given
        var account = new BankAccount();
        var openingBalance = account.GetBalance(); // Query (Func)
        //When
        account.Deposit(amountToDeposit); // Command (Action)         
        //Then
        Assert.Equal(openingBalance + amountToDeposit,
        account.GetBalance());

    }
}


using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests;

public class MakingDeposits
{
    [Fact]
    public void DeposistsIncreasesTheBalance()
    {
        //Given
        var account = new BankAccount();
        var openingBalance = account.GetBalance(); //Query (Func)
        var amountToDeposit = 100M;
        //When
        account.Deposit(amountToDeposit); //Command (Action)
        //Then
        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());

    }
}


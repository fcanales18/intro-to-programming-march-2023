using Banking.Domain;
using Banking.UnitTests.TestDoubles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests;

public class MakingWithdrawals
{
    [Theory]
    [InlineData(1)]
    [InlineData(1020.22)]
    public void MakingAWithdrawalDecreasesBalance(decimal amountToWithdraw)
    {
        //Given
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance(); //Query (Func)
        //When
        account.Withdraw(amountToWithdraw); //Command (Action)
        //Then
        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }
}
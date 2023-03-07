using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests;
public class NewAccounts
{
  
    [Fact]
    public void NewAccountHasCorrectOpeningBalance()
    {
        //"Write the code you Wish you had"

        //Given
        //Type identifier = initializer
        BankAccount account = new BankAccount();
        //When
        decimal balance = account.GetBalance();
        //Then
        Assert.Equal(5000, balance);
    }
}

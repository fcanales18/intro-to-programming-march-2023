using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests;

public class GoldCustomerDeposits
{
    [Fact]
    public void GoldCustomersGetABonusOnDeposits()
    {
        var account = new BankAccount();
        account.AccountType = BankAccountType.Gold;
        var amountToDesposit = 100M;
        var openingBalance = account.GetBalance();

        account.Deposit(amountToDesposit);

        Assert.Equal(amountToDesposit + 10M + openingBalance, account.GetBalance());
    }
}

﻿
using Banking.Domain;
namespace Banking.UnitTests.BonusCalculations;

public class AdvancedBonusCalculatorTests
{
    [Fact]
    public void DepositsGetBonusBasedOnBalance() //decimal balance, decimal amount, decimal expectedBonus, DateTimeOffset when
    {
        //Given
        var bonusCalculator = new AdvancedBonusCalculator();

        //When
        decimal bonus = bonusCalculator.CalculateBankAccountDepositBonusFor(1000M, 10);

        //Then
        Assert.Equal(-42, bonus);
    }
}

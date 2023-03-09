
using Banking.Domain;

namespace Banking.UnitTests.BonusCalculations;

public class BasicBonusCalculatorTests
{
    //deposits that meet the criteria get a bonus
    [Theory]
    [InlineData(5000, 100, 10)]
    [InlineData(5000, 200, 20)] //Just at boundary
    [InlineData(4999.99, 100, 0)] //Just below boundary
                                //Add more as you need to give you confidence
    public void DepositsGetBonusBasedOnBalance(decimal balance, decimal amount, decimal expectedBonus)
    {
        //Given
        var bonusCalculator = new StandardBonusCalculator();

        //When
        decimal bonus = bonusCalculator.CalculateBankAccountDepositBonusFor(balance, amount);

        Assert.Equal(expectedBonus, bonus);
    }
    //deposits that do not meet the criteria do not get a bonus
}

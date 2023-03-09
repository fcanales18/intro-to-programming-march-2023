namespace Banking.Domain;

public class AdvancedBonusCalculator : ICalculateBonuses
{
    public decimal CalculateBankAccountDepositBonusFor(decimal accountCurrentBalance, decimal amountOfDeposits)
    {
        //this is where you can start doing the work
        return -42;
    }
}
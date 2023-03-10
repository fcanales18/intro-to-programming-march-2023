

namespace CSharpSyntax;

public class BankAccount
{
    private string _accountNumber = string.Empty;
    private string _firstName = string.Empty;

    internal BankAccount(string accountNumber, string firstName)
    {
        _accountNumber = accountNumber;
        FirstName = firstName;
    }

    //FirstName read only
    public string FirstName
    {
        get { return _firstName; }
        private set { _firstName = value; }
    }

    public string LastName { get; private set; } = string.Empty;
    public string GetAccountNumber()
    {
        return _accountNumber;
    }

}


//Class that does some work fo rme
//Services

public class AccountManager
{
    public BankAccount GetAccountById(string accountNumber)
    {
        //go find in the database
        var account = new BankAccount(accountNumber, "Jeff");
        return account;
    }

    public void DoDeposit(BankAccount bankAccount, decimal amount)
    {

    }
}
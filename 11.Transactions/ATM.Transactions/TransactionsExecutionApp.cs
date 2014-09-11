namespace ATM.Transactions
{
    using System;
    using System.Data.Entity.Core;
    using System.Linq;
    using System.Transactions;
    using ATM.Data;
    /* TASK 1
     *Suppose you are creating a simple engine for an ATM machine. 
     *Create a new database "ATM" in SQL Server to hold the accounts of the card holders 
     *and the balance (money) for each account. 
     *Add a new table CardAccounts with the following fields:
     *Id (int)
     *CardNumber (char(10))
     *CardPIN (char(4))
     *CardCash (money)
     *Add a few sample records in the table.
     */
    /* TASK 2
     * Using transactions write a method which retrieves some money (for example $200) from certain account. 
     * The retrieval is successful when the following sequence of sub-operations is completed successfully:
     * 1.A query checks if the given CardPIN and CardNumber are valid.
     * 2.The amount on the account (CardCash) is evaluated to see whether it is bigger than the requested sum (more than $200).
     * 3.The ATM machine pays the required sum (e.g. $200) and stores in the table CardAccounts the new amount (CardCash = CardCash - 200).     * Why does the isolation level need to be set to “repeatable read”?     */    /* TASK 3     * Extend the project from the previous exercise and add a new table TransactionsHistory with fields
     * (Id, CardNumber, TransactionDate, Ammount) containing information about all money retrievals on all accounts.
     * Modify the program logic so that it saves historical information (logs) 
     * in the new table after each successful money withdrawal.
     * What should the isolation level be for the transaction?     */ 
    public class TransactionsExecutionApp
    {
        private const string CardNumber = "2321456789";
        private const string CardPIN = "1234";
        
        public static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            ExecuteTransaction();
        }

        public static void ExecuteTransaction()
        {
            while (true)
            {
                try
                {
                    WithdrawMoney(CardNumber, CardPIN);
                    Console.WriteLine("Transaction completed!");
                }
                catch (EntityException e)
                {
                    Console.WriteLine("Operation failed...");
                    Console.WriteLine(e.InnerException.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Another transaction (Y/N)?");
                if (Console.ReadKey(true).Key == ConsoleKey.N)
                {
                    break;
                }
            }

            Console.WriteLine("GOODBYE!");
        }

        public static void WithdrawMoney(string cardNumber, string cardPin)
        {
            if (cardNumber == null)
            {
                throw new ArgumentNullException("Card number cannot be null!");
            }

            if (cardPin == null)
            {
                throw new ArgumentNullException("Card PIN cannot be null!");
            }

            if (cardNumber.Length != 10)
            {
                throw new ArgumentException("Invalid card number! Card number must consist of 10 digits!");
            }

            if (cardPin.Length != 4)
            {
                throw new ArgumentException("Invalid card PIN! Card PIN must consist of 4 digits!");
            }

            var options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.RepeatableRead;
            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                using (var db = new ATMEntities())
                {
                    var account = db.CardAccounts.FirstOrDefault(a => a.CardNumber == cardNumber && a.CardPIN == cardPin);

                    if (account == null)
                    {
                        scope.Dispose();
                        throw new InvalidOperationException("Wrong CardNumber or PIN!");
                    }

                    PrintBalance(account.CardCash);
                    decimal ammount = GetAmmountToWithdraw();

                    if (ammount < 0)
                    {
                        scope.Dispose();
                        throw new InvalidOperationException("You cannot withdraw negative amount!");
                    }

                    if (account.CardCash < ammount)
                    {
                        scope.Dispose();
                        throw new InvalidOperationException("Insufficient funds!");
                    }

                    account.CardCash -= ammount;
                    db.SaveChanges();

                    SaveTransactionHistory(cardNumber, ammount, db);

                    PrintBalance(account.CardCash);
                }

                scope.Complete();
            }
        }

        private static void SaveTransactionHistory(string cardNumber, decimal amount, ATMEntities db)
        {
            var options = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead,
                Timeout = new TimeSpan(0, 0, 0, 10)
            };

            using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
            {
                db.TransactionsHistories.Add(new TransactionsHistory
                {
                    CardNumber = cardNumber,
                    TransactionDate = DateTime.Now,
                    Ammount = amount
                });

                db.SaveChanges();

                scope.Complete();
            }
        }

        private static void PrintBalance(decimal cardCash)
        {
            Console.WriteLine("Account balance: {0:C}", cardCash);
        }

        private static decimal GetAmmountToWithdraw()
        {
            Console.Write("Please enter withdraw amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            return amount;
        }
    }
}

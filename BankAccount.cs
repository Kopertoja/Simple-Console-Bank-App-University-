using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BankAccount
    {
        private static List<Transaction> AllTransactions = new List<Transaction>();
        private static List<Loan> AllLoans = new List<Loan>();

        
        private static UInt32 accountNumberSeed = 23232323;

        public UInt32 Number { get; }
        public string Owner { get; set; }
        public decimal balance;
        public decimal Credit = 0;
        
        public decimal Balance
        {
            get {
                decimal transactionSum = 0;
                foreach (var transaction in AllTransactions)
                {
                    transactionSum += transaction.Amount;
                }
                return transactionSum + balance;
            }
            set { balance = value; }
        }

        public BankAccount(string name, decimal initialBalance, decimal Loan)
        {
            this.Owner = name;
            this.balance = initialBalance;
            this.Number = accountNumberSeed;
            this.Credit = Loan;
                      
            Console.WriteLine($"Utworzono konto z saldem {initialBalance}. Właścicielem konta jest: {name} ");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {

            Console.WriteLine($"Dokonano wpłaty o kwocie {amount}");
            if (amount <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Nie można wpłacić kwoty ujemnej");                              
            }
            Transaction deposit = new Transaction(amount, date, note);
            AllTransactions.Add(deposit);
        }

        public void MakeWithdraw(decimal amount, DateTime date, string note)
        {
           
            if(amount > this.balance)
            {
              throw new ArgumentOutOfRangeException("Nie ma wystarczających środków na koncie");
                
            }
            Console.WriteLine($"Dokonano wypłaty na kwote: {amount}");
            amount = amount * -1;
            Transaction withdraw = new Transaction(amount, date, note);
            AllTransactions.Add(withdraw);

        }

        public void ListTransactionHistory()
        {
            Console.WriteLine("Hisotria wykonywanych działań na koncie: \n");
            foreach (var Transaction in AllTransactions)
            {
                Console.WriteLine($"{Transaction.Note} | {Transaction.Amount} | {Transaction.Date} ");
            }
            if (Credit != 0) 
            { 
               
                Console.WriteLine("\nKredyty na twoim koncie:\n");
                foreach (var Loan in AllLoans)
                {
                Console.WriteLine($"{Loan.Note} | {Loan.Amount} | {Loan.Date} ");
                }
                Console.ReadKey();
            }
        }

        public void TakingLoan(decimal amount, DateTime date, string note)
        {
            note = "KREDYT";
            if(amount > 1000)
            {
                throw new ArgumentOutOfRangeException("Nie można wiąć tak dużego kredytu!");
            }
            Console.WriteLine($"Udzielono kredytu na kwotę: {amount}");
            Loan newLoan = new Loan(amount, date, note);
            Transaction Loan = new Transaction(amount, date, note);
            AllTransactions.Add(Loan);
            AllLoans.Add(newLoan);
            Credit += amount;
            
        }
        public void PayingLoan(decimal amount, DateTime date, string note)
        {
            
            note = "KREDYT";
            if (amount > this.Credit)
            {
                throw new ArgumentOutOfRangeException("Kredyt nie jest aż tak duży: ");
            }
            Console.WriteLine($"Spłaciłeś: {amount}zł kredytu");
            amount = amount * -1;
            Loan newLoan = new Loan(amount, date, note);
            Transaction Loan = new Transaction(amount, date, note);
            AllTransactions.Add(Loan);
            AllLoans.Add(newLoan);
            Credit += amount;

        }

        public void DisplayInfo()
        {

            Console.WriteLine("Twoje konto: \n");
            Console.WriteLine($"Właściciel: {Owner}");
            Console.WriteLine($"Numer konta:{Number}");
            Console.WriteLine($"Dostępne środki: {Balance}");
            Console.WriteLine($"Kwota kredytu: {Credit}");

        }

        
    }
}

using System;


namespace ConsoleApp1
{
    class Program
    {
        
        public static void Main(string[] args)
        {
             
            try
            {
                            
                playWithAccount();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Coś poszło nie tak: {e.Message}");
                Console.ReadKey();
               
            }
            
        }

        static public void playWithAccount()
        {
           

            Console.WriteLine("Proszę wprowadzić początkowy stan dla nowego konta: ");
            decimal initialBalance = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Proszę podać imię i nazwisko osoby, dla kórej tworzone jest konto: ");
            string name = Console.ReadLine();
            decimal Loan = 0;
            var instance = new BankAccount(name, initialBalance, Loan);
            Console.WriteLine("\nProszę nacisnąć dowolny klawisz aby kontynować.");
            Console.ReadKey();
            decimal i;

            
            do
            {
            Console.Clear();
            Console.WriteLine("1 = Dokonywanie wpłaty \n2 - Dokonywanie wypłaty \n3 - Historia transakcji \n4 - Informacje na temat konta \n5 - Udzielanie Kredytu \n6 - Spłata kredytu");
            string input = Console.ReadLine().ToUpper();


                switch (input)
                {
                    case "2":
                        Console.WriteLine("Wybieranie pieniędzy");
                        Console.WriteLine("Proszę podać kwotę do pobrania: ");
                        decimal withdraw = Decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Notatka: ");
                        string note2 ="WYPŁATA | " + Console.ReadLine();
                        DateTime localDate2 = DateTime.Now;
                        instance.MakeWithdraw(withdraw, localDate2, note2);


                        break;
                    case "1":
                        Console.WriteLine("Wykonywanie Depozytu");
                        Console.WriteLine("Proszę podać kwotę depozytu: ");
                        decimal deposit = Decimal.Parse(Console.ReadLine());
                        Console.WriteLine("Notatka: ");
                        string note1 ="WPŁATA | " + Console.ReadLine();
                        DateTime localDate1 = DateTime.Now;
                        instance.MakeDeposit(deposit, localDate1, note1);
                        break;
                    case "3":
                        instance.ListTransactionHistory();
                        break;
                    case "4":
                        instance.DisplayInfo();
                        break;
                    case "5":
                        Console.WriteLine("Udzielanie kredytu.");
                        Console.WriteLine("Proszę wybrać kwotę kredytu. Kredyt nie może byś wiekszy niż 1000zł.");
                        decimal CreditAmount = Decimal.Parse(Console.ReadLine());
                        DateTime localDate3 = DateTime.Now;
                        string note3 = Console.ReadLine();                         
                        instance.TakingLoan(CreditAmount, localDate3, note3);
                        break;
                    case "6":
                        Console.WriteLine("Spłata kredytu.");
                        Console.WriteLine("Proszę podać kwotę kredytu do spłaty");
                        decimal amount = Decimal.Parse(Console.ReadLine());
                        DateTime localDate4 = DateTime.Now;
                        string note4 = Console.ReadLine();
                        instance.PayingLoan(amount, localDate4, note4);
                        break;
                }                
                Console.WriteLine("\nCzy chciałbys kontynować? 0/1");
                i = Decimal.Parse(Console.ReadLine());

            } while (i == 1);
        }
    }
}

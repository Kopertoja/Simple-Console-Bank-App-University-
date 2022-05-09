using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Loan
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Note { get; }


        public Loan(decimal amount, DateTime date, string note)
        {
            this.Amount = amount;
            this.Date = date;
            this.Note = note;
        }
      
    }
}

  

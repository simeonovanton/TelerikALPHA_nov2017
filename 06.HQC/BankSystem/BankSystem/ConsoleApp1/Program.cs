using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.Logic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankAccount = new BankAccount(new ConsoleLogger())
            {
                Name = "Pesho"
            };

            bankAccount.Deposit(1000);
            bankAccount.Withdraw(100);
            Console.WriteLine(bankAccount.Money);

        }
    }
}

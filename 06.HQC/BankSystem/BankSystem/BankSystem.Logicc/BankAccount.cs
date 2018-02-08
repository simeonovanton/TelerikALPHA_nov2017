using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BankSystem.Logic
{
    public class BankAccount
    {
        private ILogger logger;
        //public BankAccount()
        //{
        //    this.logger = new FileLogger();
        //}
        public BankAccount(ILogger logger)
        {
            this.logger = logger;
        }
        public string Name { get; set; }
        public decimal Money { get; private set; }

        public void Withdraw(decimal money)
        {
            if (this.Money < money)
            {
                throw new ArgumentException("Unsufficient money balance!");
            }
            this.logger.Log($"{this.Name} withraw {money}");
            this.Money -= money;
        }

        public void Deposit(decimal money)
        {
            this.logger.Log($"{this.Name} deposit {money}");
            this.Money += money;
        }

    }
}

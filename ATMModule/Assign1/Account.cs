using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign1
{
    public abstract class Account
    {
        public string PIN { get; set; }

        public string Name { get; set; }

        public List<AccountType> AccountType { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public double Balance { get; set; }


        public abstract double calc(double balance, double withdraw, bool isWithdraw);
        public abstract int calcReward(double balance);

    }

    public enum AccountType
    {
        BasicBank, PreferredPackage, UltimatePackage, Chequing
    }

    public class Basic : Account
    {

        public Basic(string pin, List<AccountType> accountType, string name, string address, string email, string phone, double Balance)
        {
            this.PIN = pin;
            this.AccountType = accountType;
            this.Name = name;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.Balance = Balance;

        }

        public override double calc(double balance, double withdraw, bool isWithdraw)//claculate withdraw or deposit
        {
            double newBalance;

            if (isWithdraw)
                newBalance = balance - withdraw;
            else
                newBalance = balance + withdraw;

            while (newBalance < 500)
            {
                Console.WriteLine("balance is less than 500, Enter another withdraw");
                withdraw = double.Parse(Console.ReadLine());
                newBalance = balance - withdraw;
            }
            return newBalance;
        }

        public override int calcReward(double balance)
        {
            int points = 0;

            if (balance >= 2000)
            {
                int bonus = (int)((balance - 2000) / 500);
                points = points + 10 + (bonus * 5);
            }

            return points;
        }

    }

    public class Prefer : Account
    {

        public Prefer(string pin, List<AccountType> accountType, string name, string address, string email, string phone, double Balance)
        {
            this.PIN = pin;
            this.AccountType = accountType;
            this.Name = name;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.Balance = Balance;

        }

        public override double calc(double balance, double withdraw, bool isWithdraw)//claculate withdraw or deposit
        {
            double newBalance;

            if (isWithdraw)
                newBalance = balance - withdraw;
            else
                newBalance = balance + withdraw;

            while (newBalance < 500)
            {
                Console.WriteLine("balance is less than 500, Enter another withdraw");
                withdraw = double.Parse(Console.ReadLine());
                newBalance = balance - withdraw;
            }
            return newBalance;
        }

        public override int calcReward(double balance)
        {
            int points = 0;

            if (balance >= 2000)
            {
                int bonus = (int)((balance - 2000) / 500);
                points = points + 10 + (bonus * 5);
            }

            return points;
        }

    }

    public class Ultimate : Account
    {

        public Ultimate(string pin, List<AccountType> accountType, string name, string address, string email, string phone, double Balance)
        {
            this.PIN = pin;
            this.AccountType = accountType;
            this.Name = name;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.Balance = Balance;

        }

        public override double calc(double balance, double withdraw, bool isWithdraw)//claculate withdraw or deposit
        {
            double newBalance;

            if (isWithdraw)
                newBalance = balance - withdraw;
            else
                newBalance = balance + withdraw;

            while (newBalance < 500)
            {
                Console.WriteLine("balance is less than 500, Enter another withdraw");
                withdraw = double.Parse(Console.ReadLine());
                newBalance = balance - withdraw;
            }
            return newBalance;
        }

        public override int calcReward(double balance)
        {
            int points = 0;

            if (balance >= 2000)
            {
                int bonus = (int)((balance - 2000) / 500);
                points = points + 10 + (bonus * 5);
            }

            return points;
        }
    }

    public class Chequing : Account
    {

        public Chequing(string pin, List<AccountType> accountType, string name, string address, string email, string phone, double Balance)
        {
            this.PIN = pin;
            this.AccountType = accountType;
            this.Name = name;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.Balance = Balance;

        }

        public override double calc(double balance, double withdraw, bool isWithdraw)//claculate withdraw or deposit
        {
            double newBalance;

            if (isWithdraw)
                newBalance = balance - withdraw;
            else
                newBalance = balance + withdraw;

            while (newBalance < 500)
            {
                Console.WriteLine("balance is less than 500, Enter another withdraw");
                withdraw = double.Parse(Console.ReadLine());
                newBalance = balance - withdraw;
            }
            return newBalance;
        }

        public override int calcReward(double balance)
        {
            int points = 0;

            if (balance >= 2000)
            {
                int bonus = (int)((balance - 2000) / 500);
                points = points + 10 + (bonus * 5);
            }

            return points;
        }

    }

}
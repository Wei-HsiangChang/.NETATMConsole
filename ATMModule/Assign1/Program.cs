using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assign1;


namespace ATM
{
    internal class ATMSystem
    {
        static void Main(string[] args)
        {
            const string CHEQUING = "Chequing";
            const string BASIC = "Basic";
            const string PREFER = "Prefer";
            const string ULTIMATE = "Ultimate";
            string accountTypeName;

            List<Account> basicAccountList = ListRepo.BasicAccountStorage();
            List<Account> additionalAccountList = ListRepo.AdditionalAccounts();

            Console.WriteLine("Please enter your PIN number");

            string pin = Console.ReadLine();

            //check the client accounts matching the PIN number 
            var clientAccount = from client in basicAccountList
                            where client.PIN.Equals(pin)
                            select client;

            if (clientAccount.Count() != 1) //when find more than one PIN number terminate the console
            {
                Console.WriteLine("Duplicated or invalid PIN");
                Environment.Exit(0);
            }

            //enter to the menu
            foreach (var ca in clientAccount)
            {
                double newbalance;
                int reward;

                Console.WriteLine("Welcome to SounzyChill Bank, " + ca.Name +". Select the number of 1-7 from the following options:");
                Console.WriteLine("1. Current Balance\n2. Withdraw\n3. Deposit\n4. Cancel\n5. Reward Points Balance\n6. Close Account\n7. Exit ATM\n");
                int select = int.Parse(Console.ReadLine());
                if (select <= 7 && select >= 1)
                {
                    switch (select)
                    {
                        case 1:
                            Console.WriteLine("Select one of the account type");
                            Console.WriteLine("1. Basic Bank Account\n2. Preferred Package\n3. Ultimate Package\n4. Chequing Account");
                            select = int.Parse(Console.ReadLine());

                            if (select == 1) // if choose Basic Bank Account
                            {
                                Console.WriteLine("Show current balance for your " + AccountType.BasicBank + " account:\n");
                                Console.WriteLine("your current balance is " + ca.Balance.ToString("N2") + " dollars\n");
                            }

                            int i = 1;
                            // Loops in other account that match the choice or not to have related response 
                            foreach (var at in ca.AccountType)
                            {

                                if ((AccountType)(select - 1) == at) //if choose other accounts instead of Basic Bank Account 
                                {
                                    switch (at)
                                    {
                                        case AccountType.Chequing:
                                            accountTypeName = CHEQUING;
                                            break;
                                        case AccountType.BasicBank:
                                            accountTypeName = BASIC;
                                            break;
                                        case AccountType.PreferredPackage:
                                            accountTypeName = PREFER;
                                            break;
                                        case AccountType.UltimatePackage:
                                            accountTypeName = ULTIMATE;
                                            break;
                                        default:
                                            accountTypeName = "";
                                            break;
                                    }


                                    //check the other accounts matching the PIN number 
                                    var otherAccountList = from otherAccounts in additionalAccountList
                                                           where otherAccounts.PIN.Equals(pin)
                                                           select otherAccounts;

                                    foreach (var aa in otherAccountList)
                                    {
                                        if (aa.GetType().Name.Equals(accountTypeName)) //if client have other account
                                        {
                                            Console.WriteLine("Show current balance for your " + at + " account:\n");
                                            Console.WriteLine("your current balance is " + aa.Balance.ToString("N2") + " dollars\n");
                                        }

                                    }

                                    break;
                                }

                                if (i == ca.AccountType.Count()) //if can not find the account type terminate the console
                                {
                                    Console.WriteLine("you do not have this account");
                                    Environment.Exit(0);
                                }
                                i++;
                            }
                            break;

                        case 2:
                            Console.WriteLine("Select the account you want to withdraw");
                            Console.WriteLine("1. Basic Bank Account\n2. Preferred Package\n3. Ultimate Package\n4. Chequing Account");
                            select = int.Parse(Console.ReadLine());

                            while (select < 1 || select > 4) //warn if select wrong number
                            {
                                Console.WriteLine("Selection incorrect! Re-enter\n1. Basic Bank Account\n2. Preferred Package\n3. Ultimate Package\n4. Chequing Account");
                                select = int.Parse(Console.ReadLine());

                            }

                            Console.WriteLine("Enter the cash you want to Withdraw");
                            double withdraw = double.Parse(Console.ReadLine());
                            if (select == 1) // if choose Basic Bank Account
                            {
                                newbalance = ca.calc(ca.Balance, withdraw, true);
                                ca.Balance = newbalance;
                                Console.WriteLine("After withdrawing, the balance is " + ca.Balance.ToString("N2") + " dollars\n");
                            }
                            else
                            {
                                i = 1;
                                // Loops in other account that match the choice or not to have related response 
                                foreach (var at in ca.AccountType)
                                {                
                                        
                                    if ((AccountType)(select - 1) == at) //if choose other accounts instead of Basic Bank Account
                                    {
        
                                        switch (at)
                                        {
                                            case AccountType.Chequing:
                                                accountTypeName = CHEQUING;
                                                break;
                                            case AccountType.BasicBank:
                                                accountTypeName = BASIC;
                                                break;
                                            case AccountType.PreferredPackage:
                                                accountTypeName = PREFER;
                                                break;
                                            case AccountType.UltimatePackage:
                                                accountTypeName = ULTIMATE;
                                                break;
                                            default:
                                                accountTypeName = "";
                                                break;
                                        }


                                        //check the other accounts matching the PIN number 
                                        var otherAccountList = from otherAccounts in additionalAccountList
                                                               where otherAccounts.PIN.Equals(pin)
                                                               select otherAccounts;

                                        foreach (var aa in otherAccountList)
                                        {
                                            if (aa.GetType().Name.Equals(accountTypeName)) //if client have other account
                                            {
                                                newbalance = aa.calc(aa.Balance, withdraw, true);
                                                aa.Balance = newbalance;
                                                Console.WriteLine("After withdrawing, the balance is " + aa.Balance.ToString("N2") + " dollars\n");
                                            }

                                        }

                                        break;
                                    }

                                    if (i == ca.AccountType.Count()) //if can not find the account type terminate the console
                                    {
                                        Console.WriteLine("you do not have this account");
                                        Environment.Exit(0);
                                    }
                                    i++;
                                }

                            }
                            break;

                        case 3:
                            Console.WriteLine("Select the account you want to deposit");
                            Console.WriteLine("1. Basic Bank Account\n2. Preferred Package\n3. Ultimate Package\n4. Chequing Account");
                            select = int.Parse(Console.ReadLine());

                            while (select < 1 || select > 4) //warn if select wrong number
                            {
                                Console.WriteLine("Selection incorrect! Re-enter\n1. Basic Bank Account\n2. Preferred Package\n3. Ultimate Package\n4. Chequing Account");
                                select = int.Parse(Console.ReadLine());

                            }

                            Console.WriteLine("Enter the cash you want to deposit");
                            double deposit = double.Parse(Console.ReadLine());
                            if (select == 1) // if choose Basic Bank Account
                            {
                                newbalance = ca.calc(ca.Balance, deposit, false);
                                ca.Balance = newbalance;
                                Console.WriteLine("After depositing, the balance is " + ca.Balance.ToString("N2") + " dollars\n");
                            }
                            else
                            {
                                i = 1;
                                // Loops in other account that match the choice or not to have related response 
                                foreach (var at in ca.AccountType)
                                {

                                    if ((AccountType)(select - 1) == at) //if choose other accounts instead of Basic Bank Account 
                                    {
                                        switch (at)
                                        {
                                            case AccountType.Chequing:
                                                accountTypeName = CHEQUING;
                                                break;
                                            case AccountType.BasicBank:
                                                accountTypeName = BASIC;
                                                break;
                                            case AccountType.PreferredPackage:
                                                accountTypeName = PREFER;
                                                break;
                                            case AccountType.UltimatePackage:
                                                accountTypeName = ULTIMATE;
                                                break;
                                            default:
                                                accountTypeName = "";
                                                break;
                                        }


                                        //check the other accounts matching the PIN number 
                                        var otherAccountList = from otherAccounts in additionalAccountList
                                                               where otherAccounts.PIN.Equals(pin)
                                                               select otherAccounts;

                                        foreach (var aa in otherAccountList)
                                        {
                                            if (aa.GetType().Name.Equals(accountTypeName)) //if client have other account
                                            {
                                                newbalance = aa.calc(aa.Balance, deposit, false);
                                                aa.Balance = newbalance;
                                                Console.WriteLine("After depositing, the balance is " + aa.Balance.ToString("N2") + " dollars\n");
                                            }

                                        }

                                        break;
                                    }

                                    if (i == ca.AccountType.Count()) //if can not find the account type terminate the console
                                    {
                                        Console.WriteLine("you do not have this account");
                                        Environment.Exit(0);
                                    }
                                    i++;
                                }
                            }
                            break;

                        case 4:
                            Console.WriteLine("Cancel the menu");
                            break;
                        case 5:
                            Console.WriteLine("Select the account you want to check Reward Points");
                            Console.WriteLine("1. Basic Bank Account\n2. Preferred Package\n3. Ultimate Package\n4. Chequing Account");
                            select = int.Parse(Console.ReadLine());
                           
                            if (select == 1) // if choose Basic Bank Account
                            {
                                reward = ca.calcReward(ca.Balance);
                                Console.WriteLine("The current Reward Points you will get per week is " + reward + " points\n");
                            }
                            else
                            {
                                i = 1;
                                // Loops in other account that match the choice or not to have related response 
                                foreach (var at in ca.AccountType)
                                {

                                    if ((AccountType)(select - 1) == at) //if choose other accounts instead of Basic Bank Account 
                                    {
                                        switch (at)
                                        {
                                            case AccountType.Chequing:
                                                accountTypeName = CHEQUING;
                                                break;
                                            case AccountType.BasicBank:
                                                accountTypeName = BASIC;
                                                break;
                                            case AccountType.PreferredPackage:
                                                accountTypeName = PREFER;
                                                break;
                                            case AccountType.UltimatePackage:
                                                accountTypeName = ULTIMATE;
                                                break;
                                            default:
                                                accountTypeName = "";
                                                break;
                                        }


                                        //check the other accounts matching the PIN number 
                                        var otherAccountList = from otherAccounts in additionalAccountList
                                                               where otherAccounts.PIN.Equals(pin)
                                                               select otherAccounts;

                                        foreach (var aa in otherAccountList)
                                        {
                                            if (aa.GetType().Name.Equals(accountTypeName)) //if client have other account
                                            {
                                                reward = aa.calcReward(aa.Balance);
                                                Console.WriteLine("The current Reward Points you will get per week is " + reward + " points\n");

                                            }

                                        }

                                        break;
                                    }

                                    if (i == ca.AccountType.Count()) //if can not find the account type terminate the console
                                    {
                                        Console.WriteLine("you do not have this account");
                                        Environment.Exit(0);
                                    }
                                    i++;
                                }
                            }
                            break;
                        case 6:
                            Console.WriteLine("Select the account you want to close it");
                            Console.WriteLine("1. Basic Bank Account\n2. Preferred Package\n3. Ultimate Package\n4. Chequing Account");
                            select = int.Parse(Console.ReadLine());
                            while (select < 1 || select > 4) //warn if select wrong number
                            {
                                Console.WriteLine("Selection incorrect! Re-enter\n1. Basic Bank Account\n2. Preferred Package\n3. Ultimate Package\n4. Chequing Account");
                                select = int.Parse(Console.ReadLine());

                            }

                            if (select == 1) // if choose Basic Bank Account
                            {
                                Console.WriteLine("It will delete all your related account also");

                                i = 1;
                                // Loops in other account to delete related account types
                                foreach (var at in ca.AccountType)
                                {

                                    if ((AccountType)(select - 1) == at)
                                    {

                                        switch (at)
                                        {
                                            case AccountType.Chequing:
                                                accountTypeName = CHEQUING;
                                                break;
                                            case AccountType.BasicBank:
                                                accountTypeName = BASIC;
                                                break;
                                            case AccountType.PreferredPackage:
                                                accountTypeName = PREFER;
                                                break;
                                            case AccountType.UltimatePackage:
                                                accountTypeName = ULTIMATE;
                                                break;
                                            default:
                                                accountTypeName = "";
                                                break;
                                        }


                                        //check the other accounts matching the PIN number 
                                        var otherAccountList = from otherAccounts in additionalAccountList
                                                               where otherAccounts.PIN.Equals(pin)
                                                               select otherAccounts;

                                        foreach (var aa in otherAccountList)
                                        {
                                            Console.WriteLine("Delete your " + aa.GetType().Name + " account\n");

                                            otherAccountList.Where(x => x != aa).ToList(); //delete sub account containing the same PIN

                                        }

                                        break;
                                    }

                                    if (i == ca.AccountType.Count()) //if can not find the account type terminate the console
                                    {
                                        Console.WriteLine("you do not have this account");
                                        Environment.Exit(0);
                                    }
                                    i++;
                                }

                            }
                            else
                            {
                                i = 1;
                                foreach (var at in ca.AccountType)
                                {

                                    if ((AccountType)(select - 1) == at) 
                                    {
                                        switch (at)
                                        {
                                            case AccountType.Chequing:
                                                accountTypeName = CHEQUING;
                                                break;
                                            case AccountType.BasicBank:
                                                accountTypeName = BASIC;
                                                break;
                                            case AccountType.PreferredPackage:
                                                accountTypeName = PREFER;
                                                break;
                                            case AccountType.UltimatePackage:
                                                accountTypeName = ULTIMATE;
                                                break;
                                            default:
                                                accountTypeName = "";
                                                break;
                                        }


                                        //check the other accounts matching the PIN number 
                                        var otherAccountList = from otherAccounts in additionalAccountList
                                                               where otherAccounts.PIN.Equals(pin)
                                                               select otherAccounts;

                                        foreach (var aa in otherAccountList)
                                        {
                                            if (aa.GetType().Name.Equals(accountTypeName))
                                            {
                                                Console.WriteLine("Delete " + accountTypeName + " account\n");
                                                otherAccountList.Where(x => x != aa).ToList(); //delete sub account containing the same account type  

                                            }

                                        }

                                        break;
                                    }

                                    if (i == ca.AccountType.Count()) //if can not find the account type terminate the console
                                    {
                                        Console.WriteLine("you do not have this account");
                                        Environment.Exit(0);
                                    }
                                    i++;
                                }
                            }

                            break;
                        case 7:
                            Console.WriteLine("Exit ATM, welcome next time!");
                            Environment.Exit(0);
                            break;
                    }
                    
                }
        
            }

        }
    }
}



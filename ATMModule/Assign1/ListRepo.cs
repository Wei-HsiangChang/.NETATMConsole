using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assign1
{
    public class ListRepo
    {
        public static List<Account> BasicAccountStorage()
        {
            //Store account data, Basic Bank account type by default
            List<Account> ClientAccounts = new List<Account>()
            {
            new Basic("123", new List<AccountType>() {(AccountType)0, (AccountType)3}, "Michael","123 street","123@gmail.com","0123", 2000),
            new Basic("234", new List<AccountType>() {(AccountType)0, (AccountType)1 }, "Lea","234 street","234@gmail.com","2345", 1800),
            new Basic("345", new List<AccountType>() {(AccountType)0, (AccountType)1, (AccountType)2 },"Tim","345 street","345@gmail.com","3456", 700.2345),
            new Basic("456", new List<AccountType>() {(AccountType)0 },"John","456 Street","456@gmail.com","4567", 900.345),
            new Basic("567", new List<AccountType>() {(AccountType)0, (AccountType)2},"Lisa","567 Street","567@gmail.com","5678", 6360.45)
            };
            return ClientAccounts;
        }

        public static List<Account> AdditionalAccounts()
        {
            //Store other account type data
            List<Account> OtherAccounts = new List<Account>()
            {
            new Chequing("123", new List<AccountType>() {(AccountType)0, (AccountType)3}, "Michael","123 street","123@gmail.com","0123", 1300.5),
            new Prefer("234", new List<AccountType>() {(AccountType)0, (AccountType)1 }, "Lea","234 street","234@gmail.com","2345", 1600),
            new Prefer("345", new List<AccountType>() {(AccountType)0, (AccountType)1, (AccountType)2 },"Tim","345 street","345@gmail.com","3456", 1200.245),
            new Ultimate("345", new List<AccountType>() {(AccountType)0, (AccountType)1, (AccountType)2 },"Tim","345 street","345@gmail.com","3456", 4860.5),
            new Ultimate("567", new List<AccountType>() {(AccountType)0, (AccountType)2},"Lisa","567 Street","567@gmail.com","5678", 3360.5)
            };
            return OtherAccounts;
        }


    }
}


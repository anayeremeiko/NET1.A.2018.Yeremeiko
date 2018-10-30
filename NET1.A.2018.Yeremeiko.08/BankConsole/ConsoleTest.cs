using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bank;

namespace BankConsole
{
    public class ConsoleTest
    {
        public static void Main(string[] args)
        {
            BankAccountService service = new BankAccountService(new AccountRepository());
            Client client = new Client("Anastasia", "Yeremeiko", "nastyaeremeyko@gmail.com", "AB2938881");
            string accountId;
            service.CreateAccount(client, 3000, out accountId);

            service.AccountTopUp(accountId, 30);
            service.Withdrawal(accountId, 50);
            service.CloseAccount(accountId);
        }
    }
}

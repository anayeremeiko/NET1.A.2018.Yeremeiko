using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Bank service.
    /// </summary>
    public class BankAccountService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public BankAccountService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        /// <summary>
        /// Creates the account.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns>The account.</returns>
        /// <exception cref="ArgumentException">Money should be non negative.</exception>
        public Account CreateAccount(Client client, decimal money, out string id)
        {
            if (money < 0)
            {
                throw new ArgumentException("Money should be non negative.");
            }

            Account account;

            if (money <= 1000)
            {
                account = new BaseAccount(client, money);
            }
            else if (money <= 10000)
            {
                account = new SilverAccount(client, money);
            }
            else if (money <= 100000)
            {
                account = new GoldAccount(client, money);
            }
            else
            {
                account = new PlatinumAccount(client, money);
            }

            id = account.Id;

            _repositoryFactory.Create(account);

            return account;
        }

        /// <summary>
        /// Closes the account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <exception cref="ArgumentNullException">Account need to be not null.</exception>
        /// <exception cref="ArgumentException">There is no account with such identifier.</exception>
        public void CloseAccount(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException($"{nameof(id)} need to be not empty.");
            }

            Account account = _repositoryFactory.GetAccount(id);
            if (account == null)
            {
                throw new ArgumentException($"There is no account with such identifier.");
            }

            account.Close();
        }

        /// <summary>
        /// Add money to account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="money">The money.</param>
        /// <exception cref="ArgumentNullException">Account need to be not null.</exception>
        /// <exception cref="ArgumentException">Money need to be positive value.</exception>
        /// <exception cref="ArgumentException">There is no account with such identifier.</exception>
        public void AccountTopUp(string id, decimal money)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException($"{nameof(id)} need to be not empty.");
            }

            if (money <= 0)
            {
                throw new ArgumentException($"{nameof(money)} need to be positive value.");
            }

            Account account = _repositoryFactory.GetAccount(id);
            if (account == null)
            {
                throw new ArgumentException($"There is no account with such identifier.");
            }

            account.TopUp(money);
        }

        /// <summary>
        /// Withdrawals the specified account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="money">The money.</param>
        /// <exception cref="ArgumentNullException">Account need to be not null.</exception>
        /// <exception cref="ArgumentException">Money need to ne positive value.</exception>
        /// <exception cref="ArgumentException">There is no account with such identifier.</exception>
        public void Withdrawal(string id, decimal money)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException($"{nameof(id)} need to be not empty.");
            }

            if (money <= 0)
            {
                throw new ArgumentException($"{nameof(money)} need to be positive value.");
            }

            Account account = _repositoryFactory.GetAccount(id);
            if (account == null)
            {
                throw new ArgumentException($"There is no account with such identifier.");
            }
            
            account.Withdrawal(money);
        }
    }
}

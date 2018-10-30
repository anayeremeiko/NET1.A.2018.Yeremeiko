using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class AccountRepository : IRepositoryFactory
    {
        private List<Account> accountRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        public AccountRepository()
        {
            accountRepository = new List<Account>();
        }

        /// <summary>
        /// Creates new account.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <exception cref="ArgumentNullException">Account need to be not null.</exception>
        public void Create(Account account)
        {
            if (ReferenceEquals(account, null))
            {
                throw new ArgumentNullException($"{nameof(account)} need to be not null.");
            }

            accountRepository.Add(account);
        }

        /// <summary>
        /// Deletes the account by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="ArgumentException">Id need to be not empty.</exception>
        public void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException($"{nameof(id)} need to be not empty.");
            }
            
            foreach (Account account in accountRepository)
            {
                if (account.Id == id)
                {
                    accountRepository.Remove(account);
                }
            }
        }

        /// <summary>
        /// Gets the account by specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Matching account.</returns>
        /// <exception cref="ArgumentException">The identifier need to be not empty.</exception>
        public Account GetAccount(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException($"{nameof(id)} need to be not empty.");
            }

            foreach (Account account in accountRepository)
            {
                if (account.Id == id)
                {
                    return account;
                }
            }

            return null;
        }
    }
}

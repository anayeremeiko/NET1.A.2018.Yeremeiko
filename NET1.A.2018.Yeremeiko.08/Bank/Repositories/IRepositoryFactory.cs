using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    /// <summary>
    /// Interface for bank repository.
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Creates new account.
        /// </summary>
        /// <param name="account">The account.</param>
        void Create(Account account);

        /// <summary>
        /// Gets the account.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Account GetAccount(string id);

        /// <summary>
        /// Deletes the account by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(string id);
    }
}

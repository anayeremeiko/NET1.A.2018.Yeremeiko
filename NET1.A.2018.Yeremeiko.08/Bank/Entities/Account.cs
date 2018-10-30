using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public abstract class Account : IEquatable<Account>
    {
        protected int balanceCoefficient;
        protected int operationCoefficient;
        private readonly string id;

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected Account(Client owner)
        {
            if (ReferenceEquals(owner, null))
            {
                throw new ArgumentNullException($"{nameof(owner)} need to be not null.");
            }

            Open = true;
            Owner = owner;
            this.id = owner.Id;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id => id;

        /// <summary>
        /// Gets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public decimal Balance { get; private set; }

        /// <summary>
        /// Gets the bonus.
        /// </summary>
        /// <value>
        /// The bonus.
        /// </value>
        public decimal Bonus { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Account"/> is open.
        /// </summary>
        /// <value>
        ///   <c>true</c> if open; otherwise, <c>false</c>.
        /// </value>
        public bool Open { get; private set; }

        /// <summary>
        /// Gets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public Client Owner { get; private set; }

        /// <summary>
        /// Gets the balance coefficient.
        /// </summary>
        /// <value>
        /// The balance coefficient.
        /// </value>
        protected int BalanceCoefficient { get => balanceCoefficient; private set => balanceCoefficient = value; }

        /// <summary>
        /// Gets the operation coefficient.
        /// </summary>
        /// <value>
        /// The operation coefficient.
        /// </value>
        protected int OperationCoefficient { get => operationCoefficient; private set => operationCoefficient = value; }

        /// <summary>
        /// Closes this account.
        /// </summary>
        public void Close() => Open = false;

        public void TopUp(decimal money)
        {
            if (Balance == 0)
            {
                Balance = money;
                Bonus = BalanceBonusCount(money);
            }
            else
            {
                Bonus += BalanceBonusCount(money);
                Balance += money;
                Bonus += OperationsBonusCount(money);
            }
        }

        /// <summary>
        /// Balance bonus count.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns>Balance bonus.</returns>
        public decimal BalanceBonusCount(decimal money) => Balance * BalanceCoefficient / 1000;

        /// <summary>
        /// Operations bonus count.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <returns>Operation bonus</returns>
        public decimal OperationsBonusCount(decimal money) => Balance * OperationCoefficient / 100;

        /// <summary>
        /// Withdrawals the specified money.
        /// </summary>
        /// <param name="money">The money.</param>
        /// <exception cref="ArgumentException">Not enough money.</exception>
        public void Withdrawal(decimal money)
        {
            if (Balance - money <= 0)
            {
                throw new ArgumentException("Not enough money.");
            }

            Balance -= BalanceBonusCount(money);
            Balance -= money;
            Bonus -= OperationsBonusCount(money);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Account other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other.Owner == Owner && other.BalanceCoefficient == BalanceCoefficient && other.OperationCoefficient == OperationCoefficient)
            {
                return true;
            }

            return false;
        }
    }
}

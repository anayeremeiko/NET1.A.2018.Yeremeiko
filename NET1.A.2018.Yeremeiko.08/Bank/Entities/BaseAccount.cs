using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class BaseAccount : Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAccount"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="money">The money.</param>
        public BaseAccount(Client client, decimal money) : base(client)
        {
            balanceCoefficient = 2;
            operationCoefficient = 1;
            TopUp(money);
        }
    }
}

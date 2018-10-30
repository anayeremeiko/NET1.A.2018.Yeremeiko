using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class PlatinumAccount : Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlatinumAccount"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="money">The money.</param>
        public PlatinumAccount(Client client, decimal money) : base(client)
        {
            balanceCoefficient = 5;
            operationCoefficient = 4;
            TopUp(money);
        }
    }
}

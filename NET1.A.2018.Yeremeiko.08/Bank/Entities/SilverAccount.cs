using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class SilverAccount : Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SilverAccount"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="money">The money.</param>
        public SilverAccount(Client client, decimal money) : base(client)
        {
            balanceCoefficient = 3;
            operationCoefficient = 2;
            TopUp(money);
        }
    }
}

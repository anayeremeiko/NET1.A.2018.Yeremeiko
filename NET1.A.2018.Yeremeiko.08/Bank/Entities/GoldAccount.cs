using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class GoldAccount : Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccount"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="money">The money.</param>
        public GoldAccount(Client client, decimal money) : base(client)
        {
            balanceCoefficient = 4;
            operationCoefficient = 3;
            TopUp(money);
        }
    }
}

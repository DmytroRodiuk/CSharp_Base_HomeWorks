using System;

namespace Lesson08_HomeWork08.CardSystem.Specific
{
    public class PlatinumCard : CommonCard
    {
        public PlatinumCard(string number, CardSecurity security, DateTime expirationDate, Customer owner, Bank emittent)
            : base(number, security, expirationDate, owner, emittent)
        {
        }

        public override decimal DepositCommission(decimal amount)
        {
            if (amount > 10_000)
            {
                return base.DepositCommission(amount) / 2;
            }
            else
            {
                return base.DepositCommission(amount) + 15;
            }
        }

        public override decimal WithdrawCommission(decimal amount)
        {
            return 20;
        }
    }
}

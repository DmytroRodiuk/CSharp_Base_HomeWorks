using System;

namespace Lesson08_HomeWork08.CardSystem.Specific
{
    public class UniversalCard : CommonCard
    {
        public UniversalCard(string number, CardSecurity security, DateTime expirationDate, Customer owner, Bank emittent)
            : base(number, security, expirationDate, owner, emittent)
        {
        }

        public override decimal DepositCommission(decimal amount)
        {
            return base.DepositCommission(amount);
        }

        public override decimal WithdrawCommission(decimal amount)
        {
            return base.WithdrawCommission(amount);
        }
    }
}

﻿using System;

namespace Lesson08_HomeWork08.CardSystem.Specific
{
    public class SavingsCard : CommonCard
    {
        public SavingsCard(string number, CardSecurity security, DateTime expirationDate, Customer owner, Bank emittent)
            : base(number, security, expirationDate, owner, emittent)
        {
            WithdrawCommissionPercent = 0.02m;
        }

        public override decimal DepositCommission(decimal amount)
        {
            return 0;
        }

        public override decimal WithdrawCommission(decimal amount)
        {
            return base.WithdrawCommission(amount);
        }
    }
}

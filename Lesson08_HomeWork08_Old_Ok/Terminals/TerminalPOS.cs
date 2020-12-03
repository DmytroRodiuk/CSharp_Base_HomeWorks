using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson08_HomeWork08.Terminals
{
    class TerminalPOS : CommonTerminal
    {
        public TerminalPOS(Bank owner, uint number) : base(owner, number)
        {
            // Возможность снятия денег / пополнения счета через банкомат (ATM)
            isDeposit = false;
            isWithdraw = false;
            isPay = true;

            base.Balance = 0;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson08_HomeWork08.Terminals
{
    public class MobileTerminal : CommonTerminal
    {
        // Общий класс для мобильных терминалов - различных видов POS-терминалов, 
        // возможно програмных (приложения в смартфоне ?) и т.д.

        public MobileTerminal(Bank owner, uint number) : base(owner, number)
        {
            // Возможность снятия денег / пополнения счета через банкомат (ATM)
            isDeposit = false;
            isWithdraw = false;
            isPay = true;

            base.Balance = 0;

            TerminalDepositCommissionPercent = 0;
            TerminalWithdrawCommissionPercent = 0;
        }
    }
}

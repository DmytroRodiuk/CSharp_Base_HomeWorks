using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson08_HomeWork08.Terminals
{
    // Общий класс для стационарных терминалов - банкоматы ATM, терминалы для пополнения денег SST
    

    public class StationaryTerminal : CommonTerminal
    {
        // Кол-во банкнот разного достоинства в терминале
        protected uint[,] banknoteArray;
        // Временный массив для отслеживания вносимых купюр
        protected uint[,] banknoteArrayTmp;

        public uint[,] GetBanknoteArrayTmp()
        {
            return banknoteArrayTmp;
        }


        // Создадим временный массив вносимых банкнот
        public void InitBanknoteArrayTmp()
        {
            banknoteArrayTmp = new uint[,] { { 5, 0 }, { 10, 0 }, { 20, 0 }, { 50, 0 }, { 100, 0 }, { 200, 0 }, { 500, 0 }, { 1000, 0 } };
        }

        // Для контроля заполнения терминала кешем - не пора ли делать инкассацию ?
        public uint GetBanknoteCount()
        {
            uint count = 0;
            for (int i = 0; i < banknoteArray.Length / 2; i++)
            {
                count += banknoteArray[i, 1];
            }
            return count;
        }


        public StationaryTerminal(Bank owner, uint number) : base(owner, number)
        {
            // Возможность снятия денег / пополнения счета через банкомат (ATM)
            isDeposit = false;
            isWithdraw = true;
            isPay = true;

            base.Balance = 10_000;          // Для теста

            TerminalDepositCommissionPercent = 0.01m;       // У нас жадный банк
            TerminalWithdrawCommissionPercent = 0.02m;      // У нас жадный банк

            // Для теста - по 3 банкноты каждого номинала
            banknoteArray = new uint[,] { { 5, 3 }, { 10, 3 }, { 20, 3 }, { 50, 3 }, { 100, 3 }, { 200, 3 }, { 500, 3 }, { 1000, 3 } };
        }




    }
}

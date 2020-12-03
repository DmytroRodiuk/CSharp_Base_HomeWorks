using System;
using System.Collections.Generic;
using System.Text;


namespace Lesson08_HomeWork08.Terminals
{
    public class TerminalSST : StationaryTerminal
    {
        public TerminalSST(Bank owner, uint number) : base(owner, number)
        {
            isDeposit = true;
            isWithdraw = false;
            isPay = true;

            base.Balance = 10_000;
        }

        public void Deposit(decimal amount, ref CommonCard card)
        {
            // Пополняем карту
            card.Deposit(amount);

            // За пополнение счета через терминал - комиссию не берем. Пока не берем....

            // Кол-во денег в терминале
            Balance += amount;
        }



        // Внесение банкнот - во временный массив
        public bool AddBanknote(uint banknoteNominal, uint banknoteCount = 1)
        {
            for (int i = 0; i < banknoteArrayTmp.Length / 2; i++)
            {
                if (banknoteArrayTmp[i, 0] == banknoteNominal)
                {
                    banknoteArrayTmp[i, 1]++;
                    return true;
                }
            }
            return false;
        }

        // Завершаем процесс ввода банкнот - переносим банкноты в основной массив
        public void AddBanknoteFinish()
        {
            for (int i = 0; i < banknoteArrayTmp.Length / 2; i++)
            {
                if (banknoteArray[i, 0] == banknoteArrayTmp[i, 0])
                {
                    banknoteArrayTmp[i, 1]++;
                }
            }

            // Вернем временный массив вносимых банкнот в начальное состояние
            InitBanknoteArrayTmp();
        }


    }
}

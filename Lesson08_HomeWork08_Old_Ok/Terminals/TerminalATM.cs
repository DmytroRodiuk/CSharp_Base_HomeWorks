using System;
using System.Collections.Generic;
using System.Text;


namespace Lesson08_HomeWork08.Terminals
{
    class TerminalATM : CommonTerminal
    {
        private uint[,] banknoteArrayTmp;

        public uint[,] GetBanknoteArrayTmp()
        {
            return banknoteArrayTmp;
        }

        public TerminalATM(Bank owner, uint number) : base(owner, number)
        {
            // Возможность снятия денег / пополнения счета через банкомат (ATM)
            isDeposit = false;
            isWithdraw = true;
            isPay = false;           // Пока ТАК

            base.Balance = 10_000;

            // Тля теста - по 3 банкноты каждого номинала
            banknoteArray = new uint[,] { { 5, 3 }, { 10, 3 }, { 20, 3 }, { 50, 3 }, { 100, 3 }, { 200, 3 }, { 500, 3 }, { 1000, 3 } };

        }


        // Снять кеш через банкомат (ATM)       
        public void Withdraw(decimal amount, ref CommonCard card)
        {
            // Комиссия за использование терминала для оплаты - с карты 1
            decimal commissionTerm = TerminalWithdrawCommission(amount);
            // Комиссия за снятие денег с карты 1
            decimal commissionCard = card.WithdrawCommission(amount + commissionTerm);

            if (amount <= 0)
            {
                Console.WriteLine("Required: amount > 0");
            }

            if (Balance < amount + commissionCard + commissionTerm)
            {
                Console.WriteLine("Not enough money");
            }

            // Выводим с 1-й карты - сумма для снятия кэша + Комиссия за использование терминала
            card.Withdraw(amount + commissionTerm);

            Owner.ReceiveFunds(commissionTerm);

            Balance -= amount;

            // С учетом банкнот
            if (banknoteArrayTmp != null)
            {
                for (int i = 0; i < banknoteArrayTmp.Length / 2; i++)
                {
                    banknoteArray[i, 1] -= banknoteArrayTmp[i, 1];
                }
            }
        }



        // Создадим временный массив вносимых банкнот
        public void InitBanknoteArrayTmp()
        {
            banknoteArrayTmp = new uint[,] { { 5, 0 }, { 10, 0 }, { 20, 0 }, { 50, 0 }, { 100, 0 }, { 200, 0 }, { 500, 0 }, { 1000, 0 } };
        }

        // Проверка возможности снятия денег с учетом ниличия банкнот в банкомате
        // Какими банкнотими выдать запрашиваемую сумму - в массив banknoteArrayTmp
        public bool IsWithdraw(decimal amount)
        {
            bool ret = false;

            // Кратность 5 - номинал мин. банкноты
            if (amount % 5 != 0)   return ret;

            InitBanknoteArrayTmp();

            do
            {
                for (int i = (int) banknoteArrayTmp.Length / 2 - 1; i >= 0; i--)
                {
                    if (amount >= banknoteArray[i, 0] && (banknoteArray[i, 1] - banknoteArrayTmp[i, 1]) > 0)
                    {
                        banknoteArrayTmp[i, 1]++;
                        amount -= banknoteArrayTmp[i, 0];

                        if (amount > 0)
                        {
                            i++;    // Еще раз проверим наличие банкноты этого номинала
                        }
                    }
                }
            } while (amount > 0);

            return true;
        }


    }
}

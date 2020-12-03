using System;
using System.Collections.Generic;
using System.Text;
using Lesson08_HomeWork08.Terminals;

namespace Lesson08_HomeWork08
{
    public class CommonTerminal
    {
        // Банк-владелец терминала (SST) /банкомата (ATM)
        public Bank Owner { get; set; }

        // Номер терминала (SST) /банкомата (ATM)
        public uint TerminalNumber { get; set; }

        public Address TerminalAddress { get; set; }

        // Кол-во денег в терминале (SST) /банкомате (ATM)
        public decimal Balance { get; set; }


        // Кол-во банкнот разного достоинства в терминале
        protected uint[,] banknoteArray;

        public uint GetBanknoteCount() 
        {
            uint count = 0;
            for (int i = 0; i < banknoteArray.Length/2; i++)
            {
                count += banknoteArray[i, 1];
            }
            return count; 
        }


        public decimal TerminalDepositCommissionPercent { get; set; }
        public decimal TerminalWithdrawCommissionPercent { get; set; }

        // Возможность пополнения счета через терминал (SST) / банкомат (ATM)
        protected bool isDeposit;
        public bool IsDeposit() { return isDeposit; }

        // Возможность снятия денег через банкомат (ATM)
        protected bool isWithdraw;
        public bool IsWithdraw() { return isWithdraw; }

        // Возможность оплатить через терминал (POS)
        protected bool isPay;
        public bool IsPay() { return isPay; }




        public CommonTerminal(Bank owner, uint number)
        {
            Owner = owner;
            TerminalNumber = number;
            Balance = 0;

            banknoteArray = new uint[,] { { 5, 0 }, { 10, 0 }, { 20, 0 }, { 50, 0 }, { 100, 0 }, { 200, 0 }, { 500, 0 }, { 1000, 0 } };

            TerminalDepositCommissionPercent = 0.02m;
            TerminalWithdrawCommissionPercent = 0.02m;

            isDeposit = true;
            isWithdraw = true;
            isPay = true;
        }


        // Если банк окажется жадным
        public virtual decimal TerminalDepositCommission(decimal amount)
        {
            return amount * TerminalDepositCommissionPercent;
        }
        // Если банк окажется жадным
        public virtual decimal TerminalWithdrawCommission(decimal amount)
        {
            return amount * TerminalWithdrawCommissionPercent;
        }








        // Перечисление денег с карты 1 на карту 2 этого БАНКА
        public void Pay(decimal amount, ref CommonCard card1, ref CommonCard card2)
        {
            // Комиссия за использование терминала для оплаты - с карты 1
            decimal commissionTerm = TerminalWithdrawCommission(amount);
            // Комиссия за снятие денег с карты 1
            decimal commissionCard1 = card1.WithdrawCommission(amount + commissionTerm);
            // Комиссия за зачисление денег на карту 2
            decimal commissionCard2 = card2.DepositCommission(amount);

            if (amount <= 0)
            {
                Console.WriteLine("Required: amount > 0");
            }

            if (card1.Balance < amount + commissionCard1 + commissionTerm)
            {
                Console.WriteLine("Not enough money on Card 1");
            }
            if (card2.Balance + amount < commissionCard2)
            {
                Console.WriteLine("Not enough money on Card 2");
            }

            // Выводим с 1-й карты - сумма для перевода + Комиссия за использование терминала
            card1.Withdraw(amount + commissionTerm);

            // Комиссия за использование терминала для оплаты - с карты 1
            Owner.ReceiveFunds(commissionTerm);

            // Пополняем 2-ю карту
            card2.Deposit(amount);
        }


    }
}

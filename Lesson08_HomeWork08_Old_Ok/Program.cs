using System;
using Lesson08_HomeWork08.Terminals;

namespace Lesson08_HomeWork08
{
    class Program
    {
        static void Main(string[] args)
        {
            uint banknote = 0;
            uint summInp = 0;
            uint summReal = 0;


            //---------------------------------------------------------------------------------------------------

            Bank bank = new Bank("GlobalBank", 1_000_000);

            Customer customer = new Customer("Ivan", "Ivanov", 123456789, new Address());

            Console.WriteLine("Создаем карты для клиента");
            CommonCard card1 = bank.EmitCard("sav",  customer);
            CommonCard card2 = bank.EmitCard("plat", customer);
            customer.AddCards(new[] { card1, card2 });

            Console.WriteLine("Депозит + 550, затем вывод - 220");
            card1.Deposit(550);
            card1.Withdraw(220);
            
            card2.Deposit(100);

            Console.WriteLine("Баланс на карте 1 - " + card1.Balance);
            Console.WriteLine();
            Console.ReadKey();


            //---------------------------------------------------------------------------------------------------
            // Создаем в банке терминалы
            Console.WriteLine("Создаем в банке терминалы");
            TerminalSST terminal1 = new TerminalSST(bank, 1001);
            TerminalATM terminal2 = new TerminalATM(bank, 1002);
            TerminalPOS terminal3 = new TerminalPOS(bank, 1003);

            bank.AddTerminal(terminal1);
            bank.AddTerminal(terminal2);
            bank.AddTerminal(terminal3);
            
            Console.WriteLine("Количество терминалов банка - " + bank.GetCountTerminals());
            Console.WriteLine();
            Console.ReadKey();


            //---------------------------------------------------------------------------------------------------
            // Пополняем счет через терминал SST
            Console.WriteLine();
            Console.WriteLine("Пополняем счет через терминал SST без учета купюр");
            Console.WriteLine();

            if (terminal1.IsDeposit())
            {
                Console.WriteLine("Баланс по карте - " + card1.Balance);
                Console.WriteLine("Кол-во денег в терминале (SST) - " + terminal1.Balance);

                Console.WriteLine("Пополняем счет через терминал SST на 200" );
                terminal1.Deposit(1000, ref card1);

                Console.WriteLine("Баланс по карте (после пополнения) - " + card1.Balance);
                Console.WriteLine("Кол-во денег в терминале (SST) - " + terminal1.Balance);
            }
            Console.WriteLine();
            Console.ReadKey();



            //---------------------------------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("Пополняем счет через терминал SST с учетом купюр");
            Console.WriteLine();

            // Пополняем счет через терминал SST
            if (terminal1.IsDeposit())
            {
                Console.WriteLine();
                Console.WriteLine("Баланс по карте - " + card1.Balance);
                Console.WriteLine("Кол-во денег в терминале (SST) - " + terminal1.Balance);
                Console.WriteLine();

                do
                {
                    Console.WriteLine("Введите сумму для пополнения, кратную 5:");
                }
                while (!uint.TryParse(Console.ReadLine(), out summInp) || (summInp <= 0) || (summInp % 5 != 0) );


                // Создадим временный массив вносимых банкнот
                terminal1.InitBanknoteArrayTmp();

                while (summReal < summInp)
                {
                    Console.WriteLine("Введите номинал купюры (введено " + summReal + " из " + summInp + " ):");

                    if (uint.TryParse(Console.ReadLine(), out banknote) && (banknote > 0))
                    {
                        if (terminal1.AddBanknote(banknote))
                        {
                            summReal += banknote;
                        }
                    }
                }

                // Введенная сумма банкнот больше установленной для пополнения - пополняем счет
                if (summReal >= summInp)
                {
                    terminal1.Deposit(summReal, ref card1);
                    terminal1.AddBanknoteFinish();
                }
                else
                {
                    terminal1.InitBanknoteArrayTmp();
                }

                Console.WriteLine("Баланс по карте (после пополнения) - " + card1.Balance);
                Console.WriteLine("Кол-во денег в терминале (SST) - " + terminal1.Balance);
            }
            Console.WriteLine();
            Console.ReadKey();



            //---------------------------------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("Снимаем деньги через банкомат (ATM)");
            Console.WriteLine();

            // Снимаем деньги через банкомат
            if (terminal2.IsWithdraw())
            {
                Console.WriteLine("Баланс по карте - " + card1.Balance);
                Console.WriteLine("Кол-во денег в банкомате (ATM) - " + terminal2.Balance);

                Console.WriteLine("Снимаем денег - 100");
                terminal2.Withdraw(100, ref card1);

                Console.WriteLine("Баланс по карте (после снятия) - " + card1.Balance);
                Console.WriteLine("Кол-во денег в банкомате (ATM) - " + terminal2.Balance);
            }
            Console.WriteLine();
            Console.ReadKey();
















            //---------------------------------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("Снимаем деньги через банкомат (ATM) с учетом НАЛИЧИЯ в банкомате купюр");
            Console.WriteLine();

            bool correctOperator = false;

            do
            {
                Console.WriteLine("Введите сумму для снятия c карты 1:");

                if (uint.TryParse(Console.ReadLine(), out summInp) && (summInp > 0))
                {
                    if (card1.Balance + card1.WithdrawCommission(summInp) + terminal2.TerminalWithdrawCommission(summInp) < summInp)
                    {
                        Console.WriteLine("Not enough money");
                    }
                    else
                    {
                        correctOperator = true;
                    }
                }
            }
            while (!correctOperator);


            Console.WriteLine("Баланс по карте - " + card1.Balance);
            Console.WriteLine("Кол-во денег в банкомате (ATM) - " + terminal2.Balance);

            if (terminal2.IsWithdraw(summInp))
                {
                    // Выданные банкноты
                    uint[,] banknoteArrayTmp = terminal2.GetBanknoteArrayTmp();

                    terminal2.Withdraw(summInp, ref card1);

                    Console.WriteLine("Баланс по карте (после снятия) - " + card1.Balance);
                    Console.WriteLine("Кол-во денег в банкомате (ATM) - " + terminal2.Balance);

                    Console.WriteLine("Выданные банкноты:");

                    for (int i = 0; i < banknoteArrayTmp.Length / 2; i++)
                    {
                        if (banknoteArrayTmp[i, 1] > 0)
                        {
                        Console.WriteLine("Банкнота " + banknoteArrayTmp[i, 0] + " - " + banknoteArrayTmp[i, 1] + " шт.");
                        }
                    }
                }
            else
                {
                    Console.WriteLine("Снятие указанной суммы невозможно");
                }

            Console.WriteLine();
            Console.ReadKey();





            //---------------------------------------------------------------------------------------------------
            Console.WriteLine();
            Console.WriteLine("Перечисление денег с карты 1 на карту 2 этого БАНКА");
            Console.WriteLine("Баланс по карте 1 - " + card1.Balance);
            Console.WriteLine("Баланс по карте 2 - " + card2.Balance);

            do
            {
                Console.WriteLine("Введите сумму для перечисления:");
            }
            while (!uint.TryParse(Console.ReadLine(), out summInp) || (summInp <= 0));

            terminal3.Pay(summInp, ref card1, ref card2);

            Console.WriteLine("Состояние карт после перечисление денег с карты 1 на карту 2 этого БАНКА");
            Console.WriteLine("Баланс по карте 1 - " + card1.Balance);
            Console.WriteLine("Баланс по карте 2 - " + card2.Balance);
            Console.WriteLine();


            Console.ReadKey();

        }
    }
}
 
using System;

using Lesson08_HomeWork08.CardSystem;
using Lesson08_HomeWork08.CardSystem.Specific;
using Lesson08_HomeWork08.Terminals;

namespace Lesson08_HomeWork08
{
    public class Bank
    {
        public string Name { get; set; }
        public long CardsEmitted { get; set; }
        public decimal Funds { get; set; }

        // Массив терминалов/банкоматов банка
        public CommonTerminal[] Terminals { get; set; }
        public uint GetCountTerminals () { return (uint) Terminals.Length; }

        public Bank(string name, decimal funds)
        {
            Name = name;
            Funds = funds;
            Terminals = new CommonTerminal[0];
        }

        public void ReceiveFunds(decimal commission)
        {
            Funds += commission;
        }

        public CommonCard EmitCard(string cardType, Customer customer)
        {
            CommonCard card;
            switch (cardType)
            {
                case "sav":
                    card = new SavingsCard(Guid.NewGuid().ToString(), new CardSecurity(), DateTime.Now.AddYears(5), customer, this);
                    break;
                case "univ":
                    card = new UniversalCard(Guid.NewGuid().ToString(), new CardSecurity(), DateTime.Now.AddYears(5), customer, this);
                    break;
                case "plat":
                    card = new PlatinumCard(Guid.NewGuid().ToString(), new CardSecurity(), DateTime.Now.AddYears(5), customer, this);
                    break;
                default: throw new ArgumentException("Wrong card type");
            }
            CardsEmitted++;
            return card;
        }


        public void AddTerminal(CommonTerminal terminal)
        {
            CommonTerminal[] newTerminalArray = new CommonTerminal [Terminals.Length + 1];
            for (int i = 0; i < Terminals.Length; i++)
            {
                newTerminalArray[i] = Terminals[i];
            }
            newTerminalArray[Terminals.Length] = terminal;
            Terminals = newTerminalArray;
        }

        public void AddTerminals(CommonTerminal[] newTerminals)
        {
            CommonTerminal[] newTerminalArray = new CommonTerminal[Terminals.Length + newTerminals.Length];
            for (int i = 0; i < Terminals.Length; i++)
            {
                newTerminalArray[i] = Terminals[i];
            }
            for (int i = 0; i < newTerminals.Length; i++)
            {
                newTerminalArray[Terminals.Length + i] = newTerminals[i];
            }
            Terminals = newTerminalArray;
        }


    }
}

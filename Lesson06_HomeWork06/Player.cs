using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson06_HomeWork06
{
    public class Player
    {
        private char playerValue;                           // Символ, картинка
        private string playerName;                          // Имя игрока

        public ConsoleColor PlayerColor { get; set; }       // Цвет символа / игрока

        public int XPos { get; set; }                       // Позиция X на поле, карте
        public int YPos { get; set; }                       // Позиция Y на поле, карте
        public int Score { get; set; }                      // Количество набраных очков
        public int Helth { get; set; }                      // Количество "здоровья": 1-100 %
        public string EMail { get; set; }                   // E-mail игрока
        public bool IsAlive { get; set; }                   // Признак "жизни" игрока
        public bool IsFriend { get; set; }                  // Признак свой-чужой для командной игры или обозначения врага

        // ??? Нужно ли создавать отдельный класс Enemy ??? 
        // Можно сделать объект enemy класса Player со свойством IsFriend = false

        public char PlayerValue
        {
            get { return playerValue; }
            set { playerValue = value; }
        }

        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }


        public void SetPosition(int x, int y)
        {
            XPos = x;
            YPos = y;
        }

        public Player()
        {
            PlayerValue = '☻';
            PlayerColor = ConsoleColor.Green;
            PlayerName = "DefaultUser";
            XPos = 0;
            YPos = 0;
            Score = 0;
            Helth = 100;
            IsAlive = true;
            IsFriend = true;
        }

        public Player(char element)
        {
            PlayerValue = element;
            PlayerColor = ConsoleColor.Green;
            PlayerName = "DefaultUser";
            XPos = 0;
            YPos = 0;
            Score = 0;
            Helth = 100;
            IsAlive = true;
            IsFriend = true;
        }

        public Player(char element, string name)
        {
            PlayerValue = element;
            PlayerColor = ConsoleColor.Green;
            PlayerName = name;
            XPos = 0;
            YPos = 0;
            Score = 0;
            Helth = 100;
            IsAlive = true;
            IsFriend = true;
        }

    }
}

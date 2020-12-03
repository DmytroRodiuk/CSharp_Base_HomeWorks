using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson07_HomeWork07
{
    public class GamePerson
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public CharacterClass Class { get; set; }
        public bool Gender { get; set; }


        public bool IsAlive { get; set; }                   // Признак "жизни"
        public bool IsFriend { get; set; }                  // Признак свой-чужой для командной игры или обозначения врага


        public int XPos { get; set; }                       // Позиция X на поле, карте
        public int YPos { get; set; }                       // Позиция Y на поле, карте
        public int Score { get; set; }                      // Количество набраных очков
        public ConsoleColor Color { get; set; }             // Цвет символа / игрока

        private char image;                                 // Символ, картинка
        public char Image
        {
            get { return image; }
            set { image = value; }
        }


        public int Health { get; set; }
        public int Mana { get; set; }
        public uint Level { get; set; }
        public int Money { get; set; }

        public Armor Armor { get; set; }
        public Helmet Helmet { get; set; }
        public Weapon Weapon { get; set; }



        public void SetPosition(int x, int y)
        {
            XPos = x;
            YPos = y;
        }


    }
}

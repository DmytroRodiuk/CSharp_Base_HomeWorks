using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson06_HomeWork06
{
    public class Enemy : Player
    {

        private string weaponType;

        public Enemy()
        {
            PlayerValue = '@';
            PlayerColor = ConsoleColor.Yellow;
            PlayerName = "DefaultEnemy";
            XPos = 0;
            YPos = 0;
            Score = 0;
            Helth = 100;
            IsAlive = true;
            IsFriend = false;
        }

        public Enemy(char element) : base (element)
        {
            PlayerValue = element;
            PlayerColor = ConsoleColor.Yellow;
            PlayerName = "DefaultEnemy";
            XPos = 0;
            YPos = 0;
            Score = 0;
            Helth = 100;
            IsAlive = true;
            IsFriend = false;
        }

        public Enemy(char element, string name) : base(element, name)
        {
            PlayerValue = element;
            PlayerColor = ConsoleColor.Yellow;
            PlayerName = name;
            XPos = 0;
            YPos = 0;
            Score = 0;
            Helth = 100;
            IsAlive = true;
            IsFriend = false;
        }

        public string WeaponType
        {
            get { return weaponType; }
            set { weaponType = value; }
        }



    }
}

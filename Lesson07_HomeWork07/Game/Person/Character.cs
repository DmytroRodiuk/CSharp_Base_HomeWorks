using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson07_HomeWork07
{
    public class Character : GamePerson
    {
        public User Owner { get; set; }
        public Inventory Inventory { get; set; }

        public Character(string name, string race, CharacterClass @class, bool gender, User user)
        {
            Name = name;
            Race = race;
            Class = @class;
            Gender = gender;
            Owner = user;

            Inventory = new Inventory();

            Image = ' ';

            XPos = 0;
            YPos = 0;
            Score = 0;
            Health = 100;

            IsAlive = true;
            IsFriend = true;
        }

        public Character()
        {
            Name = "Default";
            Race = "White";
            Class = new CharacterClass();
            Gender = true;
            Owner = new User();

            Inventory = new Inventory();

            Image = ' ';

            XPos = 0;
            YPos = 0;
            Score = 0;
            Health = 100;

            IsAlive = true;
            IsFriend = false;
        }


        public uint InventoryItemsCount(string nameInventoryItem)
        {
            uint count = Inventory.InventoryItemsCount(nameInventoryItem);

            if (nameInventoryItem == "Armor")  count += (Armor  != null) ? 1 : 0;
            if (nameInventoryItem == "Helmet") count += (Helmet != null) ? 1 : 0;
            if (nameInventoryItem == "Weapon") count += (Weapon != null) ? 1 : 0;

            return count; 
        }



    }
}

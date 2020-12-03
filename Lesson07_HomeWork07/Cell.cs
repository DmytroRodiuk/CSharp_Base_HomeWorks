using System;
using System.Collections.Generic;

namespace Lesson07_HomeWork07
{
    public class Cell
    {
        private char initValue;
        private char cellValue;
        private Character cellObject;

        public char CellValue
        {
            get { return cellValue; }
            set { cellValue = value; }
        }

        public Character GetObject
        {
            get { return cellObject; }
        }

        public int InMapPositionX { get; }
        public int InMapPositionY { get; }


        public bool CanMove { get; set; }
        public bool IsPlayerKeeper { get; set; }
        public bool IsEnemyKeeper { get; set; }

        public Cell(int x, int y)
        {
            initValue = ' ';

            InMapPositionX = x;
            InMapPositionY = y;

            if (x == 1 && y == 1)
            {
                CanMove = true;
            }
            else
            {
                GenerateCellValue();
            }
        }

        public void GenerateCellValue()
        {
            int randValue = new Random().Next(0, 10);

            // # - 1 - Wall
            // H - 3 - Your helth
            // M - 4 - Mine
            // ☻ - 7 - Your ENEMY
            // A - 5 - Armor
            // W - 6 - Weapon

            CellValue = (randValue == 1) ? '#' : (randValue == 3) ? 'H' : (randValue == 4) ? 'M' : (randValue == 5) ? 'A' : (randValue == 6) ? 'W' : initValue;

            if (randValue == 7)
            {
                Character enemy = new Character();
                enemy.Image = '☻'; //  '@';    '☺' - ok  ☻ ↑
                enemy.Color = ConsoleColor.Yellow;
                enemy.Name = "DefaultEnemy";

                SetEnemy(enemy);
                CanMove = true;
            }
            else
            {
                CanMove = randValue != 1;
            }
        }


        public void SetPlayer(Character player)
        {
            if (CanMove)
            {
                IsEnemyKeeper = false;
                IsPlayerKeeper = true;
                CellValue = player.Image;
                cellObject = player;
            }
            else
            {
                throw new Exception("CanMove = false");
            }
        }

        public void SetEnemy(Character enemy)
        {
            if (!IsPlayerKeeper)
            {
                IsEnemyKeeper = true;
                CellValue = enemy.Image;
                cellObject = enemy;
            }
            else
            {
                throw new Exception("The cell is occupied by the player");
            }
        }

        public void Reset()
        {
            IsPlayerKeeper = false;
            IsEnemyKeeper = false;
            CellValue = initValue;
            CanMove = true;
            cellObject = null;
        }

        public override string ToString()
        {
            if (GetObject == null)
            {
                return $" {CellValue} ";
            }
            else
            {
                return $"{((GetObject.Armor != null) ? "A" : " ") + cellValue + ((GetObject.Weapon != null) ? "W" : " ")}";
            }
        }
    }
}

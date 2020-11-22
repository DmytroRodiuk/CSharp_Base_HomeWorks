using System;
using System.Collections.Generic;

namespace Lesson06_HomeWork06
{
    public class Cell
    {
        private char initValue;
        private char cellValue;
        private Player cellObject;

        public char CellValue
        {
            get { return cellValue; }
            set { cellValue = value; }
        }

        public Player GetObject
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
            CellValue = (randValue == 1) ? '#' : (randValue == 2) ? 'H' : (randValue > 3 && randValue < 9) ? 'M' : initValue;
            //            CellValue = (randValue == 1) ? '#' : (randValue == 2) ? 'H' : (randValue == 3) ? '@' : (randValue > 3 && randValue < 9) ? 'M' : initValue;

            if (randValue == 3)
            {
                SetEnemy(new Enemy());
                CanMove = false;
            }
            else
            {
                CanMove = randValue != 1;
            }
        }


        public void SetPlayer(Player player)
        {
            if (CanMove)
            {
                IsPlayerKeeper = true;
                CellValue = player.PlayerValue;
                cellObject = player;
            }
            else
            {
                throw new Exception("CanMove = false");
            }
        }

        public void SetEnemy(Enemy enemy)
        {
            if (!IsPlayerKeeper)
            {
                IsEnemyKeeper = true;
                CellValue = enemy.PlayerValue;
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
            CellValue = initValue;
            CanMove = true;
        }

        public override string ToString()
        {
            return $" {CellValue} ";
        }
    }
}

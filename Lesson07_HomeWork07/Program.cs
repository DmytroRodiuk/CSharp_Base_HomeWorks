using System;

namespace Lesson07_HomeWork07
{
    class Program
    {
        static Cell[,] Map = new Cell[15, 15];
        static uint turnCount = 0;
        static uint mineCount = 0;

        static Character myPlayer = new Character("Character1", "White", new CharacterClass(), true, new User());


        // Если у игрока есть оружие: при попытке занять позицию врага он бъет врага, но теряет оружие и переходит на позицию врага.
        // При этом, если у игрока есть запас оружия в Inventory - он пополняет его ("берет в руки").
        // Если у игрока нет оружия:
        //  Если у игрока есть броня - при столкновении с врагом игрок теряет броню, но сохраняет здоровье и остается на своей позиции.
        //      При этом, если у игрока есть запас брони в Inventory - он пополняет его ("берет в руки").
        //          Если у игрока нет оружия и брони - при столкновении с врагом игрок теряет здоровье (-10) и остается на своей позиции.



        static void Main(string[] args)
        { 
            myPlayer.Image = '☺';
            myPlayer.Color = ConsoleColor.Green;



            GenerateMap();
            // set player to init position
            myPlayer.SetPosition(1,1);

            Map[myPlayer.XPos, myPlayer.YPos].SetPlayer(myPlayer);

            // Prize !!!!
            Map[14, 14].Reset();
            Map[14, 14].CellValue = 'P';

            RenderMap();

            while (myPlayer.IsAlive)
            {
                turnCount++;
                bool isInputSuccess;

                do
                {
                    ConsoleKey key = Console.ReadKey().Key;
                    isInputSuccess = true;

                    switch (key)
                    {
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            {
                                if (IsPositionAvailable(0, -1))
                                {
                                    SetPlayerToPosition(0, -1);
                                }
                                else
                                {
                                    Console.WriteLine("Position is unavailable");
                                    isInputSuccess = false;
                                }
                                break;
                            }
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            {

                                if (IsPositionAvailable(-1, 0))
                                {
                                    SetPlayerToPosition(-1, 0);
                                }
                                else
                                {
                                    Console.WriteLine("Position is unavailable");
                                    isInputSuccess = false;
                                }
                                break;
                            }
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            {

                                if (IsPositionAvailable(0, 1))
                                {
                                    SetPlayerToPosition(0, 1);
                                }
                                else
                                {
                                    Console.WriteLine("Position is unavailable");
                                    isInputSuccess = false;
                                }
                                break;
                            }
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            {

                                if (IsPositionAvailable(1, 0))
                                {
                                    SetPlayerToPosition(1, 0);
                                }
                                else
                                {
                                    Console.WriteLine("Position is unavailable");
                                    isInputSuccess = false;
                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Wrong key, use \"W,A,S,D\"");
                                isInputSuccess = false;
                                break;
                            }
                    }
                }
                while (!isInputSuccess);

                MotionEnemy();

                RenderMap();

            }
        }

        static void GenerateMap()
        {
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int k = 0; k < Map.GetLength(1); k++)
                {
                    Map[i, k] = new Cell(i, k);
                }
            }
        }

        static void RenderMap()
        {
            Console.Clear();
            Console.WriteLine($"Turn count:\t{turnCount}");
            Console.WriteLine($"H - Your helth:\t\t{myPlayer.Health}%");
            Console.WriteLine($"M - Mine count:\t\t{mineCount}");
            Console.WriteLine($"W - Weapon count:\t{myPlayer.InventoryItemsCount("Weapon")}");
            Console.WriteLine($"A - Armor count:\t{myPlayer.InventoryItemsCount("Armor")}");
            Console.WriteLine($"☻ - Your ENEMY");
            Console.WriteLine($"P - Your PRIZE");

            for (int i = 0; i < Map.GetLength(0); i++)
            {
                Console.WriteLine(new string('-', Map.GetLength(1) * 4 + 1));
                Console.Write("|");
                for (int k = 0; k < Map.GetLength(1); k++)
                {
                    if (Map[i, k].CellValue == 'P')            // Prize
                    {
                        ToConsole(Map[i, k].ToString(), ConsoleColor.Red);
                        Console.Write("|");
                    }
                    else if (Map[i, k].IsPlayerKeeper || Map[i, k].IsEnemyKeeper)
                    {
                        ToConsole(Map[i, k].ToString(), Map[i, k].GetObject.Color);
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write($"{Map[i, k]}|");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', Map.GetLength(1) * 4 + 1));


            // Выигрыш !!! 
            if (myPlayer.XPos == Map.GetLength(0) - 1 && myPlayer.YPos == Map.GetLength(1) - 1)
            {
                Console.WriteLine("Game over! You are winner!");
                Console.WriteLine("Game over! You are winner!");
                Console.WriteLine("Game over! You are winner!");
                Console.WriteLine("Press any key....");
                Console.ReadKey();

                // Заканчиваем игру
                myPlayer.IsAlive = false;
            }
            else
            {
                Console.WriteLine($"XPos:{myPlayer.XPos}, YPos:{myPlayer.YPos}");
            }

        }

        /// <summary>
        /// Use before calling SetPlayerToPosition
        /// </summary>
        /// <param name="mDelta"></param>
        /// <param name="nDelta"></param>
        /// <returns></returns>
        static bool IsPositionAvailable(int xDelta, int yDelta)
        {
            bool isInBounds = true;

            int newPosX = myPlayer.XPos + xDelta;
            int newPosY = myPlayer.YPos + yDelta;

            if (myPlayer.XPos + xDelta < 0 || myPlayer.XPos + xDelta >= Map.GetLength(0) ||
                myPlayer.YPos + yDelta < 0 || myPlayer.YPos + yDelta >= Map.GetLength(1))
            {
                isInBounds = false;
            }

            return isInBounds && Map[newPosX, newPosY].CanMove;
        }


        static bool IsPositionMap(int xDelta, int yDelta)
        {
            bool isInBounds = true;

            int newPosX = myPlayer.XPos + xDelta;
            int newPosY = myPlayer.YPos + yDelta;

            if (myPlayer.XPos + xDelta < 0 || myPlayer.XPos + xDelta >= Map.GetLength(0) ||
                myPlayer.YPos + yDelta < 0 || myPlayer.YPos + yDelta >= Map.GetLength(1))
            {
                isInBounds = false;
            }

            return isInBounds;
        }


        /// <summary>
        /// Only for move actions, Exception if !IsPositionAvailable
        /// </summary>
        /// <param name="mDelta"></param>
        /// <param name="nDelta"></param>
        static void SetPlayerToPosition(int xDelta, int yDelta)
        {
            if (IsPositionAvailable(xDelta, yDelta))
            {
                int newPosX = myPlayer.XPos + xDelta;
                int newPosY = myPlayer.YPos + yDelta;

                // Если на новой позиции враг
                if (Map[newPosX, newPosY].IsEnemyKeeper)
                {
                    // Если у игрока есть оружие: при попытке занять позицию врага он бъет врага, но теряет оружие и переходит на позицию врага.
                    // При этом, если у игрока есть запас оружия в Inventory - он пополняет его ("берет в руки").
                    // Если у игрока нет оружия:
                    //  Если у игрока есть броня - при столкновении с врагом игрок теряет броню, но сохраняет здоровье и остается на своей позиции.
                    //      При этом, если у игрока есть запас брони в Inventory - он пополняет его ("берет в руки").
                    //          Если у игрока нет оружия и брони - при столкновении с врагом игрок теряет здоровье (-10) и остается на своей позиции.

                    if (myPlayer.Weapon != null)
                    {
                        if (myPlayer.Inventory.isExistItem("Weapon"))
                            myPlayer.Inventory.RemoveInventoryItem("Weapon");
                        else
                            myPlayer.Weapon = null;
                    }
                    else 
                    {
                        if (myPlayer.Armor != null)
                        {
                            if (myPlayer.Inventory.isExistItem("Armor"))
                                myPlayer.Inventory.RemoveInventoryItem("Armor");
                            else
                                myPlayer.Armor = null;
                        }
                        else
                        {
                            if (myPlayer.Health < 10)
                            {
                                // Заканчиваем игру
                                myPlayer.IsAlive = false;

                                Console.WriteLine("Game over! Your are loser!");
                                Console.WriteLine("Press any key....");
                                Console.ReadKey();
                            }
                            else
                            {
                                myPlayer.Health -= 10;
                            }
                        }
                        return;
                    }
                }
                // Увеличиваем "здоровье"
                else if (Map[newPosX, newPosY].CellValue == 'H' && myPlayer.Health < 100)
                {
                    myPlayer.Health += 2;
                }
                // Получаем броню - Armor
                else if (Map[newPosX, newPosY].CellValue == 'A')
                {
                    Armor newArmor = new Armor();
                    newArmor.Name = "Armor";

                    // Если Armor в руках - добавим еще один экземпляр (на запас - потом пригодится) в список инвентаря
                    if (myPlayer.Armor != null)
                    {
                        myPlayer.Inventory.AddInventoryItem(newArmor);
                    }
                    else
                    {
                        myPlayer.Armor = newArmor;
                    }
                }
                // Получаем оружие - Weapon
                else if (Map[newPosX, newPosY].CellValue == 'W')
                {
                    Weapon newWeapon = new Weapon();
                    newWeapon.Name = "Weapon";

                    // Если Weapon в руках - добавим еще один экземпляр (на запас - потом пригодится) в список инвентаря
                    if (myPlayer.Weapon != null)
                    {
                        myPlayer.Inventory.AddInventoryItem(newWeapon);
                    }
                    else
                    {
                        myPlayer.Weapon = newWeapon;
                    }
                }
                // Наступили на "мину" 
                else if (Map[newPosX, newPosY].CellValue == 'M')
                {
                    mineCount++;
                    if (myPlayer.Health < 5)
                    {
                        // Заканчиваем игру
                        myPlayer.IsAlive = false;

                        Console.WriteLine("Game over! Your are loser!");
                        Console.WriteLine("Press any key....");
                        Console.ReadKey();
                    }
                    else
                    {
                        myPlayer.Health -= 5;
                    }
                }

                Map[myPlayer.XPos, myPlayer.YPos].Reset();
                Map[newPosX, newPosY].SetPlayer(myPlayer);

                myPlayer.XPos = newPosX;
                myPlayer.YPos = newPosY;
            }
        }



        static bool IsEnemyMotionAvailable(int newPosX, int newPosY)
        {
            bool isInBounds = true;

            if (newPosX < 0 || newPosX >= Map.GetLength(0) || newPosY < 0 || newPosY >= Map.GetLength(1))
            {
                isInBounds = false;
            }

            //return isInBounds && Map[newPosX, newPosY].CanMove && !Map[newPosX, newPosY].IsPlayerKeeper && !Map[newPosX, newPosY].IsEnemyKeeper && Map[newPosX, newPosY].CellValue != 'P';
            return isInBounds && Map[newPosX, newPosY].CellValue == ' ';
        }

        static void MotionEnemy()
        {
            int direction;
            Cell tmpCell;

            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int k = 0; k < Map.GetLength(1); k++)
                {
                    if (Map[i, k].IsEnemyKeeper)
                    {
                        direction = new Random().Next(0, 4);

                        switch (direction)
                        {
                            case 1:     // вверх
                                {
                                    if (IsEnemyMotionAvailable(i, k - 1))
                                    {
                                        tmpCell = Map[i, k - 1];
                                        Map[i, k - 1] = Map[i, k];
                                        Map[i, k] = tmpCell;
                                    }
                                    break;
                                }
                            case 2:      // влево
                                {
                                    if (IsEnemyMotionAvailable(i - 1, k))
                                    {
                                        tmpCell = Map[i - 1, k];
                                        Map[i - 1, k] = Map[i, k];
                                        Map[i, k] = tmpCell;
                                    }
                                    break;
                                }
                            case 3:      // вправо
                                {
                                    if (IsEnemyMotionAvailable(i + 1, k))
                                    {
                                        tmpCell = Map[i + 1, k];
                                        Map[i + 1, k] = Map[i, k];
                                        Map[i, k] = tmpCell;
                                    }
                                    break;
                                }
                            default:      // вниз
                                {
                                    if (IsEnemyMotionAvailable(i, k + 1))
                                    {
                                        tmpCell = Map[i, k + 1];
                                        Map[i, k + 1] = Map[i, k];
                                        Map[i, k] = tmpCell;
                                    }
                                    break;
                                }
                        }
                    }
                    else
                    {
                    }
                }
            }
        }



        public static void ToConsole(string str, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ResetColor();
        }



    }
}

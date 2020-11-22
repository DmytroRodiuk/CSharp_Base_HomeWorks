using System;

namespace Lesson06_HomeWork06
{
    class Program
    {
        static Player myPlayer = new Player('☻');
        static Cell[,] Map = new Cell[15, 15];
        static int turnCount = 0;
        static int mineCount = 0;

        static void Main(string[] args)
        {
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
            Console.WriteLine($"H - Your helth:\t{myPlayer.Helth}%");
            Console.WriteLine($"M - Mine count:\t{mineCount}");
            Console.WriteLine($"@ - Your ENEMY");
            Console.WriteLine($"P - Your PRIZE");

            for (int i = 0; i < Map.GetLength(0); i++)
            {
                Console.WriteLine(new string('-', Map.GetLength(1) * 4 + 1));
                Console.Write("|");
                for (int k = 0; k < Map.GetLength(1); k++)
                {
                    if (Map[i, k].IsPlayerKeeper || Map[i, k].IsEnemyKeeper)
                    {
                        ToConsole(Map[i, k].ToString(), Map[i, k].GetObject.PlayerColor);
                        Console.Write("|");
                    }
                    else if (Map[i, k].CellValue == 'P')            // Prize
                    {
                        ToConsole(Map[i, k].ToString(), ConsoleColor.Red);
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

                // Увеличиваем "здоровье"
                if (Map[newPosX, newPosY].CellValue == 'H' && myPlayer.Helth < 100)
                {
                    myPlayer.Helth++;
                }
                // Наступили на "мину" 
                else if (Map[newPosX, newPosY].CellValue == 'M')
                {
                    mineCount++;
                    if (myPlayer.Helth < 5)
                    {
                        // Заканчиваем игру
                        myPlayer.IsAlive = false;

                        Console.WriteLine("Game over! Your are loser!");
                        Console.WriteLine("Press any key....");
                        Console.ReadKey();
                    }
                    else
                    {
                        myPlayer.Helth -= 5;
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

            return isInBounds && Map[newPosX, newPosY].CanMove && !Map[newPosX, newPosY].IsPlayerKeeper && Map[newPosX, newPosY].CellValue != 'P';
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


        // ----------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------

        static void Task()
        {
            int size = 0;
            bool success = false;
            do
            {
                Console.Write("Enter size: ");
                string input = Console.ReadLine();
                if (!double.TryParse(input, out double number))
                {
                    Console.WriteLine("Not a number!");
                    continue;
                }

                if (number <= 0)
                {
                    Console.WriteLine("Size must be more than 0");
                    continue;
                }

                if (number - (int)number > 0)
                {
                    Console.WriteLine("Only integer!");
                    continue;
                }

                success = true;
                size = (int)number;
                Console.WriteLine();
            }
            while (!success);

            Console.WriteLine("Task 1\n");
            int[,] vs = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < size; k++)
                {
                    vs[i, k] = i >= k ? i + 1 : 0;
                    Console.Write($"{vs[i, k]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Task 2\n");
            int[,] vs1 = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int k = 0; k < size; k++)
                {
                    vs[i, k] = i >= k ? (i + 1) * (k + 1) : 0;
                    Console.Write($"{vs[i, k]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Recursion(params int[] array)
        {
            if (array.Length > 1)
            {
                int[] newLine = new int[array.Length - 1];
                for (int i = 0; i < newLine.Length; i++)
                {
                    newLine[i] = array[i] + array[i + 1];
                }
                Recursion(newLine);
                foreach (int item in array)
                {
                    Console.Write($"{item}\t");
                }
                Console.WriteLine();
            }
            else if (array.Length == 1)
            {
                Console.WriteLine($"{array[0]}");
            }
            else
            {
                Console.WriteLine("Empty array");
            }
        }
    }
}

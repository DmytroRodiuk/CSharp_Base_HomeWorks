using System;

namespace Lesson05_HomeWork04
{
    class Program
    {
        static void Main(string[] args)
        {

            string userAction;
            bool correctOperator;
            int tmpNum;

            // Размеры матриц
            uint matrix1_X;
            uint matrix1_Y;
            uint matrix2_X;
            uint matrix2_Y;

            int[,] matrix1;
            int[,] matrix2;
            int[,] matrixRez;

            do
            {
                Console.Clear();
                Console.WriteLine("Выберите действие над матрицами:");
                Console.WriteLine("\t1 - Сложение матриц");
                Console.WriteLine("\t2 - Умножение матрицы на число");
                Console.WriteLine("\t3 - Умножение матриц");
                Console.WriteLine("\t4 - Возведение матрицы в степень");
                Console.WriteLine("\t5 - Транспонирование матриц");
                Console.WriteLine("\t6 - Завершить работу");
                userAction = Console.ReadLine();
                correctOperator = true;

                switch (userAction)
                {
                    case "1":
                        {
                            Console.WriteLine("Складывать можно только матрицы одинакового размера!");

                            // Размеры матриц
                            matrix1_X = GetSizeMatrix(1);        // Кол-во строк матрицы
                            matrix1_Y = GetSizeMatrix(2);        // Кол-во столбцов матрицы

                            // Создаем матрицы
                            matrix1 = new int[matrix1_X, matrix1_Y];
                            matrix2 = new int[matrix1_X, matrix1_Y];

                            // Заполняем матрицы
                            Console.WriteLine("Заполняем матрицу A");
                            GetMatrix(ref matrix1);

                            Console.WriteLine("Заполняем матрицу B");
                            GetMatrix(ref matrix2);

                            Console.WriteLine("Матрица A:");
                            PrintMatrix(ref matrix1);
                            Console.WriteLine("Матрица B:");
                            PrintMatrix(ref matrix2);

                            // Сложение матриц
                            matrixRez = MatrixAddition(matrix1, matrix2);

                            Console.WriteLine("Результат сложения матриц:");
                            PrintMatrix(ref matrixRez);

                            break;
                        }
                    case "2":
                        {
                            // Размеры матриц
                            matrix1_X = GetSizeMatrix(1);        // Кол-во строк матрицы
                            matrix1_Y = GetSizeMatrix(2);        // Кол-во столбцов матрицы

                            // Создаем матрицу
                            matrix1 = new int[matrix1_X, matrix1_Y];

                            // Заполняем матрицы
                            Console.WriteLine("Заполняем матрицу");
                            GetMatrix(ref matrix1);

                            Console.WriteLine("Матрица 1:");
                            PrintMatrix(ref matrix1);

                            do
                            {
                                Console.WriteLine("Введите число для умножения матрицы:");
                            }
                            while (!int.TryParse(Console.ReadLine(), out tmpNum));

                            // Умножение матрицы на число
                            matrixRez = MatrixMult(matrix1, tmpNum);

                            Console.WriteLine("Результат умножения матрицы на число:");
                            PrintMatrix(ref matrixRez);

                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Для умноженя матрицы должны быть совместимы!");
                            Console.WriteLine("(число строк матрицы A равно числу столбцов матрицы B)");
                            Console.WriteLine();

                            // Размеры матриц
                            Console.WriteLine("Матрица A:");
                            matrix1_X = GetSizeMatrix(1);        // Кол-во строк матрицы
                            matrix1_Y = GetSizeMatrix(2);        // Кол-во столбцов матрицы
                            Console.WriteLine("Матрица В:");
                            matrix2_X = GetSizeMatrix(1);        // Кол-во строк матрицы
                            matrix2_Y = GetSizeMatrix(2);        // Кол-во столбцов матрицы

                            if (matrix1_X != matrix2_Y && matrix1_Y != matrix2_X)
                            {
                                Console.WriteLine("Ошибка! Для умноженя матрицы должны быть совместимы!");
                                Console.WriteLine("(число строк матрицы A равно числу столбцов матрицы B)");
                                Console.ReadKey();
                                break;
                            }

                            // Создаем матрицы
                            matrix1 = new int[matrix1_X, matrix1_Y];
                            matrix2 = new int[matrix2_X, matrix2_Y];

                            // Заполняем матрицы
                            Console.WriteLine();
                            Console.WriteLine("Заполняем матрицу A");
                            GetMatrix(ref matrix1);

                            Console.WriteLine("Заполняем матрицу B");
                            GetMatrix(ref matrix2);

                            Console.WriteLine("Матрица A:");
                            PrintMatrix(ref matrix1);
                            Console.WriteLine("Матрица B:");
                            PrintMatrix(ref matrix2);

                            // Умножение матриц
                            matrixRez = MatrixMult(matrix1, matrix2);

                            Console.WriteLine();
                            Console.WriteLine("Результат умножения матриц A*B:");
                            PrintMatrix(ref matrixRez);

                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Допускается возводить в степень только квадратные матрицы!");
                            Console.WriteLine("(число строк должно быть равно числу столбцов)");
                            Console.WriteLine();

                            // Размеры матриц
                            Console.WriteLine("Матрица A:");
                            matrix1_X = GetSizeMatrix(1);        // Кол-во строк матрицы

                            // Создаем матрицы
                            matrix1 = new int[matrix1_X, matrix1_X];
                            matrix2 = new int[matrix1_X, matrix1_X];

                            // Заполняем матрицы
                            Console.WriteLine();
                            Console.WriteLine("Заполняем матрицу A");
                            GetMatrix(ref matrix1);

                            Console.WriteLine("Матрица A:");
                            PrintMatrix(ref matrix1);

                            do
                            {
                                Console.WriteLine("Введите степень матрицы:");
                            }
                            while (!int.TryParse(Console.ReadLine(), out tmpNum) || (tmpNum < 0));


                            // Возведение матрицы в степень
                            matrixRez = MatrixSqrt(matrix1, tmpNum);

                            Console.WriteLine();
                            Console.WriteLine("Результат возведения матрицы в степень:");
                            PrintMatrix(ref matrixRez);

                            break;
                        }
                    case "5":
                        {
                            // Размеры матриц
                            matrix1_X = GetSizeMatrix(1);        // Кол-во строк матрицы
                            matrix1_Y = GetSizeMatrix(2);        // Кол-во столбцов матрицы

                            // Создаем матрицы
                            matrix1 = new int[matrix1_X, matrix1_Y];

                            // Заполняем матрицы
                            Console.WriteLine("Заполняем матрицу");
                            GetMatrix(ref matrix1);

                            Console.WriteLine("Матрица A:");
                            PrintMatrix(ref matrix1);

                            // Транспонирование матриц
                            matrixRez = MatrixTransp(matrix1);

                            Console.WriteLine("Результат танспонирования матрицы:");
                            PrintMatrix(ref matrixRez);

                            break;
                        }
                    case "6":
                        {
                            correctOperator = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неправильная операция!");
                            break;
                        }
                }

                if (userAction != "6")
                {
                    Console.WriteLine("Для продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                }

            }
            while (correctOperator);

        }


        // Запрос размеров матриц
        /// <param name="typeLine"></param>
        /// 1 - строки, 2 - столбцы
        static uint GetSizeMatrix(uint typeLine)
        {
            uint newCount;

            do
            {
                Console.WriteLine("Введите количество " + (typeLine == 1 ? "строк":"столбцов") + " матрицы:");
            }
            while (!uint.TryParse(Console.ReadLine(), out newCount));

            return newCount;
        }

        // Заполнение матриц
        static void GetMatrix(ref int[,] matrix)
        {
            // Запрашиваем значения ячеек матрицы
            for (uint i = 0; i < matrix.GetLength(0); i++)
            {
                for (uint j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = GetCellValue(i, j);
                }
            }
        }

        // Запрашиваем значения ячеек матрицы
        static int GetCellValue(uint x, uint y)
        {
            int cellValue;
          
            do
            {
                Console.WriteLine("Введите значение ячейки [" + x + "," + y + "]");
            }
            while (!int.TryParse(Console.ReadLine(), out cellValue));

            return cellValue;
        }

        // Вывод матрицы
        static void PrintMatrix(ref int[,] matrix)
        {
            for (uint i = 0; i < matrix.GetLength(0); i++)
            {
                for (uint j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Сложение матриц
        static int[,] MatrixAddition(int[,] matrix1, int[,] matrix2)
        {
            int[,] matrix3 = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

            for (uint i = 0; i < matrix1.GetLength(0); i++)
            {
                for (uint j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix3[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return matrix3;
        }

        // Умножение матрицы на число
        static int[,] MatrixMult(int[,] matrix1, int tmpNum)
        {
            int[,] matrix3 = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

            for (uint i = 0; i < matrix1.GetLength(0); i++)
            {
                for (uint j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix3[i, j] = matrix1[i, j] * tmpNum;
                }
            }

            return matrix3;
        }

        // Умножение матриц
        static int[,] MatrixMult(int[,] matrix1, int[,] matrix2)
        {
            int[,] matrix3 = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

            for (uint i = 0; i < matrix1.GetLength(0); i++)
            {
                for (uint j = 0; j < matrix2.GetLength(1); j++)
                {
                    int tmpVal = 0;

                    for (uint k = 0; k < matrix1.GetLength(1); k++)
                    {
                            tmpVal = tmpVal + matrix1[i, k] * matrix2[k, j];
                    }

                    matrix3[i, j] = tmpVal;

                }
            }

            return matrix3;
        }

        // Возведение матрицы в степень
        static int[,] MatrixSqrt(int[,] matrix1, int tmpNum)
        {
            int[,] matrix3 = new int[matrix1.GetLength(0), matrix1.GetLength(1)];

            if (tmpNum == 0)
            {
                for (uint i = 0; i < matrix1.GetLength(0); i++)
                {
                    for (uint j = 0; j < matrix1.GetLength(1); j++)
                    {
                        matrix3[i,j] = (i==j) ? 1 : 0;
                    }
                }
            }
            else
            {
                matrix3 = matrix1;

                for (uint i = 2; i <= tmpNum; i++)
                {
                    matrix3 = MatrixMult(matrix1, matrix3);
                }

            }

            return matrix3;
        }

        // Транспонирование матриц
        static int[,] MatrixTransp(int[,] matrix1)
        {
            int[,] matrix3 = new int[matrix1.GetLength(1), matrix1.GetLength(0)];

            for (uint i = 0; i < matrix1.GetLength(0); i++)
            {
                for (uint j = 0; j < matrix1.GetLength(1); j++)
                {
                    matrix3[j, i] = matrix1[i, j];
                }
            }

            return matrix3;
        }

    }
}

using System;

namespace Lesson04_HomeWork03
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Console.WriteLine("Для продолжения нажмите любую клавишу ...");
            Console.ReadKey();
            Console.WriteLine();

            //         Part2_Sample();

            Part2_1();
            Console.WriteLine("Для продолжения нажмите любую клавишу ...");
            Console.ReadKey();
            Console.WriteLine();

            Part2_2();
            Console.WriteLine("Для продолжения нажмите любую клавишу ...");
            Console.ReadKey();
            Console.WriteLine();

            Part2_3();
            Console.WriteLine("Нажмите любую клавишу ...");
            Console.ReadKey();
            Console.WriteLine();
        }

        private static void Part1()
        {
            uint lenMasX;
            uint lenMasY;

            // Запрашиваем размер массива
            do
            {
                Console.WriteLine("Введите размер двумерного массива (X):");
            }
            while (!uint.TryParse(Console.ReadLine(), out lenMasX));

            do
            {
                Console.WriteLine("Введите размер двумерного массива (Y):");
            }
            while (!uint.TryParse(Console.ReadLine(), out lenMasY));

            // Создаем массив
            int[,] array1 = new int[lenMasX, lenMasY];
            Random ran = new Random();

            int valueMax = 0;
            int valueMin = 0;
            int valueSum = 0;

            // Заполняем массив случайными числами
            for (int i = 0; i < lenMasX; i++)
            {
                for (int j = 0; j < lenMasY; j++)
                {
                    array1[i, j] = ran.Next(1,1000);

                    if (array1[i, j] > valueMax) valueMax = array1[i, j];
                    if (array1[i, j] < valueMin) valueMin = array1[i, j];

                    // Сумма для среднего значения
                    valueSum += array1[i, j];
                }
            }

            Console.WriteLine();
            Console.WriteLine("Максимальное\t значение элементов массива: " + valueMax);
            Console.WriteLine("Минимальное\t значение элементов массива: " + valueMin);
            Console.WriteLine("Среднее\t\t значение элементов массива: " + valueSum/(lenMasX*lenMasY));
            Console.WriteLine();
        }

        private static void Part2_Sample()
        {
            uint sizeArr;

            // Запрашиваем размер массива
            do
            {
                Console.WriteLine("Введите размер двумерного массива:");
            }
            while (!uint.TryParse(Console.ReadLine(), out sizeArr));

            // Создаем массив
            int[,] array1 = new int[sizeArr, sizeArr];


            // Заполняем массив числами
            for (int i = 0; i < sizeArr; i++)
            {
                Console.WriteLine("---------------------");
                for (int k = 0; k < sizeArr; k++)
                {
                    array1[i, k] = (i + k) % 2 == 0 ? i + 1 : 0;

                    Console.Write("| " + array1[i, k] + " ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("---------------------");


        }
        private static void Part2_1()
        {
            int sizeArr;

            // Запрашиваем размер массива
            do
            {
                Console.WriteLine("Введите размер двумерного массива:");
            }
            while (!int.TryParse(Console.ReadLine(), out sizeArr) || (sizeArr <= 0));

            // Создаем массив
            int[,] array1 = new int[sizeArr, sizeArr];


            Console.WriteLine( new string ('-', sizeArr*3));

            // Заполняем массив числами
            for (int i = 0; i < sizeArr; i++)
            {
                for (int k = 0; k < sizeArr; k++)
                {
                    // array1[i, k] = ((k >= i) && (k < sizeArr-i)) ? k+1-i : 0;
                    // array1[i, k] = (k <= i) && (k >= sizeArr-i-1) ? k+1 - ((int)sizeArr - i - 1) : 0;
                    // array1[i, k] = (i < sizeArr/2) ?  1: 0;

                    array1[i, k] = (i < sizeArr / 2) ? (((k >= i) && (k < sizeArr - i)) ? k + 1 - i : 0) : ((k <= i) && (k >= sizeArr - i - 1) ? k + 1 - ((int)sizeArr - i - 1) : 0);

                    Console.Write(array1[i, k] < 10 ? " " + array1[i, k] + " " : array1[i, k] + " ");
                }
                Console.WriteLine();
            }
            // Console.WriteLine("---------------------");
            Console.WriteLine(new string('-', sizeArr*3));
        }
        private static void Part2_2()
        {
            int sizeArr;

            // Запрашиваем размер массива
            do
            {
                Console.WriteLine("Введите размер двумерного массива:");
            }
            while (!int.TryParse(Console.ReadLine(), out sizeArr) || (sizeArr <= 0));

            // Создаем массив
            int[,] array1 = new int[sizeArr, sizeArr];

            Console.WriteLine(new string('-', sizeArr * 3));

            // Заполняем массив числами
            for (int i = 0; i < sizeArr; i++)
            {
                for (int k = 0; k < sizeArr; k++)
                {
                    array1[i, k] = (i == 0) || (i == (sizeArr-1)) ? 1 : (k == 0) || (k == (sizeArr - 1)) ? 1 : 0;

                    Console.Write(array1[i, k] < 10 ? " " + array1[i, k] + " " : array1[i, k] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', sizeArr * 3));
        }
        private static void Part2_3()
        {
            int sizeArr;

            // Запрашиваем размер массива
            do
            {
                Console.WriteLine("Введите размер двумерного массива:");
            }
            while (!int.TryParse(Console.ReadLine(), out sizeArr) || (sizeArr <= 0));

            // Создаем массив
            int[,] array1 = new int[sizeArr, sizeArr];

            Console.WriteLine(new string('-', sizeArr * 3));

            // Заполняем массив числами
            for (int i = 0; i < sizeArr; i++)
            {
                for (int k = 0; k < sizeArr; k++)
                {
                    array1[i, k] = (i == k) || (i == sizeArr-k-1) ? 1 : 0;

                    Console.Write(array1[i, k] < 10 ? " " + array1[i, k] + " " : array1[i, k] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', sizeArr * 3));
        }
        
    }
}

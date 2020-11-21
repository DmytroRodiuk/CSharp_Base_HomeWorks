using System;

namespace Lesson05_HomeWork05
{
    class Program
    {
        static void Main(string[] args)
        {
            string userAction;
            bool correctOperator;

            uint sizeMas;
            int[] arrayInp;
            int[] arrayRez;

            do
            {
                Console.WriteLine("Введите размер одномерного массива:");
            }
            while (!uint.TryParse(Console.ReadLine(), out sizeMas) || (sizeMas < 1));

            // Создаем массив
            arrayInp = new int[sizeMas];


            do
            {
                Console.Clear();
                Console.WriteLine("Выберите метод сортировки:");
                Console.WriteLine("\t1 - Сортировка пузырьком \t (Bubble sort)");
                Console.WriteLine("\t2 - Быстрая сортировка \t\t (Quicksort)");
                Console.WriteLine("\t3 - Гномья сортировка \t\t (GnomeSort)");
                Console.WriteLine("\t4 - Сортировка Шелла \t\t (ShellSort)");
                Console.WriteLine("\t5 - Завершить работу");
                userAction = Console.ReadLine();
                correctOperator = true;

                switch (userAction)
                {
                    case "1":
                        {
                            // Заполняем массив
                            InitArray(ref arrayInp);

                            // Вывод неотсортированного массива
                            Console.WriteLine("Неотсортированный массив:");
                            PrintArray(arrayInp);

                            // Сортировка - Bubble sort
                            arrayRez = SortBubble(arrayInp);

                            // Вывод отсортированного массива
                            Console.WriteLine("Отсортированный массив:");
                            PrintArray(arrayRez);

                            break;
                        }
                    case "2":
                        {
                            // Заполняем массив
                            InitArray(ref arrayInp);

                            // Вывод неотсортированного массива
                            Console.WriteLine("Неотсортированный массив:");
                            PrintArray(arrayInp);

                            // Сортировка - QuickSort
                            arrayRez = QuickSort(arrayInp, 0, arrayInp.Length - 1);

                            // Вывод отсортированного массива
                            Console.WriteLine("Отсортированный массив:");
                            PrintArray(arrayRez);

                            break;
                        }
                    case "3":
                        {
                            // Заполняем массив
                            InitArray(ref arrayInp);

                            // Вывод неотсортированного массива
                            Console.WriteLine("Неотсортированный массив:");
                            PrintArray(arrayInp);

                            // Сортировка - GnomeSort
                            arrayRez = GnomeSort(arrayInp);

                            // Вывод отсортированного массива
                            Console.WriteLine("Отсортированный массив:");
                            PrintArray(arrayRez);

                            break;
                        }
                    case "4":
                        {
                            // Заполняем массив
                            InitArray(ref arrayInp);

                            // Вывод неотсортированного массива
                            Console.WriteLine("Неотсортированный массив:");
                            PrintArray(arrayInp);

                            // Сортировка - ShellSort
                            arrayRez = ShellSort(arrayInp);

                            // Вывод отсортированного массива
                            Console.WriteLine("Отсортированный массив:");
                            PrintArray(arrayRez);

                            break;
                        }
                    case "5":
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

                if (userAction != "5")
                {
                    Console.WriteLine("Для продолжения нажмите любую клавишу...");
                    Console.ReadKey();
                }
            }
            while (correctOperator);
        }


        // // Заполняем массив
        static void InitArray(ref int[] array)
        {
            Random random = new Random();

            for (uint i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 100);
            }
        }

        // Вывод массива
        static void PrintArray(int[] array)
        {
            for (uint i = 0; i < array.GetLength(0); i++)
            {
                    Console.Write($"{array[i]}\t");
            }
            Console.WriteLine();
        }

        // Обмен элементов массива
        static void Swap(ref int item1, ref int item2)
        {
            int temp = item1;
            item1 = item2;
            item2 = temp;
        }


        // Сортировка пузырьком
        /// <summary>
        /// За каждый проход элементы последовательно сравниваются попарно и, если порядок в паре неверный, 
        /// выполняется обмен элементов.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static int[] SortBubble(int[] array)
        {
            for (int j = 0; j < array.Length - 1; j++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        // Меняем местами элементы массива
                        Swap(ref array[i + 1], ref array[i]);
                    }
                }
            }

            return array;
        }


        // Быстрая сортировка
        /// <summary>
        /// Выбирается опорный элемент, и массив делится на 2 подмассива: меньших опорного и больших опорного. 
        /// Потом этот алгоритм применяется рекурсивно к подмассивам.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static int[] QuickSort(int[] array, int first, int last)
        {
            int left  = first;                          // левая граница
            int right = last;                           // правая граница
            int middle = array[(first + last) / 2];     // опорный элемент - средний

            while (left <= right)                       // пока границы не сойдутся
            {
                while (array[left] < middle)            // сдвигаем левую границу пока элемент[left] меньше middle
                    left++;
                while (array[right] > middle)           // сдвигаем правую границу пока элемент[right] больше middle
                    right--;

                if (left <= right)                      // меняем элементы [left] и [right] местами 
                {
                    Swap(ref array[left], ref array[right]);
                    left++;
                    right--;
                }
            }

            // Рекурсивно вызываем сортировку для левой и правой части массива
            if (first < right)
                array = QuickSort(array, first, right);
            if (last > left)
                array = QuickSort(array, left, last);

            return array;
        }


        // Гномья сортировка
        /// <summary>
        /// За каждый проход элементы последовательно сравниваются попарно и, если порядок в паре неверный, 
        /// выполняется обмен элементов.
        /// 
        /// Алгоритм находит первую пару элементов массива: если они в правильном порядке - идет дальше, 
        /// если нет (неотсортированы) - меняет их местами и делает шаг назад.
        /// Граничные условия: если нет предыдущего элемента массива, идем вперёд; если нет следующего - заканчиваем.
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static int[] GnomeSort(int[] array)
        {
            var indLeft= 1;
            var indRight = indLeft + 1;

            while (indLeft < array.Length)
            {
                // сравниваем пару элементов массива
                if (array[indLeft - 1] < array[indLeft])        
                {
                    // пара элементов массива в правильном порядке - идем дальше
                    indLeft = indRight;
                    indRight++;
                }
                else
                {
                    // пара элементов массива неотсортирована - меняем их местами
                    Swap(ref array[indLeft - 1], ref array[indLeft]);

                    // и делаем шаг назад
                    indLeft--;
                    if (indLeft == 0)
                    {
                        indLeft = indRight;
                        indRight++;
                    }
                }
            }

            return array;
        }


        // Сортировка Шелла
        /// <summary>
        /// Сначала сравниваются и сортируются между собой значения, стоящие один от другого на некотором расстоянии step. 
        /// После этого процедура повторяется для меньших значений step, 
        /// и завершается сортировка Шелла упорядочиванием элементов при step=1.
        /// 
        /// <param name="array"></param>
        /// <returns></returns>
        static int[] ShellSort(int[] array)
        {
            int j;
            int step = array.Length / 2;

            while (step > 0)
            {
                // Идем по элементам, которые сортируются на определённом шаге step
                for (int i = 0; i < (array.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (array[j] > array[j + step]))
                    {
                        // Меняем элементы местами
                        Swap(ref array[j], ref array[j + step]);

                        j -= step;
                    }
                }
                step = step / 2;
            }

            return array;
        }

    }
}

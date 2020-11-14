using System;

namespace Lesson03_HomeWork02
{
    class Program
    {
        static void Main(string[] args)
        {
            Part12_Digits_of_Number();
            //Part12_Digits_of_Number_with_Array();

            Console.WriteLine("Для продолжения нажмите любую клавишу ...");
            Console.ReadKey();

            Console.WriteLine();
            Part35_Calculator();
        }

        private static void Part12_Digits_of_Number()
        {
            int userNumber;

            do
            {
                Console.WriteLine("Введите 5-значное число:");
            }
            while (!int.TryParse(Console.ReadLine(), out userNumber) || (userNumber < 10000) || (userNumber > 99999));

            /*
            Console.WriteLine("i цифра равна " + 12345 / 10000);
            Console.WriteLine("i цифра равна " + 12345 / 1000 % 10);
            Console.WriteLine("i цифра равна " + 12345 / 100 % 10);
            Console.WriteLine("i цифра равна " + 12345 / 10 % 10);
            Console.WriteLine("i цифра равна " + 12345 % 10);
            */

            int tmpDigit;
            int maxDigit = 0;
            int minDigit = 9;

            for (int i = 1; i <= 5; i++)
            {
                tmpDigit = (int)(userNumber / Math.Pow(10, (5 - i))) % 10;
                Console.WriteLine(i + " цифра равна " + tmpDigit);

                if (tmpDigit > maxDigit) maxDigit = tmpDigit;
                if (tmpDigit < minDigit) minDigit = tmpDigit;
            }

            Console.WriteLine();
            Console.WriteLine("Большая цифра числа равна " + maxDigit);
            Console.WriteLine("Меньшая цифра числа равна " + minDigit);
            Console.WriteLine();
        }
        private static void Part12_Digits_of_Number_with_Array()
        {
            int userNumber;

            do
            {
                Console.WriteLine("Введите 5-значное число:");
            }
            while (!int.TryParse(Console.ReadLine(), out userNumber) || (userNumber < 10000) || (userNumber > 99999));

            int tmpDigit;
            int[] tmpArray = new int[5];

            int maxDigit = 0;
            int minDigit = 9;

            for (int i = 0; i < 5; i++)
            {
                tmpDigit = userNumber % 10;
                userNumber = userNumber / 10;

                tmpArray[i] = tmpDigit;

                if (tmpDigit > maxDigit) maxDigit = tmpDigit;
                if (tmpDigit < minDigit) minDigit = tmpDigit;
            }

            for (int i = 4; i >= 0; i--)
            {
                Console.WriteLine(5-i + " цифра равна " + tmpArray[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Большая цифра числа равна " + maxDigit);
            Console.WriteLine("Меньшая цифра числа равна " + minDigit);
            Console.WriteLine();
        }

        private static void Part35_Calculator()
        {
            Console.WriteLine("Калькулятор: ");

            double number1 = 0;
            double number2 = 0;
            uint nChoice;

            bool parseResult = false;
            string userInput;


            do
            {
                Console.WriteLine();

                while (!parseResult)
                {
                    Console.Write("Введите 1-е число: ");
                    parseResult = double.TryParse(Console.ReadLine(), out number1);
                }

                do
                {
                    Console.Write("Введите 2-е число: ");
                    parseResult = double.TryParse(Console.ReadLine(), out number2);
                }
                while (!parseResult);


                bool correctOperator;

                do
                {
                    Console.Write("Введите операцию (+, - *, /, ^, S - корень 1-го числа): ");
                    userInput = Console.ReadLine();
                    correctOperator = true;

                    switch (userInput)
                    {
                        case "+":
                            Console.WriteLine("Результат - " + (number1 += number2));
                            break;
                        case "-":
                            Console.WriteLine("Результат - " + (number1 -= number2));
                            break;
                        case "*":
                            Console.WriteLine("Результат - " + (number1 *= number2));
                            break;
                        case "/":
                            if (number2 == 0)
                            {
                                Console.WriteLine("Неправильная операция - деление на НОЛЬ!");
                                correctOperator = false;
                            }
                            else
                                Console.WriteLine("Результат - " + (number1 /= number2));
                            break;
                        case "^":
                            Console.WriteLine("Результат - " + (number1 = Math.Pow(number1, number2)));
                            break;
                        case "S":
                            Console.WriteLine("Результат - " + (number1 = Math.Sqrt(number1)));
                            break;
                        default:
                            Console.WriteLine("Invalid operation!");
                            correctOperator = false;
                            break;
                    }

                }
                while (!correctOperator);


                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Для продолжения введите: ");
                    Console.WriteLine("     1 - новое вычисление (повтор прошлого цикла);");
                    Console.WriteLine("     2 - выход из программы;");
                    Console.WriteLine("     3 - продолжение работы с предыдущим результатом (в виде первого числа).");
                    parseResult = uint.TryParse(Console.ReadLine(), out nChoice);
                }
                while (!parseResult || (nChoice == 0) || (nChoice > 3));

                switch (nChoice)
                {
                    case 1:
                        number1 = 0;
                        number2 = 0;
                        parseResult = false;
                        break;
                    case 3:
                        parseResult = true;
                        break;
                    default:
                        return;
                }

            }
            while (true);

        }
    }
}

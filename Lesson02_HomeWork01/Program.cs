using System;
using System.Text.RegularExpressions;

namespace Lesson02_HomeWork01
{
    class Program
    {
        static void Main(string[] args)
        {

            Part1();
            Part2();
            Part34();

            Console.WriteLine("Enter any key ...");
            Console.ReadKey();
        }

        private static void Part1()
        {
            string studentName;

            Console.WriteLine("Enter name student :");
            studentName = Console.ReadLine();
            Console.WriteLine("Hello " + studentName + " !");
        }

        private static void Part2()
        {
            Console.WriteLine("Solution of quadratic equation (Ax^2+Bx+C=0)");

            Console.WriteLine("Enter 1 argument (A):");
            bool success1 = int.TryParse(Console.ReadLine(), out int argA);
            Console.WriteLine("Enter 2 argument (B):");
            bool success2 = int.TryParse(Console.ReadLine(), out int argB);
            Console.WriteLine("Enter 3 argument (C):");
            bool success3 = int.TryParse(Console.ReadLine(), out int argC);


            if (success1 && success2 && success3)
            {
                // Найти дискриминант
                double discr = Math.Pow(argB, 2) - 4 * argA * argC;
                Console.WriteLine("Discriminant = " + discr);

                // Если дискриминант меньше нуля, то уравнение не имеет корней. 
                // Если равен нулю, то корень один, больше нуля - два корня.

                if (discr < 0)
                {
                    Console.WriteLine("Equation haven't solution");
                }
                else if (discr == 0)
                {
                    // 1, 12, 36
                    //double x1 = (-argB + Math.Sqrt(discr)) / (2 * argA);
                    double x1 = -argB / (2 * argA);
                    Console.WriteLine("x1 = " + x1);
                }
                else
                {
                    // 7, 1, -6
                    double x1 = (-argB + Math.Sqrt(discr)) / (2 * argA);
                    double x2 = (-argB - Math.Sqrt(discr)) / (2 * argA);
                    Console.WriteLine("x1 = " + x1 + ", x2= " + x2);
                }

            }
            else
            {
                Console.WriteLine("Error! Incorrect input!.");
            }

        }

        private static void Part34()
        {
            Console.WriteLine("Enter length of first cathetus:");
            bool success1 = uint.TryParse(Console.ReadLine(), out uint catA);
            Console.WriteLine("Enter length of second cathetus:");
            bool success2 = uint.TryParse(Console.ReadLine(), out uint catB);

            if (success1 && success2)
            {
                // -------------------------------------------------------------
                // Гипотенуза hipC определится по теореме Пифагора
                double hipC = Math.Sqrt(catA * catA + catB * catB);
                Console.WriteLine("Hypotenuse length = " + hipC);


                // -------------------------------------------------------------
                // Углы - по теореме косинусов: cos(A) = (b^2 + c^2 - a^2) / 2bc
                double pi = 3.14;

                //Угол A
                double cosA = ((catB * catB + hipC * hipC - catA * catA) / (2 * catB * hipC));
                double radA = Math.Acos(cosA);          // радианы
                double cornerA = radA * 180 / pi;       // градусы

                Console.WriteLine("Сorner A = " + cornerA);
                // т.к. один угол прямой и сумма внутранних углов треугольника = 180
                Console.WriteLine("Сorner B = " + (90 - cornerA));
            }
            else if (!success1)
            {
                Console.WriteLine("Error! Incorrect length of first cathetus!");
            }
            else
            {
                Console.WriteLine("Error! Incorrect length of second cathetus!");
            }

        }

    }
}


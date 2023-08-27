using System;

namespace c_sharp_first_project
{
    class Program
    {
        static double divide(double num_1, double num_2)
        {
            return num_1 / num_2;
        }

        static double multiply(double num_1, double num_2)
        {
            return num_1 * num_2;
        }

        static double substract(double num_1, double num_2)
        {
            return num_1 - num_2;
        }

        static double plus(double num_1, double num_2)
        {
            return num_1 + num_2;
        }
        static void Main()
        {
            string[] menu_choices = { "Divide", "Multiply", "Subtract", "Plus" };
            int select_choice = 0;
            bool menu_check = true;

            while (menu_check)
            {
                Console.Clear();
                print_menu(menu_choices, select_choice);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        select_choice = (select_choice - 1 + menu_choices.Length) % menu_choices.Length;
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        select_choice = (select_choice + 1) % menu_choices.Length;
                        break;
                    case ConsoleKey.Enter:
                        start_operation(menu_choices[select_choice]);
                        break;
                    case ConsoleKey.Escape:
                        menu_check = false;
                        break;
                }
            }
        }

        static void print_menu(string[] menu_choices, int select_choice)
        {
            Console.WriteLine("Select an Operation Please:");
            Console.WriteLine();

            for (int i = 0; i < menu_choices.Length; i++)
            {
                if (i == select_choice)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(">> ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("   ");
                }

                Console.WriteLine(menu_choices[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress Enter to select operation or Esc to exit.");
        }

        static void start_operation(string select_choice)
        {
            Console.Clear();
            double num1, num2;

            Console.Write("Enter the first number: ");
            double.TryParse(Console.ReadLine(), out num1);

            Console.Write("Enter the second number: ");
            double.TryParse(Console.ReadLine(), out num2);

            double result = 0;

            switch (select_choice)
            {
                case "Divide":
                    if (num2 != 0)
                    {
                        result = divide(num1, num2);
                        Console.WriteLine($"{num1} / {num2} = {result}");
                    }
                    else
                        Console.WriteLine("Cannot divide by zero.");
                    break;
                case "Multiply":
                    result = multiply(num1, num2);
                    Console.WriteLine($"{num1} * {num2} = {result}");
                    break;
                case "Subtract":
                    result = substract(num1, num2);
                    Console.WriteLine($"{num1} - {num2} = {result}");
                    break;
                case "Plus":
                    result = plus(num1, num2);
                    Console.WriteLine($"{num1} + {num2} = {result}");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
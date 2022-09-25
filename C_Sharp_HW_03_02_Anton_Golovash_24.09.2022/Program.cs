using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace C_Sharp_HW_03_02_Anton_Golovash_24._09._2022
{
    internal class Program
    {
        enum Fault
        {
            WrongNumberOfParameters = 1,
            WrongOperation = 2,
            OperandIsNotNumber = 3,
            YouCannotDivideByZero = 4
        };

        enum NameOperation { SUM = 1, SUB = 2, DIV = 3, MULT = 4, HELP = 5 };

        static void ShowHelp(Fault F)
        {
            if (F == Fault.WrongNumberOfParameters)
            {
                Console.WriteLine();
                Console.WriteLine("Для корректной работы программы требуется три оператора");
            }
            if (F == Fault.WrongOperation)
            {
                Console.WriteLine();
                Console.WriteLine("Допустимый первый операнд");
                Console.WriteLine("sum - сложение");
                Console.WriteLine("sub - вычитание");
                Console.WriteLine("div - деление");
                Console.WriteLine("mult - умножение");
            }
            if (F == Fault.OperandIsNotNumber)
            {
                Console.WriteLine();
                Console.WriteLine("Второй и третий операнды должны быть числами");
            }
            if (F == Fault.YouCannotDivideByZero)
            {
                Console.WriteLine();
                Console.WriteLine("При делении третий операнд не может быть нолём");
            }
        }
        static void ShowError(Fault F)
        {
            if (F == Fault.WrongNumberOfParameters)
            {
                Console.WriteLine();
                Console.WriteLine("Неправильное количество параметров");
                ShowHelp(F);
            }
            if (F == Fault.WrongOperation)
            {
                Console.WriteLine();
                Console.WriteLine("Название операции программа не поддерживает");
                ShowHelp(F);
            }
            if (F == Fault.OperandIsNotNumber)
            {
                Console.WriteLine();
                Console.WriteLine("Операнды не являются числами");
                ShowHelp(F);
            }
            if (F == Fault.YouCannotDivideByZero)
            {
                Console.WriteLine();
                Console.WriteLine("На ноль делить нельзя");
                ShowHelp(F);
            }
        }
        static bool CommandValidator(String command)
        {
            if (0 == String.Compare(command, "help", true))
            {
                ShowHelp(Fault.WrongNumberOfParameters);
                ShowHelp(Fault.WrongOperation);
                ShowHelp(Fault.OperandIsNotNumber);
                ShowHelp(Fault.YouCannotDivideByZero);
                Console.WriteLine();
                Console.WriteLine("Для завершения программы нажмите любую клавишу");
                Console.ReadKey();
                return false;
            }
            if ((String.Compare(command, "sum", true) != 0) &&
                (String.Compare(command, "sub", true) != 0) &&
                (String.Compare(command, "div", true) != 0) &&
                (String.Compare(command, "mult", true) != 0) &&
                (String.Compare(command, "help", true) != 0))
            {
                ShowError(Fault.WrongOperation);
                Console.WriteLine();
                Console.WriteLine("Для завершения программы нажмите любую клавишу");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        static bool LengthValidator(int length)
        {
            if (length > 3)
            {
                ShowError(Fault.WrongNumberOfParameters);
                Console.WriteLine();
                Console.WriteLine("Для завершения программы нажмите любую клавишу");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        static bool NumberValidator(bool firstParametrIsNumber, bool secondParametrIsNumber)
        {
            if (!firstParametrIsNumber)
            {
                ShowError(Fault.OperandIsNotNumber);
                Console.WriteLine();
                Console.WriteLine("Для завершения программы нажмите любую клавишу");
                Console.ReadKey();
                return false;
            }
            if (!secondParametrIsNumber)
            {
                ShowError(Fault.OperandIsNotNumber);
                Console.WriteLine();
                Console.WriteLine("Для завершения программы нажмите любую клавишу");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        static bool Number2IsNotZeroValidator(String command, double number2)
        {
            if ((command == "div") && (0 == number2))
            {
                ShowError(Fault.YouCannotDivideByZero);
                Console.WriteLine();
                Console.WriteLine("Для завершения программы нажмите любую клавишу");
                Console.ReadKey();
                return false;
            }
            return true;
        }
        static int GetOperation(ref String name_operation)
            {
	        if (0 == String.Compare(name_operation, "sum")) { return (int)NameOperation.SUM; }
	        else if (0 == String.Compare(name_operation, "sub")) { return (int)NameOperation.SUB; }
            else if (0 == String.Compare(name_operation, "div")) { return (int)NameOperation.DIV; }
            else if (0 == String.Compare(name_operation, "mult")) { return (int)NameOperation.MULT; }
            else if (0 == String.Compare(name_operation, "help")) { return (int)NameOperation.HELP; }
            else {return 6; }
            }

        static double F_Sum(double number1, double number2) { return (number1 + number2); }

        static double F_Sub(double number1, double number2) { return (number1 - number2); }

        static double F_Div(double number1, double number2) { return (number1 / number2); }

        static double F_Mult(double number1, double number2) { return (number1 * number2); }

        static void Main()
        {
            string[] args = { "mult", "5", "6" };
            string command = args[0];
            bool firstParametrIsNumber = double.TryParse(args[1], out double number1);
            bool secondParametrIsNumber = double.TryParse(args[2], out double number2);

            if (!CommandValidator(command))
            {
                return;
            }
            if (!LengthValidator(args.Length))
            {
                return;
            }
            if (!NumberValidator(firstParametrIsNumber, secondParametrIsNumber))
            {
                return;
            }
            if (!Number2IsNotZeroValidator(command, number2))
            {
                return;
            }

            switch (GetOperation(ref command))
            {
                case (int)NameOperation.SUM:
                    Console.WriteLine();
                    Console.WriteLine($"Summation result = {F_Sum(number1, number2)}");
                    break;
                case (int)NameOperation.SUB:
                    Console.WriteLine();
                    Console.WriteLine($"Subtraction result = { F_Sub(number1, number2)}");
                    break;
                case (int)NameOperation.DIV:
                    Console.WriteLine();
                    Console.WriteLine($"Division result = {F_Div(number1, number2)}");
                    break;
                case (int)NameOperation.MULT:
                    Console.WriteLine();
                    Console.WriteLine($"Multiplication result = {F_Mult(number1, number2)}");
                    break;
            };
            Console.ReadKey();
        }
    }
}

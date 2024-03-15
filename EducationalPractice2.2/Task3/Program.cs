using System;
using System.Collections.Generic;

class Int
{
    private int field_intValue;
    private bool field_isEven;

    public int intValue
    {
        get { return field_intValue; }
        set { field_intValue = value; }
    }
    
    public bool isEven
    {
        get { return field_isEven; }
        set { field_isEven = value; }
    }

    public Int(int inputNumber, bool isEven)
    {
        field_intValue = inputNumber;
        field_isEven = isEven;
    }

    public static Int PrintOff(List<Int> listOfIntNumbers)
    {
        foreach (Int intNumber in listOfIntNumbers)
        {
            Console.WriteLine($"Int value: {intNumber.intValue}, is even: {intNumber.isEven}");
        }
        return null;
    }

    public static void ChangeNumbers(List<Int> listOfNumbers)
    {
        Console.WriteLine("Choose index of number you want to change: ");
        int indexOfNumber = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Choose new number: ");
        int newNumber = Convert.ToInt32(Console.ReadLine());

        if (indexOfNumber >= 0 && indexOfNumber < listOfNumbers.Count)
        {
            listOfNumbers[indexOfNumber].intValue = newNumber;
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }

    public static int GetSum(List<Int> listOfNumbers)
    {
        Console.WriteLine("Choose index of first number: ");
        int indexOfFirstNumber = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Choose index of number you want to change: ");
        int indexOfSecondNumber = Convert.ToInt32(Console.ReadLine());

        int sum = 0;
        if (indexOfFirstNumber >= 0 && indexOfFirstNumber < listOfNumbers.Count)
        {
            if (indexOfFirstNumber >= 0 && indexOfFirstNumber < listOfNumbers.Count)
            {
                sum = listOfNumbers[indexOfFirstNumber].intValue + listOfNumbers[indexOfSecondNumber].intValue;
                Console.WriteLine("Sum: " + sum);
            }
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
        return sum;
    }

    public static void GetMax(List<Int> listOfNumbers)
    {
        int max = 0;
        foreach (Int number in listOfNumbers)
        {
            if (number.intValue > max) 
            {
                max = number.intValue;
            }
        }

        Console.WriteLine("Max is: " + max);
    }
}

class Task3
{
    static void Main()
    {
        List<Int> listOfIntNumbers = new List<Int>();
        Console.WriteLine("Input some quantity of numbers (to stop input zero)");
        while (true)
        {
            int inputNumber = Convert.ToInt32(Console.ReadLine());
            if (inputNumber == 0)
            {
                break;
            }
            bool isEven = true;
            if (inputNumber % 2 == 0)
            {
                isEven = true;
            }
            else
            {
                isEven = false;
            }
            listOfIntNumbers.Add(new Int(inputNumber, isEven));
        }

        while (true)
        {
            Console.WriteLine("Select an action:");
            Console.WriteLine("1: Output all numbers");
            Console.WriteLine("2: Change number");
            Console.WriteLine("3: Sum two numbers");
            Console.WriteLine("4: Find max number");
            Console.WriteLine("0: Close the program");
            Console.WriteLine();
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Int.PrintOff(listOfIntNumbers);
                    break;
                case "2":
                    Int.ChangeNumbers(listOfIntNumbers);
                    break;
                case "3":
                    Int.GetSum(listOfIntNumbers);
                    break;
                case "4":
                    Int.GetMax(listOfIntNumbers);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid input. Try again");
                    break;
            }
            Console.WriteLine("\n");
        }
    }
}

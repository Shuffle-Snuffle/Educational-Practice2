using System;
using System.Collections.Generic;

class RomanNumbersConverter
{
    private Dictionary<char, int> romanNumbers = new Dictionary<char, int>
    {
        { 'I', 1},
        { 'V', 5},
        { 'X', 10},
        { 'L', 50},
        { 'C', 100},
        { 'D', 500},
        { 'M', 1000}
    };

    public int Convert(string inputNumber)
    {
        int result = 0;

        for (int i = 0; i < inputNumber.Length; ++i)
        {
            try
            {
                int currentValue = romanNumbers[inputNumber[i]];
                if (i + 1 < inputNumber.Length)
                {
                    if (currentValue < romanNumbers[inputNumber[i + 1]])
                    {
                        result -= currentValue;
                    }
                    else
                    {
                        result += currentValue;
                    }
                }
                else
                {
                    result += currentValue;
                }
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Invalid Roman digit: " + inputNumber[i]);
                return -1;
            }
        }

        return result;
    }
}

class Task1
{
    static void Main() 
    {
        RomanNumbersConverter number = new RomanNumbersConverter();
        Console.WriteLine("Input roman number for convertation: ");
        string inputNumber = Console.ReadLine();
        Console.WriteLine("Converted number:");
        Console.WriteLine(number.Convert(inputNumber));
    }
}
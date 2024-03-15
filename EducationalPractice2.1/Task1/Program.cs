using System;

class Task1
{
    static void Main()
    {
        Console.WriteLine("Input string J \"jewels\":");
        string j = Console.ReadLine();

        Console.WriteLine("Input string S \"stones\":");
        string s = Console.ReadLine();

        int count = 0;
        foreach (char stone in s)
        {
            for (int i = 0; i < j.Length; i++)
            {
                if (stone == j[i])
                {
                    count++;
                    break;
                }
            }
        }

        Console.WriteLine($"Number of coincidence: {count}");
    }
}


using System;

class Counter
{
    private int field_value;

    public int Value
    {
        get { return field_value; }
        set { field_value = value; }
    }

    public Counter() 
    {
        field_value = 0;
    }
    public Counter(int initialValue)
    {
        field_value = initialValue;
    }

    public void Increment()
    {
        field_value++;
    }

    public void Decrement()
    {
        field_value--;
    }
}

class Task4
{
    static Counter counter = null;
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Select an action:");
            Console.WriteLine("1: Initialize counter");
            Console.WriteLine("2: Print current state of counter");
            Console.WriteLine("3: Decrement the counter");
            Console.WriteLine("4: Increment the counter");
            Console.WriteLine("0: Close the program");
            Console.WriteLine();
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    counter = InitializeCounter();
                    break;
                case "2":
                    PrintCurrentState(counter);
                    break;
                case "3":
                    if (counter != null)
                    {
                        counter.Decrement();
                        Console.WriteLine("Decrement succesfull");
                    }
                    else
                    {
                        Console.WriteLine("Counter is not initialized. Please initialize it first.");
                    }
                    break;
                case "4":
                    if (counter != null)
                    {
                        counter.Increment();
                        Console.WriteLine("Increment succesfull");
                    }
                    else
                    {
                        Console.WriteLine("Counter is not initialized. Please initialize it first.");
                    }
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid input. Try again");
                    break;
            }
            Console.WriteLine();
        }
    }

    static Counter InitializeCounter()
    {
        Console.WriteLine("Initialize default value or current? (1 - default, 2 - current)");
        int choiseOfCounterValue = Convert.ToInt32(Console.ReadLine());
        if(choiseOfCounterValue == 1)
        {
            Counter currentCounter = new Counter();
            Console.WriteLine("Initialize succesfull");
            return currentCounter;
        }
        if (choiseOfCounterValue == 2)
        {
            Console.WriteLine("Choose value for counter");
            int valueForCounter = Convert.ToInt32(Console.ReadLine());
            Counter currentCounter = new Counter(valueForCounter);
            Console.WriteLine("Initialize succesfull");
            return currentCounter;
        }
        else
        {
            Console.WriteLine("Invalid input");
            return null;
        }
    }

    static void PrintCurrentState(Counter counter)
    {
        if (counter != null)
        {
            Console.WriteLine("Current state of counter is: {0}", counter.Value);
        }
        else
        {
            Console.WriteLine("Counter don't initialize");
        }
    }
}

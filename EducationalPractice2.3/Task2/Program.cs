using System;

class Worker
{
    private string name;
    private string surname;
    private double rate;
    private int days;

    public Worker(string name, string surname, double rate, int days)
    {
        this.name = name;
        this.surname = surname;
        this.rate = rate;
        this.days = days;
    }

    public Worker()
    {
        this.name = null;
        this.surname = null;
        this.rate = 0;
        this.days = 0;
    }

    public double GetSalary()
    {
        return rate * days;
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Surname
    {
        get { return surname; }
        set { surname = value; }
    }

    public double Rate
    {
        get { return rate; }
        set { rate = value; }
    }

    public int Days
    {
        get { return days; }
        set { days = value; }
    }
}

class Task2
{
    static void Main()
    {
        Worker worker = new Worker("Tobias", "Ripper", 1000, 20);
        Console.WriteLine(worker.Name);
        Console.WriteLine(worker.Surname);
        Console.WriteLine(worker.Rate);
        Console.WriteLine(worker.Days);
        Console.WriteLine(worker.GetSalary());
    }
}
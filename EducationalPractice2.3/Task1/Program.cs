using System;

class Worker
{
    public string name;
    public string surname;
    public double rate;
    public int days;

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
}

class Task1 
{
    static void Main()
    {
        Worker worker = new Worker("Tobias", "Ripper", 1000, 20);
        Console.WriteLine(worker.name);
        Console.WriteLine(worker.GetSalary());
    }
}
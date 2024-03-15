using System;
class Athlete
{
    private int field_number;
    private string field_name;

    public Athlete()
    {
        field_number = 0;
        field_name = "Unknown";
    }

    public Athlete(int number, string name)
    {
        field_number = number;
        field_name = name;
    }

    public string Name
    {
        get { return field_name; }
        set { field_name = value; }
    }

    public int Number
    {
        get { return field_number; }
        set { field_number = value; }
    }

    ~Athlete()
    {
        Console.WriteLine($"Object {field_name} ({field_number}) deleted");
    }
}

class Task5
{
    static void Main()
    {
        NotMain();
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    static void NotMain()
    {
        Athlete athlete1 = new Athlete();
        Console.WriteLine($"Name: {athlete1.Name}, Number: {athlete1.Number}");

        Athlete athlete2 = new Athlete(228, "John Doe");
        Console.WriteLine($"Name: {athlete2.Name}, Number: {athlete2.Number}");

        athlete2.Name = "Jane Doe";
        athlete2.Number = 282;
        Console.WriteLine($"Name: {athlete2.Name}, Number: {athlete2.Number}");
    }
}

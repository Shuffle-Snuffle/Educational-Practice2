using System;

class Calculation
{
    private string calculationLine;

    public string SetCalculationLine
    {
        set {calculationLine = value; }
    }

    public string GetCalculationLine
    {
        get { return calculationLine; }
    }

    public char SetLastSymbolCalculationLine
    {
        set { calculationLine += value; }
    }

    public char GetLastSymbol
    {
        get { return calculationLine[calculationLine.Length - 1]; }
    }

    public void DeleteLastSymbol()
    {
        if (calculationLine.Length > 0)
        {
            calculationLine = calculationLine.Remove(calculationLine.Length - 1);
        }
    }
}

class Task3
{
    static void Main()
    {
        Calculation newObject = new Calculation();
        newObject.SetCalculationLine = "Moscow";
        Console.WriteLine(newObject.GetCalculationLine);
        newObject.SetLastSymbolCalculationLine = 'L';
        Console.WriteLine(newObject.GetLastSymbol);
        Console.WriteLine(newObject.GetCalculationLine);
        newObject.DeleteLastSymbol();
        Console.WriteLine(newObject.GetCalculationLine);
    }
}
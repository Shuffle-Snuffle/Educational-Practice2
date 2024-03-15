using System;
using System.Collections.Generic;

class Train
{
    private string field_destination;
    private string field_trainNumber;
    private DateTime field_departureTime;


    public string Destination
    {
        get { return field_destination; }
        set { field_destination = value; }
    }

    public string TrainNumber
    {
        get { return field_trainNumber; }
        set { field_trainNumber = value; }
    }

    public DateTime DepartureTime
    {
        get { return field_departureTime; }
        set { field_departureTime = value; }
    }

    public Train(string destination, string trainNumber, DateTime departureTime)
    {
        field_destination = destination;
        field_trainNumber = trainNumber;
        field_departureTime = departureTime;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Destination: {field_destination}");
        Console.WriteLine($"Number of train: {field_trainNumber}");
        Console.WriteLine($"Departure time: {field_departureTime}");
    }

    public static Train FindTrain(List<Train> listOfTrains, string trainNumber)
    {
        foreach (Train current_train in listOfTrains)
        {
            if (current_train.TrainNumber == trainNumber)
            {
                return current_train;
            }
        }

        return null;
    }
}

class Task2
{
    static List<Train> listOfTrains = new List<Train>();
    static void Main()
    {
        listOfTrains.Add(new Train("Hell", "666", new DateTime(1995, 10, 15)));
        listOfTrains.Add(new Train("Purgatory", "999", new DateTime(1996, 5, 20)));
        listOfTrains.Add(new Train("Paradise", "777", new DateTime(1997, 2, 10)));

        Console.WriteLine("Enter train's number:");
        string trainNumber = Console.ReadLine();

        Train foundTrain = Train.FindTrain(listOfTrains, trainNumber);

        if (foundTrain != null)
        {
            foundTrain.PrintInfo();
        }
        else
        {
            Console.WriteLine("Train is not existed");
        }
    }
}
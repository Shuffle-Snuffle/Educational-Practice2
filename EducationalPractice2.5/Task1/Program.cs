using Npgsql;
using System;

namespace Task;
public class Task1
{
    public static void Main()
    {
        string connectionString = "Host=localhost;Username=postgres;Password=ShadowTen2!;Database=Task1";
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Black;
        while (true)
        {
            Console.WriteLine("Main Menu:\n");
            Console.WriteLine("View and add machine types (1)");
            Console.WriteLine("View and add drivers and their licenses (2)");
            Console.WriteLine("View and add cars (3)");
            Console.WriteLine("View and add itinerary (4)");
            Console.WriteLine("View and add routes (5)");
            Console.WriteLine("Exiting the program (6)");

            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DataBaseRequests.ViewAndAddMachineTypes(connectionString);
                    break;

                case "2":
                    DataBaseRequests.ViewAndAddDriversAndLicenses(connectionString);
                    break;

                case "3":
                    DataBaseRequests.ViewAndAddCars(connectionString);
                    break;

                case "4":
                    DataBaseRequests.ViewAndAddItinerary(connectionString);
                    break;

                case "5":
                    DataBaseRequests.ViewAndAddRoutes(connectionString);
                    break;

                case "6":
                    Console.WriteLine("\nProgram terminated");
                    return;

                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }
}

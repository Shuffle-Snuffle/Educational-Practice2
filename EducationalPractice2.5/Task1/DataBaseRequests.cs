using System;
using Npgsql;

namespace Task;
public class DataBaseRequests
{
    public static void ViewAndAddMachineTypes(string connectionString)
    {
        Console.WriteLine("\nChoose action: 1: View machine types, 2: Add machine types");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT * FROM type_car";

                using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                using NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader[0]} Название: {reader[1]}");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nInvalid input, try again");
            }
            finally
            {
                Console.WriteLine("\nAction successfully, tap any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else if (choice == 2)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Input name of new type car");
                string name = Console.ReadLine();
                string sql = $"INSERT INTO type_car(name) VALUES ('{name}')";

                using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nInvalid input, try again");
            }
            finally
            {
                Console.WriteLine("\nAction successfully, tap any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    public static void ViewAndAddDriversAndLicenses(string connectionString)
    {
        Console.WriteLine("\nChoose action: 1: View drivers and their licenses, 2: Add drivers and their licenses");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            Console.WriteLine("Choose action: view drivers (1) or their licenses (2)");
            int choiceAction = Convert.ToInt32(Console.ReadLine());

            if (choiceAction == 1)
            {
                try
                {
                    NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                    connection.Open();
                    string sql = "SELECT * FROM driver";

                    using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                    using NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Console.WriteLine($"Id: {reader[0]} Имя: {reader[1]} Фамилия: {reader[2]} Дата рождения: {reader[3]}");
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\nInvalid input, try again");
                }
                finally
                {
                    Console.WriteLine("\nAction successfully, tap any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            if (choiceAction == 2)
            {
                try
                {
                    NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                    connection.Open();
                    string sql = "SELECT dr.first_name, dr.last_name, rc.name FROM driver_rights_category " +
                        "INNER JOIN driver dr on driver_rights_category.id_driver = dr.id " +
                        "INNER JOIN rights_category rc on rc.id = driver_rights_category.id_rights_category";

                    using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                    using NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"Имя: {reader[0]} Фамилия: {reader[1]} Категория прав: {reader[2]}");
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\nInvalid input, try again");
                }
                finally
                {
                    Console.WriteLine("\nAction successfully, tap any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        else if (choice == 2)
        {
            Console.WriteLine("Choose action: add driver (1) add rights category (2) connect driver with rights (3)");
            int choiceAction = Convert.ToInt32(Console.ReadLine());

            if (choiceAction == 1)
            {
                try
                {
                    NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                    connection.Open();
                    Console.WriteLine("Input firstname of driver:");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Input lastname of driver:");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Input birthdate of driver:");
                    DateTime birthdate = Convert.ToDateTime(Console.ReadLine());

                    string sqlDrivers = $"INSERT INTO driver(first_name, last_name, birthdate) VALUES ('{firstName}', '{lastName}', '{birthdate}')";
                    using NpgsqlCommand command = new NpgsqlCommand(sqlDrivers, connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\nInvalid input, try again");
                }
                finally
                {
                    Console.WriteLine("\nAction successfully, tap any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else if (choiceAction == 2)
            {
                try
                {
                    NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                    connection.Open();
                    Console.WriteLine("Input rights category");
                    string name = Console.ReadLine();
                    string sqlRights = $"INSERT INTO rights_category(name) VALUES ('{name}')";
                    using NpgsqlCommand commandAddRights = new NpgsqlCommand(sqlRights, connection);
                    commandAddRights.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\nInvalid input, try again");
                }
                finally
                {
                    Console.WriteLine("\nAction successfully, tap any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
            else if (choiceAction == 3)
            {
                try
                {
                    NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                    connection.Open();
                    Console.WriteLine("Input id of driver to connect him with rights");
                    int driver = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Input id of rights category for driver");
                    int rightsCategory = Convert.ToInt32(Console.ReadLine());

                    string sqlDriversAndLicense = $"INSERT INTO driver_rights_category(id_driver, id_rights_category) VALUES ({driver}, {rightsCategory})";
                    using NpgsqlCommand commandInsertRights = new NpgsqlCommand(sqlDriversAndLicense, connection);
                    commandInsertRights.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("\nInvalid input, try again");
                }
                finally
                {
                    Console.WriteLine("\nAction successfully, tap any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }

    public static void ViewAndAddCars(string connectionString)
    {
        Console.WriteLine("\nChoose action: 1: View cars 2: Add cars");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT * FROM car";

                using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                using NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Id машины: {reader[0]} Id типа машины: {reader[1]} Название машины: {reader[2]} Государственный номер машины: {reader[3]} Число пассажиров: {reader[4]}");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nInvalid input, try again");
            }
            finally
            {
                Console.WriteLine("\nAction successfully, tap any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else if (choice == 2)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();

                Console.WriteLine("Input name of new car");
                string name = Console.ReadLine();
                Console.WriteLine("Input id of type of car of new car");
                int id_type_car = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input state number of new car");
                string state_number = Console.ReadLine();
                Console.WriteLine("Input number of passengers of new car");
                int number_passengers = Convert.ToInt32(Console.ReadLine());

                string sql = $"INSERT INTO car(id_type_car, name, state_number, number_passengers) VALUES ({id_type_car}, '{name}', '{state_number}', {number_passengers})";

                using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nInvalid input, try again");
            }
            finally
            {
                Console.WriteLine("\nAction successfully, tap any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    public static void ViewAndAddItinerary(string connectionString)
    {
        Console.WriteLine("\nChoose action: 1: View itinerary 2: Add itinerary");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT * FROM itinerary";

                using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                using NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader[0]} Название: {reader[1]}");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nInvalid input, try again");
            }
            finally
            {
                Console.WriteLine("\nAction successfully, tap any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else if (choice == 2)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();

                Console.WriteLine("Input name of new itinerary");
                string name = Console.ReadLine();

                string sql = $"INSERT INTO itinerary (name) VALUES ('{name}')";

                using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nInvalid input, try again");
            }
            finally
            {
                Console.WriteLine("\nAction successfully, tap any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    public static void ViewAndAddRoutes(string connectionString)
    {
        Console.WriteLine("\nChoose action: 1: View routes 2: Add routes");
        int choice = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                string sql = "SELECT * FROM route";

                using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                using NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader[0]} id водителя: {reader[1]} id машины: {reader[2]} id маршрута: {reader[3]} Число пассажиров: {reader[4]}");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nInvalid input, try again");
            }
            finally
            {
                Console.WriteLine("\nAction successfully, tap any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else if (choice == 2)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();

                Console.WriteLine("Input id of driver of new route");
                int id_driver = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input id of car of new route");
                int id_car = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input id of itinerary of new route");
                int id_itinerary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input number of passengers of new route");
                int number_passengers = Convert.ToInt32(Console.ReadLine());

                string sql = $"INSERT INTO route(id_driver, id_car, id_itinerary, number_passengers) VALUES ({id_driver}, {id_car}, {id_itinerary}, {number_passengers})";

                using NpgsqlCommand command = new NpgsqlCommand(sql, connection);
                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nInvalid input, try again");
            }
            finally
            {
                Console.WriteLine("\nAction successfully, tap any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
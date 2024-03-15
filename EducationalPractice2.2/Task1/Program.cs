using System;
using System.Collections.Generic;

public class Student
{
    private string field_surname;
    private DateTime field_dateOfBirth;
    private string field_groupNumber;
    private int[] field_academicPerformance;

    public string Surname
    {
        get { return field_surname; }
        set { field_surname = value; }
    }

    public DateTime DateOfBirth
    {
        get { return field_dateOfBirth; }
        set { field_dateOfBirth = value; }
    }

    public string GroupNumber
    {
        get { return field_groupNumber; }
        set { field_groupNumber = value; }
    }

    public int[] AcademicPerformance
    {
        get { return field_academicPerformance; }
        set { field_academicPerformance = value; }
    }

    public Student(string surname, DateTime dateOfBirth, string groupNumber, int[] academicPerformance)
    {
        field_surname = surname;
        field_dateOfBirth = dateOfBirth;
        field_groupNumber = groupNumber;
        field_academicPerformance = academicPerformance;
    }

    public void ChangeSurname(string newSurname)
    {
        field_surname = newSurname;
    }

    public void ChangeDateOfBirth(DateTime newDateOfBirth)
    {
        field_dateOfBirth = newDateOfBirth;
    }

    public void ChangeGroupNumber(string newGroupNumber)
    {
        field_groupNumber = newGroupNumber;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Surname: {field_surname}");
        Console.WriteLine($"Date of birth: {field_dateOfBirth}");
        Console.WriteLine($"Group number: {field_groupNumber}");
        Console.WriteLine("Academic perfomance:");
        foreach (int grade in field_academicPerformance)
        {
            Console.Write(grade + " ");
        }
    }

    public static Student FindStudent(List<Student> listOfStudents, string surname, DateTime dateOfBirth)
    {
        foreach (Student current_student in listOfStudents)
        {
            if (current_student.Surname == surname && current_student.DateOfBirth == dateOfBirth)
            {
                return current_student;
            }
        }

        return null;
    }
}

class Task1
{
    static List<Student> listOfStudents = new List<Student>();
    static void Main()
    {
        listOfStudents.Add(new Student("Varlamov", new DateTime(1995, 10, 15), "631", new int[] { 5, 4, 3, 4, 5 }));
        listOfStudents.Add(new Student("Volnov", new DateTime(1996, 5, 20), "931", new int[] { 4, 5, 3, 4, 4 }));
        listOfStudents.Add(new Student("Zaryadov", new DateTime(1997, 2, 10), "731", new int[] { 3, 4, 3, 3, 3 }));

        while (true)
        {
            Console.WriteLine("Select an action:");
            Console.WriteLine("1: Find specific student");
            Console.WriteLine("2: Change information about student");
            Console.WriteLine("0: Close the program");
            Console.WriteLine();
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    findStudent();
                    break;
                case "2":
                    changeInformation();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid input. Try again");
                    break;
            }
            Console.WriteLine("\n");
        }
    }

    static void findStudent()
    {
        Console.WriteLine("Enter student's surname:");
        string surname = Console.ReadLine();
        Console.WriteLine("Enter student's date of birth (yyyy-MM-dd):");
        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

        Student foundStudent = Student.FindStudent(listOfStudents, surname, dateOfBirth);

        if (foundStudent != null)
        {
            Console.WriteLine("\nStudent found:\n");
            foundStudent.PrintInfo();
        }
        else
        {
            Console.WriteLine("Student not found\n");
        }
    }
    static void changeInformation()
    {
        Console.WriteLine("Enter student's surname:");
        string surname = Console.ReadLine();
        Console.WriteLine("Enter student's date of birth (yyyy-MM-dd):");
        DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

        Student foundStudent = Student.FindStudent(listOfStudents, surname, dateOfBirth);

        if (foundStudent != null)
        {
            Console.WriteLine("Select what you want to change:");
            Console.WriteLine("1: Surname");
            Console.WriteLine("2: Date of birth");
            Console.WriteLine("3: Group number");
            Console.WriteLine();
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter new surname:");
                    string newSurname = Console.ReadLine();
                    foundStudent.ChangeSurname(newSurname);
                    break;
                case "2":
                    Console.WriteLine("Enter new date of birth (yyyy-MM-dd):");
                    DateTime newDateOfBirth = DateTime.Parse(Console.ReadLine());
                    foundStudent.ChangeDateOfBirth(newDateOfBirth);
                    break;
                case "3":
                    Console.WriteLine("Enter new group number:");
                    string newGroupNumber = Console.ReadLine();
                    foundStudent.ChangeGroupNumber(newGroupNumber);
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again");
                    break;
            }

            Console.WriteLine("Information changed:");
            foundStudent.PrintInfo();
        }
        else
        {
            Console.WriteLine("Student not found");
        }
    }
}
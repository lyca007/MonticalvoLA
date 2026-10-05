using System;
using System.Collections.Generic;

namespace Dictionary
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }

    class Program
    {
        static void Main()
        {
            Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();

            int choice = 0;

            while (choice != 4)
            {
                Console.Clear();

                Console.WriteLine("======================================");
                Console.WriteLine("   STUDENT LOOKUP USING DICTIONARY");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Display All Students");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("\nInvalid choice.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        // add
                        if (studentDictionary.Count >= 10)
                        {
                            Console.WriteLine("\nMaximum of 10 students reached.");
                            Console.Write("Press Enter to continue...");
                            Console.ReadLine();
                            break;
                        }

                        Student newStudent = new Student();

                        Console.Write("\nEnter the Student Number: ");
                        newStudent.StudentNumber = Console.ReadLine()!;

                        if (studentDictionary.ContainsKey(newStudent.StudentNumber))
                        {
                            Console.WriteLine("Student number already exists!");
                            Console.Write("Press Enter to continue...");
                            Console.ReadLine();
                            break;
                        }

                        Console.Write("Enter the Student Name: ");
                        newStudent.Name = Console.ReadLine()!;

                        Console.Write("Enter the Student Program: ");
                        newStudent.Program = Console.ReadLine()!;

                        Console.Write("Enter the Student Year Level (1-4): ");

                        if (!int.TryParse(Console.ReadLine(), out newStudent.YearLevel))
                        {
                            Console.WriteLine("Invalid year level.");
                            Console.Write("Press Enter to continue...");
                            Console.ReadLine();
                            break;
                        }

                        if (newStudent.YearLevel < 1 || newStudent.YearLevel > 4)
                        {
                            Console.WriteLine("Year level must be between 1 and 4.");
                            Console.Write("Press Enter to continue...");
                            Console.ReadLine();
                            break;
                        }

                        studentDictionary.Add(newStudent.StudentNumber, newStudent);

                        Console.WriteLine("\nStudent added successfully!");

                        if (studentDictionary.Count >= 10)
                        {
                            Console.WriteLine("Maximum of 10 students reached.");
                        }

                        Console.Write("Press Enter to return to the menu...");
                        Console.ReadLine();
                        break;


                    case 2:
                        // search
                        Console.Write("\nEnter student number you want to search: ");

                        string searchStudent = Console.ReadLine()!;

                        if (studentDictionary.ContainsKey(searchStudent))
                        {
                            Student foundStudent = studentDictionary[searchStudent];

                            Console.WriteLine("\nStudent found!");
                            Console.WriteLine($"Student Number: {foundStudent.StudentNumber}");
                            Console.WriteLine($"Name: {foundStudent.Name}");
                            Console.WriteLine($"Program: {foundStudent.Program}");
                            Console.WriteLine($"Year Level: {foundStudent.YearLevel}");
                        }
                        else
                        {
                            Console.WriteLine("\nStudent not found.");
                        }

                        Console.Write("Press Enter to return to the menu...");
                        Console.ReadLine();
                        break;


                    case 3:
                        // display
                        Console.WriteLine("\nAll Students:");

                        if (studentDictionary.Count == 0)
                        {
                            Console.WriteLine("No students found.");
                        }
                        else
                        {
                            foreach (var kvp in studentDictionary)
                            {
                                Student displayStudent = kvp.Value;

                                Console.WriteLine("--------------------------------------");
                                Console.WriteLine($"Student Number: {displayStudent.StudentNumber}");
                                Console.WriteLine($"Name: {displayStudent.Name}");
                                Console.WriteLine($"Program: {displayStudent.Program}");
                                Console.WriteLine($"Year Level: {displayStudent.YearLevel}");
                            }

                            Console.WriteLine("--------------------------------------");
                        }

                        Console.Write("\nPress Enter to return to the menu...");
                        Console.ReadLine();
                        break;


                    case 4:
                        Console.WriteLine("\nProgram Exited.");
                        break;


                    default:
                        Console.WriteLine("\nInvalid choice.");
                        Console.WriteLine("Please choose 1-4.");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
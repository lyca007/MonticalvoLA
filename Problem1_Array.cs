using System;

namespace Array
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
            Student[] students = new Student[10];
            int studentCount = 0;

            int choice;

            do
            {
                Console.Clear();

                Console.WriteLine("===============================");
                Console.WriteLine("   STUDENT RECORD MANAGEMENT");
                Console.WriteLine("===============================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("\nInvalid choice.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    continue;
                }

                int indexOfValue = -1;

                switch (choice)
                {
                    case 1:
                        // add
                        if (studentCount >= students.Length)
                        {
                            Console.WriteLine("\nMaximum of 10 students reached.");
                            Console.WriteLine("Press Enter to return to the menu...");
                            Console.ReadLine();
                            break;
                        }

                        while (studentCount < students.Length)
                        {
                            Student s = new Student();

                            Console.Write("\nEnter the Student Number: ");
                            s.StudentNumber = Console.ReadLine()!;

                            Console.Write("Enter the Student Name: ");
                            s.Name = Console.ReadLine()!;

                            Console.Write("Enter the Student Program: ");
                            s.Program = Console.ReadLine()!;

                            Console.Write("Enter the Student Year Level (1-4): ");

                            if (!int.TryParse(Console.ReadLine(), out s.YearLevel))
                            {
                                Console.WriteLine("Invalid year level.");
                                Console.WriteLine("Press Enter to continue...");
                                Console.ReadLine();
                                break;
                            }

                            if (s.YearLevel < 1 || s.YearLevel > 4)
                            {
                                Console.WriteLine("Year level must be between 1 and 4.");
                                Console.WriteLine("Press Enter to continue...");
                                Console.ReadLine();
                                break;
                            }

                            students[studentCount] = s;
                            studentCount++;

                            Console.WriteLine("\nStudent added successfully!");

                            if (studentCount >= students.Length)
                            {
                                Console.WriteLine("Maximum of 10 students reached.");
                                break;
                            }

                            Console.Write("Do you want to add another student? (Y/N): ");
                            string choice1 = Console.ReadLine()!;

                            if (choice1.ToUpper() != "Y")
                            {
                                break;
                            }
                        }

                        Console.WriteLine("\nPress Enter to return to the menu...");
                        Console.ReadLine();
                        break;


                    case 2:
                        // display
                        Console.WriteLine("\n===============================");
                        Console.WriteLine("        STUDENT RECORDS");
                        Console.WriteLine("===============================");

                        if (studentCount == 0)
                        {
                            Console.WriteLine("No student records found.");
                        }
                        else
                        {
                            for (int i = 0; i < studentCount; i++)
                            {
                                Console.WriteLine($"\nStudent #{i + 1}");
                                Console.WriteLine($"Student Number: {students[i].StudentNumber}");
                                Console.WriteLine($"Name: {students[i].Name}");
                                Console.WriteLine($"Program: {students[i].Program}");
                                Console.WriteLine($"Year Level: {students[i].YearLevel}");
                            }
                        }

                        Console.Write("\nPress Enter to go back to the menu...");
                        Console.ReadLine();
                        break;


                    case 3:
                        // search
                        Console.Write("\nEnter student number: ");
                        string searchStudentNumber = Console.ReadLine()!;

                        for (int i = 0; i < studentCount; i++)
                        {
                            if (students[i].StudentNumber == searchStudentNumber)
                            {
                                indexOfValue = i;
                                break;
                            }
                        }

                        if (indexOfValue != -1)
                        {
                            Console.WriteLine("\n===============================");
                            Console.WriteLine("         STUDENT FOUND!");
                            Console.WriteLine("===============================");
                            Console.WriteLine($"Student Number: {students[indexOfValue].StudentNumber}");
                            Console.WriteLine($"Name: {students[indexOfValue].Name}");
                            Console.WriteLine($"Program: {students[indexOfValue].Program}");
                            Console.WriteLine($"Year Level: {students[indexOfValue].YearLevel}");
                        }
                        else
                        {
                            Console.WriteLine("\nStudent not found.");
                        }

                        Console.Write("\nPress Enter to go back to the menu...");
                        Console.ReadLine();
                        break;


                    case 4:
                        // update
                        Console.Write("\nEnter student number you want to update: ");
                        string updateStudent = Console.ReadLine()!;

                        for (int i = 0; i < studentCount; i++)
                        {
                            if (students[i].StudentNumber == updateStudent)
                            {
                                indexOfValue = i;
                                break;
                            }
                        }

                        if (indexOfValue != -1)
                        {
                            Console.Write("Enter new name: ");
                            students[indexOfValue].Name = Console.ReadLine()!;

                            Console.Write("Enter new Program: ");
                            students[indexOfValue].Program = Console.ReadLine()!;

                            Console.Write("Enter new year level (1-4): ");

                            if (!int.TryParse(Console.ReadLine(), out int newYearLevel))
                            {
                                Console.WriteLine("Invalid year level.");
                                Console.WriteLine("Press Enter to continue...");
                                Console.ReadLine();
                                break;
                            }

                            if (newYearLevel < 1 || newYearLevel > 4)
                            {
                                Console.WriteLine("Year level must be between 1 and 4.");
                                Console.WriteLine("Press Enter to continue...");
                                break;
                            }

                            students[indexOfValue].YearLevel = newYearLevel;

                            Console.WriteLine("\nStudent record updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nStudent not found.");
                        }

                        Console.Write("\nPress Enter to go back to the menu...");
                        Console.ReadLine();
                        break;


                    case 5:
                        // delete
                        Console.Write("\nEnter student number you want to delete: ");
                        string deleteStudent = Console.ReadLine()!;

                        for (int i = 0; i < studentCount; i++)
                        {
                            if (students[i].StudentNumber == deleteStudent)
                            {
                                indexOfValue = i;
                                break;
                            }
                        }

                        if (indexOfValue != -1)
                        {
                            for (int i = indexOfValue; i < studentCount - 1; i++)
                            {
                                students[i] = students[i + 1];
                            }

                            students[studentCount - 1] = new Student();

                            studentCount--;

                            Console.WriteLine("\nStudent deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("\nStudent not found.");
                        }

                        Console.Write("\nPress Enter to go back to the menu...");
                        Console.ReadLine();
                        break;


                    case 6:
                        Console.WriteLine("\nProgram Exited.");
                        break;


                    default:
                        Console.WriteLine("\nInvalid choice.");
                        Console.WriteLine("Please choose between 1 and 6.");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }

            } while (choice != 6);
        }
    }
}
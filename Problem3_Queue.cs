using System;
using System.Collections.Generic;

namespace Queue
{
    struct StudentRequest
    {
        public string StudentNumber;
        public string StudentName;
        public string RequestType;
    }

    class Program
    {
        static void Main()
        {
            Queue<StudentRequest> requestQueue = new Queue<StudentRequest>();

            int choice = 0;

            while (choice != 4)
            {
                Console.Clear();

                Console.WriteLine("========================================");
                Console.WriteLine("STUDENT REQUEST QUEUE");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add Request");
                Console.WriteLine("2. View Pending Requests");
                Console.WriteLine("3. Process Request");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

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
                        StudentRequest newRequest = new StudentRequest();

                        Console.Write("\nEnter Student Number: ");
                        newRequest.StudentNumber = Console.ReadLine()!;

                        Console.Write("Enter Student Name: ");
                        newRequest.StudentName = Console.ReadLine()!;

                        Console.Write("Enter Request Type: ");
                        newRequest.RequestType = Console.ReadLine()!;

                        requestQueue.Enqueue(newRequest);

                        Console.WriteLine("\nRequest added successfully!");

                        Console.Write("Press Enter to return to the menu...");
                        Console.ReadLine();
                        break;


                    case 2:
                        // view
                        Console.WriteLine("\nREQUEST QUEUE");

                        if (requestQueue.Count == 0)
                        {
                            Console.WriteLine("No pending requests.");
                        }
                        else
                        {
                            int number = 1;

                            foreach (StudentRequest request in requestQueue)
                            {
                                Console.WriteLine($"{number}. {request.StudentName} - {request.RequestType}");
                                number++;
                            }
                        }

                        Console.Write("\nPress Enter to return to the menu...");
                        Console.ReadLine();
                        break;


                    case 3:
                        // process
                        if (requestQueue.Count == 0)
                        {
                            Console.WriteLine("\nNo pending requests to process.");
                        }
                        else
                        {
                            StudentRequest processed = requestQueue.Dequeue();

                            Console.WriteLine($"\nProcessing Request: {processed.StudentName} - {processed.RequestType}");
                            Console.WriteLine("\nRequest processed successfully!");
                        }

                        Console.Write("Press Enter to return to the menu...");
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
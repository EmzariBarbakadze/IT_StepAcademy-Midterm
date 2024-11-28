namespace StudentsManagementSystem_ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace StudentManagementSystem
    {
        class Program
        {
            static void Main(string[] args)
            {
                StudentManager studentManager = new StudentManager();

                while (true)
                {
                    Console.WriteLine("\n=== Student Management System ===");
                    Console.WriteLine("1. Add a new student");
                    Console.WriteLine("2. View all students");
                    Console.WriteLine("3. Search student by roll number");
                    Console.WriteLine("4. Update student grade");
                    Console.WriteLine("5. Exit");
                    Console.Write("Choose an option: ");

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            studentManager.AddStudent();
                            break;
                        case "2":
                            studentManager.ViewAllStudents();
                            break;
                        case "3":
                            studentManager.SearchStudentByRollNumber();
                            break;
                        case "4":
                            studentManager.UpdateStudentGrade();
                            break;
                        case "5":
                            Console.WriteLine("Program exited.");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
        }

        public class Student
        {
            public string Name { get; set; }
            public int RollNumber { get; set; }
            public char Grade { get; set; }

            public Student(string name, int rollNumber, char grade)
            {
                Name = name;
                RollNumber = rollNumber;
                Grade = grade;
            }

            public override string ToString()
            {
                return $"Name: {Name}, Roll Number: {RollNumber}, Grade: {Grade}";
            }
        }

        public class StudentManager
        {
            private List<Student> students = new List<Student>();

            public void AddStudent()
            {
                Console.Write("Enter student name: ");
                string name = Console.ReadLine();

                Console.Write("Enter student roll number: ");
                if (!int.TryParse(Console.ReadLine(), out int rollNumber))
                {
                    Console.WriteLine("Invalid roll number.");
                    return;
                }

                Console.Write("Enter student grade (A-F): ");
                char grade = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (!"ABCDEF".Contains(grade.ToString().ToUpper()))
                {
                    Console.WriteLine("Invalid grade.");
                    return;
                }

                students.Add(new Student(name, rollNumber, grade));
                Console.WriteLine("Student added successfully.");
            }

            public void ViewAllStudents()
            {
                if (students.Count == 0)
                {
                    Console.WriteLine("No students found.");
                    return;
                }

                Console.WriteLine("\nStudent List:");
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }

            public void SearchStudentByRollNumber()
            {
                Console.Write("Enter roll number: ");
                if (!int.TryParse(Console.ReadLine(), out int rollNumber))
                {
                    Console.WriteLine("Invalid roll number.");
                    return;
                }

                var student = students.FirstOrDefault(s => s.RollNumber == rollNumber);
                if (student != null)
                {
                    Console.WriteLine("Student details:");
                    Console.WriteLine(student);
                }
                else
                {
                    Console.WriteLine("Student with the given roll number not found.");
                }
            }

            public void UpdateStudentGrade()
            {
                Console.Write("Enter roll number: ");
                if (!int.TryParse(Console.ReadLine(), out int rollNumber))
                {
                    Console.WriteLine("Invalid roll number.");
                    return;
                }

                var student = students.FirstOrDefault(s => s.RollNumber == rollNumber);
                if (student != null)
                {
                    Console.Write("Enter new grade (A-F): ");
                    char grade = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    if (!"ABCDEF".Contains(grade.ToString().ToUpper()))
                    {
                        Console.WriteLine("Invalid grade.");
                        return;
                    }

                    student.Grade = grade;
                    Console.WriteLine("Student grade updated successfully.");
                }
                else
                {
                    Console.WriteLine("Student with the given roll number not found.");
                }
            }
        }
    }

}

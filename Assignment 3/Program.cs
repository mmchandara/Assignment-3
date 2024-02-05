using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentList studentList = new StudentList();

            try
            {
                while (true)
                {
                    Console.WriteLine("-----------menu------------");
                    Console.WriteLine("1. Add student.");
                    Console.WriteLine("2. Edit student by id.");
                    Console.WriteLine("3. Delete student by id.");
                    Console.WriteLine("4. Sort student by GPA.");
                    Console.WriteLine("5. Sort student by name.");
                    Console.WriteLine("6. Show student.");
                    Console.WriteLine("0. Exit.");
                    Console.WriteLine("---------------------------");

                    Console.WriteLine("Please choose: ");
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            studentList.AddStudent();
                            break;
                        case "2":
                            Console.WriteLine("Please input an ID of a student to edit: ");
                            int editId = int.Parse(Console.ReadLine());
                            studentList.Edit(editId);
                            break;
                        case "3":
                            Console.WriteLine("Please input an ID of a student to delete: ");
                            int deleteId = int.Parse(Console.ReadLine());
                            studentList.Delete(deleteId);
                            break;
                        case "4":
                            studentList.SortByGPA();
                            break;
                        case "5":
                            studentList.SortByName();
                            break;
                        case "6":
                            studentList.ShowList();
                            break;
                        case "0":
                            Console.WriteLine("Exiting program.");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please choose a valid option.");
                            break;
                    }
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
        }
            class Student
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public int Age { get; set; }
                public string Address { get; set; }
                public double GPA { get; set; }
            }

            class StudentList
            {
                private List<Student> students = new List<Student>();

                public void AddStudent()
                {
                    Console.WriteLine("Input student id: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Input student name: ");
                    string name = Console.ReadLine();

                    Console.WriteLine("Input student age: ");
                    int age = int.Parse(Console.ReadLine());

                    Console.WriteLine("Input student address: ");
                    string address = Console.ReadLine();

                    Console.WriteLine("Input student GPA: ");
                    double gpa = double.Parse(Console.ReadLine());

                    Student student = new Student { Id = id, Name = name, Age = age, Address = address, GPA = gpa };
                    students.Add(student);

                    Console.WriteLine($"Student {name} added.");
                }

                public void Edit(int id)
                {
                    Student student = students.Find(s => s.Id == id);
                    if (student != null)
                    {
                        Console.WriteLine($"Editing student with ID {id}");

                        Console.WriteLine("Input new student name: ");
                        student.Name = Console.ReadLine();

                        Console.WriteLine("Input new student age: ");
                        student.Age = int.Parse(Console.ReadLine());

                        Console.WriteLine("Input new student address: ");
                        student.Address = Console.ReadLine();

                        Console.WriteLine("Input new student GPA: ");
                        student.GPA = double.Parse(Console.ReadLine());

                        Console.WriteLine($"Student with ID {id} edited.");
                    }
                    else
                    {
                        Console.WriteLine($"Student with ID {id} not found.");
                    }
                }

                public void Delete(int id)
                {
                    Student student = students.Find(s => s.Id == id);
                    if (student != null)
                    {
                        students.Remove(student);
                        Console.WriteLine($"Student with ID {id} deleted.");
                    }
                    else
                    {
                        Console.WriteLine($"Student with ID {id} not found.");
                    }
                }

                public void ShowList()
                {
                    Console.WriteLine("ID | Name | Age | Address | GPA");
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Id} | {student.Name} | {student.Age} | {student.Address} | {student.GPA}");
                    }
                    Console.WriteLine();
                }

                public void SortByGPA()
                {
                    students.Sort((s1, s2) => s2.GPA.CompareTo(s1.GPA));
                    Console.WriteLine("Students sorted by GPA.");
                }

                public void SortByName()
                {
                    students.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));
                    Console.WriteLine("Students sorted by Name.");
                }
        }
    }
}

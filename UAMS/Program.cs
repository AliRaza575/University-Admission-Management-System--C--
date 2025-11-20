using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.Business_logic;
using UAMS.Data_Layer;

namespace UAMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DL dataLayer = new DL();
            string filePath = "C:\\Users\\Mr.Laptop point\\Desktop\\New folder\\student.txt";
            bool running = true;
            int choice;
            dataLayer.Readstudentfromfile(filePath);

            do
            {
                Console.Clear();
                Console.WriteLine("University Admission Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                 choice=int.Parse(Console.ReadLine());
                
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            AddStudent(dataLayer, filePath);
                            break;
                        case 2:
                            ViewAllStudents();
                            break;
                        case 3:
                            DeleteStudent(dataLayer, filePath);
                            break;
                        case 4:
                            UpdateStudent(dataLayer, filePath);
                            break;
                        case 5:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                
               
                if (running)
                {
                    Console.WriteLine("Press any key to return to the main menu...");
                    Console.ReadKey();
                }
            } while (running);
        }

        public static void AddStudent(IDataOperations dataLayer, string filePath)
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Student ID: ");
            string id = Console.ReadLine();
            Console.Write("Enter Matric Marks: ");
            int matricMarks = int.Parse(Console.ReadLine());
            Console.Write("Enter FSC Marks: ");
            int fscMarks = int.Parse(Console.ReadLine());
            Console.Write("Enter ECAT Marks: ");
            int ecatMarks = int.Parse(Console.ReadLine());

            BL student = new BL(name, id, matricMarks, fscMarks, ecatMarks);
            dataLayer.Addusertolist(student);
            dataLayer.AddstudenttoFile(student, filePath);
            Console.WriteLine("Student added successfully.");
        }

        public static void DeleteStudent(DL dataLayer, string filePath)
        {
            Console.Write("Enter Student ID to delete: ");
            string id = Console.ReadLine();

            dataLayer.DeleteStudent(filePath, id);
        }

        public static void ViewAllStudents()
        {
            foreach (BL student in DL.list)
            {
                Console.WriteLine($"Name: {student.getSN()}, ID: {student.getSI()}, Matric Marks: {student.getMatric_Marks()}, FSC Marks: {student.getfssmarks()}, ECAT Marks: {student.getEcat_Marks()}");
            }
        }

        public static void UpdateStudent(IDataOperations dataLayer, string filePath)
        {
            Console.Write("Enter Student ID to update: ");
            string id = Console.ReadLine();

            Console.Write("Enter new name: ");
            string newName = Console.ReadLine();
            Console.Write("Enter new Matric Marks: ");
            int newMatricMarks = int.Parse(Console.ReadLine());
            Console.Write("Enter new FSC Marks: ");
            int newFscMarks = int.Parse(Console.ReadLine());
            Console.Write("Enter new ECAT Marks: ");
            int newEcatMarks = int.Parse(Console.ReadLine());

            dataLayer.UpdateStudent(filePath, id, newName, newMatricMarks, newFscMarks, newEcatMarks);
        }
    }
}
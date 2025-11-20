using System;
using System.Collections.Generic;
using System.IO;
using UAMS.Business_logic;

namespace UAMS.Data_Layer
{
    internal interface IDataOperations
    {
        void SaveAllStudentsToFile(string filePath);

        void Addusertolist(BL item);
        void AddstudenttoFile(BL bl, string path);
        void UpdateStudent(string filepath, string id, string newName, int newMatricMarks, int newFscMarks, int newEcatMarks);
    }

    abstract class Operation
    {
        public abstract void Readstudentfromfile(string path);
    }

    internal class DL : Operation, IDataOperations
    {
        public static List<BL> list = new List<BL>();

        public void Addusertolist(BL item)
        {
            list.Add(item);
        }

        public void AddstudenttoFile(BL bl, string path)
        {
            try
            {
                using (StreamWriter writedata = new StreamWriter(path, true))
                {
                    writedata.WriteLine($"{bl.getSN()},{bl.getSI()},{bl.getMatric_Marks()},{bl.getfssmarks()},{bl.getEcat_Marks()}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while writing to file: {ex.Message}");
            }
        }

        public override void Readstudentfromfile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("File Does not Exist!");
                return;
            }

            using (StreamReader reader = new StreamReader(path))
            {
                string record;
                while ((record = reader.ReadLine()) != null)
                {
                    string[] data = record.Split(',');
                    if (data.Length == 5)
                    {
                        BL bl = new BL(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]));
                        Addusertolist(bl);
                    }
                }
            }
        }

        public  void SaveAllStudentsToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    foreach (BL student in list)
                    {
                        writer.WriteLine($"{student.getSN()},{student.getSI()},{student.getMatric_Marks()},{student.getfssmarks()},{student.getEcat_Marks()}");
                    }
                }
                Console.WriteLine("Student data successfully saved to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving student data to file: {ex.Message}");
            }
        }

        public void UpdateStudent(string filepath, string id, string newName, int newMatricMarks, int newFscMarks, int newEcatMarks)
        {
            bool studentFound = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].getSI() == id)
                {
                    list[i].setSN(newName);
                    list[i].setMM(newMatricMarks);
                    list[i].setFM(newFscMarks);
                    list[i].setEM(newEcatMarks);
                    studentFound = true;
                    break;
                }
            }

            if (studentFound)
            {
                SaveAllStudentsToFile(filepath);
                Console.WriteLine("Student updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        public void DeleteStudent(string filepath, string id)
        {
            bool studentFound = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].getSI() == id)
                {
                    list.RemoveAt(i);
                    studentFound = true;
                    break;
                }
            }

            if (studentFound)
            {
                Console.WriteLine("Student deleted successfully.");
                SaveAllStudentsToFile(filepath);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}

using System;
using System.IO;
using System.Numerics;
using System.Reflection.Metadata;

namespace program
{
    class Attendance
    {
        private string? id_imp;
        private string? day;
        private string? date;
        private string? hours;

        public static int num_record = 0;
        public void add_attendance()
        {
            //cheak id is true or not in files 
            Console.Clear();
            Console.WriteLine("Enter ID Emp :"); id_imp = Console.ReadLine();
            Console.WriteLine("Enter day :"); day = Console.ReadLine();
            Console.WriteLine("Enter Date :"); date = Console.ReadLine();
            Console.WriteLine("Enter time :"); hours = Console.ReadLine();
            string line = id_imp + ' ' + day + ' ' + date + ' ' + hours + "\n";
            File.AppendAllText("attendance.txt", line);
            Console.WriteLine("Edit Success\npress any key to continue"); Console.ReadKey();
        }
        public void delete_attendance()
        {
            Console.Clear();
            Console.WriteLine("Enter id ;"); id_imp = Console.ReadLine();
            string[] data_lines = File.ReadAllLines("attendance.txt");
            for (int i = 0; i < data_lines.Length; i++)
            {
                string id = "";
                for (int s = 0; s < data_lines[i].Length; s++)
                {
                    if (data_lines[i][s] == ' ')
                        break;
                    id += data_lines[i][s];
                }
                if (id == id_imp)
                {
                    File.WriteAllText("attendance.txt", "");
                    for (int s = 0; s < data_lines.Length; s++)
                    {
                        if (s == i) continue;
                        File.AppendAllText("attendance.txt", data_lines[s] + "\n");
                    }
                    Console.WriteLine("Delete Success\npress any key to continue"); Console.ReadKey(); break;
                }
            }
        }
        public void show_attendance()
        {
            Console.Clear();
            Console.WriteLine("Id  day    date    hours ");
            string data = File.ReadAllText("attendance.txt");
            Console.WriteLine(data); Console.ReadKey();

        }
    }
    class Employee
    {
        private string? id;
        private string? name;
        private string? salary;

        public void add_employee()
        {
            while (true)
            {
                bool loop = true;
                string[] data_lines = File.ReadAllLines("database.txt");
                while (loop)
                {
                    Console.Clear();
                    Console.WriteLine("Enter ID :"); id = Console.ReadLine();
                    Console.WriteLine("Enter Name :"); name = Console.ReadLine();
                    Console.WriteLine("Enter salary :"); salary = Console.ReadLine();
                    for (int i = 0; i < data_lines.Length || data_lines.Length == 0; i++)
                    {
                        if (data_lines.Length == 0)
                        {
                            loop = false; break;
                        }
                        string id2 = "";
                        for (int s = 0; s < data_lines[i].Length; s++)
                        {
                            if (data_lines[i][s] == ' ')
                                break;
                            id2 += data_lines[i][s];
                        }
                        if (id2 == id)
                        {
                            Console.WriteLine("ID Unavailable please choose Different ID ");
                            Console.WriteLine("Enter Any Key to Continue ");
                            Console.ReadKey();
                            loop = true; break;
                        }
                        else
                            loop = false;
                    }
                }
                string merge = id + ' ' + name + ' ' + salary + "\n";//edit split funcation
                File.AppendAllText("database.txt", merge);
                //File.AppendAllText("database.txt", Environment.NewLine);
                Console.WriteLine("Are You Want Add Again [Y/N]:");
                id = Console.ReadLine(); if (id == "N" || id == "n") break;
            }
        }
        public void edit_employee()
        {
            string g = File.ReadAllText("database.txt");
            if (g.Length > 0)
            {
                bool loop = true;
                while (loop)
                {
                    bool loop2 = false;
                    Console.Clear();
                    Console.WriteLine("Enter ID To Edit:"); id = Console.ReadLine();
                    string?[] data_lines = File.ReadAllLines("database.txt");
                    //call funcation to open file attendance same above this line
                    for (int i = 0; i < data_lines.Length; i++)
                    {
                        string id2 = "";
                        for (int s = 0; s < data_lines[i].Length; s++)
                        {
                            if (data_lines[i][s] == ' ')
                                break;
                            id2 += data_lines[i][s];
                        }
                        if (id2 == id)
                        {
                            Console.WriteLine("Enter New ID :"); id = Console.ReadLine();
                            Console.WriteLine("Enter New Name :"); name = Console.ReadLine();
                            Console.WriteLine("Enter New salary :"); salary = Console.ReadLine();
                            for (int s = 0; s < data_lines.Length; s++)
                            {
                                string id3 = "";
                                for (int k = 0; k < data_lines[s].Length; k++)
                                {
                                    if (data_lines[s][k] == ' ')
                                        break;
                                    id3 += data_lines[s][k];
                                }
                                if (id == id3)
                                {
                                    loop2 = true; break;
                                }
                            }
                            if (loop2)
                                break;
                            data_lines[i] = id + ' ' + name + ' ' + salary;
                            // here do for loop to search on id to edit new id in attendance file from attrebute data_split[i] in above
                            File.WriteAllLines("database.txt", data_lines);
                            Console.WriteLine("Edit Success\npress any key to continue"); Console.ReadKey();
                            loop = false; break;
                        }
                        if (loop2) break;
                    }
                    if (loop2) { Console.WriteLine("Change ID is Used\npress Any key to Again"); Console.ReadKey(); continue; }
                    if (loop == true) { Console.WriteLine("ID Not Found\nPress Any Key To Again"); Console.ReadKey(); }
                }
            }
            else { Console.WriteLine("No Any employee\npress Any key to continue"); Console.ReadKey(); }
        }
        public void delete_employee()
        {
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                string?[] data_lines = File.ReadAllLines("database.txt");
                Console.WriteLine("Enter ID to Delete:"); id = Console.ReadLine();
                for (int i = 0; i < data_lines.Length; i++)
                {
                    string id2 = "";
                    for (int s = 0; s < data_lines[i].Length; s++)
                    {
                        if (data_lines[i][s] == ' ')
                            break;
                        id2 += data_lines[i][s];
                    }
                    if (id2 == id)
                    {
                        File.WriteAllText("database.txt", "");
                        for (int s = 0; s < data_lines.Length; s++)
                        {
                            if (s == i) continue;
                            File.AppendAllText("database.txt", data_lines[s]);
                        }
                        // here do for loop to delete attendance file
                        Console.WriteLine("Delete Success\npress any key to continue"); Console.ReadKey();
                        loop = false; break;
                    }
                }
                if (loop)
                    Console.WriteLine("No Found ID press Any key to Again"); Console.ReadKey();
            }
        }
        public void show_employee()
        {
            
            Console.Clear();
            Console.WriteLine("ID    Name    Salary\n");
            string?[] data_split = File.ReadAllLines("database.txt");
            for (int i = 0; i < data_split.Length; i++)
            {
                Console.WriteLine(data_split[i]);
            }
            Console.WriteLine("press any key to continue"); Console.ReadKey();
        }
    }
    class ShowReport
    {
        private string? id;

        public void query_imp()
        {
            Console.Clear();
            Console.WriteLine("Enter ID "); id = Console.ReadLine();
            string?[] data_line = File.ReadAllLines("database.txt");
            string?[] attend_line = File.ReadAllLines("attendance.txt");
            double fees = 0;
            for (int i = 0; i < data_line.Length; i++)
            {
                string?[] id2 = data_line[i].Split(' ');
                if (id2[0] == id)
                {
                    Console.WriteLine(data_line[i]);
                    for (int s = 0; s < attend_line.Length; s++)
                    {
                        string?[] id3 = attend_line[s].Split(' ');
                        if (id3[0] == id)
                        {
                            Console.WriteLine(id3[1] + ' ' + id3[2] + ' ' + id3[3]);
                            string?[] hours = id3[3].Split(':');
                            int time = Convert.ToInt32(hours[0]);
                            if (time > 9)
                                fees += Convert.ToInt32(id2[2]) * 0.01;
                        }
                    }
                    Console.WriteLine("the total fees = " + fees);
                    Console.ReadKey();
                }
            }
        }
        public void query_attend()
        {

        }

    }
    class Program
    {
        static void Expert_Soluations()
        {
            Console.Clear();
            Console.WriteLine("                                     -------------------------------------------");
            Console.WriteLine("                                                   Expert Soluations            ");
            Console.WriteLine("                                     -------------------------------------------");
            Console.WriteLine("                                     1)Employee Managment   2)Attendance Managment");
            Console.WriteLine("                                     3)Show Report          4)Exit ");
        }
        static void Employee_Mangment()
        {
            Console.Clear();
            Console.WriteLine("                                      -----------------------------------------");
            Console.WriteLine("                                                  Employee Managment           ");
            Console.WriteLine("                                      -----------------------------------------");
            Console.WriteLine("                                      1)Add Employee         2)Edit Employee   ");
            Console.WriteLine("                                      3)Delete Employee      4)Show Employee   ");
            Console.WriteLine("                                                      5)Back ");
        }
        static void Attendance_Managment()
        {
            Console.Clear();
            Console.WriteLine("                                      -----------------------------------------");
            Console.WriteLine("                                                  Attendance Managment         ");
            Console.WriteLine("                                      -----------------------------------------");
            Console.WriteLine("                                      1)Add Attendance       2)Show Attendance  ");
            Console.WriteLine("                                      3)Delete Attendance    4)back  ");
        }
        static void Show_Report()
        {
            Console.Clear();
            Console.WriteLine("                                      -----------------------------------------");
            Console.WriteLine("                                                      Show Report              ");
            Console.WriteLine("                                      -----------------------------------------");
            Console.WriteLine("                                  1)Query on Employee           2)Query on attendance ");
            Console.WriteLine("                                                       3)back ");
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Expert_Soluations();
                int choise = Convert.ToInt32(Console.ReadLine());
                if (choise == 1)
                {
                    Employee obj = new Employee();
                    while (true)
                    {
                        Employee_Mangment();
                        int choise2 = Convert.ToInt32(Console.ReadLine());
                        if (choise2 == 1)
                            obj.add_employee();
                        else if (choise2 == 2)
                            obj.edit_employee();
                        else if (choise2 == 3)
                            obj.delete_employee();
                        else if (choise2 == 4)
                            obj.show_employee();
                        else if (choise2 == 5)
                            break;
                    }
                }
                else if (choise == 2)
                {
                    Attendance obj = new Attendance();
                    while (true)
                    {
                        Attendance_Managment();
                        int choise2 = Convert.ToInt32(Console.ReadLine());
                        if (choise2 == 1)
                            obj.add_attendance();
                        else if (choise2 == 2)
                            obj.show_attendance();
                        else if (choise2 == 3)
                            obj.delete_attendance();
                        else if (choise2 == 4)
                            break;
                    }
                }
                else if (choise == 3)
                {
                    ShowReport obj = new ShowReport();
                    while (true)
                    {
                        Show_Report();
                        int choise2 = Convert.ToInt32(Console.ReadLine());
                        if (choise2 == 1)
                            obj.query_imp();
                        else if (choise2 == 2)
                            obj.query_attend();
                        else if (choise2 == 3)
                            break;
                    }
                }
                else if (choise == 4)
                {
                    break;
                }

            }
        }
    }

}
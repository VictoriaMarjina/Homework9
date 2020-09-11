using System;
using System.Globalization;
using System.Net;

namespace Zadanie1
{
    public class Program
    {
        public static void Main()
        {
           
            int w = 0;
            int m = 0;
            Student database = new Student();
            database = new Student(m);
            int j = 0;
            int x = 0;
            Aspirant database2 = new Aspirant();
            database2 = new Aspirant(x);
            Switch(database,database2,w,m,j,x);

        }

        public static void Switch(Student database,Aspirant database2, int w, int m, int j,int x)
        {
            Console.WriteLine("нажмите 1 чтобы добавить студента");
            Console.WriteLine("нажмите 2 чтобы добавить аспиранта");
            Console.WriteLine("нажмите 3 для вывода информации о студентах");
            Console.WriteLine("нажмите 4 для вывода информации об аспирантах");
            Console.WriteLine("нажмите 5 для выхода");
            string Menyu = Console.ReadLine();
            switch (Menyu)
            {
                case "1":
                    Console.WriteLine("Сколько студентов вы хотите добавить в базу?");
                    int a = InNum();
                    Array.Resize(ref database.data, m + a);
                    database = Student.AddStu(database,database2, a, w, m+a,j,x);
                   
                    w=w+a;
                    break;
                case "2":
                    Console.WriteLine("Сколько аспирантов вы хотите добавить в базу?");
                    int b = InNum();
                    Array.Resize(ref database2.dataAsp, m + b);
                    database2 = Aspirant.AddAsp(database,database2, b, j, x+b, w,m);
                    j=j+b;
                    break;
                case "3":
                    Student.PrintInfoStu(database,database2,m, w,j,x);
                    break;
                case "4":
                    Aspirant.PrintInfoStu(database,database2, x, w,j,m);
                    break;
                case "5":
                    break;
                default:
                    break;
            }
           
        }
        public static bool CheckNum(string a)
        {
            if (int.TryParse(a, out int b))
                return true;
            else
                return false;
        }
        public static bool CheckStr(string a)
        {
            char[] ch = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < ch.Length; j++)
                {
                    if (a[i] == ch[j])
                        return false;
                }
            }
            return true;
        }
        public static int InNum()
        {

            string a = Console.ReadLine();
            bool b = CheckNum(a);
            if (b == true)
            {
                int c = Convert.ToInt32(a);
                return c;
            }
            else
            {
                Console.Write("не коректные данные повторите ввод:\t");
                return InNum();
            }

        }
        public static string InStr()
        {

            string a = Console.ReadLine();
            bool b = CheckStr(a);
            if (b == true)
                return a;
            else
            {
                Console.Write("не коректные данные повторите ввод:\t");
                return InStr();
            }

        }
        public static string InZachet()
        {
            int a = InNum();
            if (a < 10000000 && a > 99999999)
            {
                string b = Convert.ToString(a);
                return b;
            }
            else
            {
                Console.Write("номер зачетной книжки дожен быть не меньше и не длиннее 8символов");
                return InZachet();
            }
        }

    }

    public class Student
    {
        private string name;
        private string lastName;
        private int kurs;
        public int Kurs { 
            set {
                if (value < 0 || value > 10)
                {
                    Console.WriteLine("Номер курса должен быть задан в диапазоне от 1 до 10");
                    Program.Main();
                }
                else
                {
                    kurs = value;
                }
            }
            get { return kurs; }
        }
        private int zachet;
        public static int n;
        public static int N { get; set; }
        public  Student[] data;
        public Student(int n)
        {
            data = new Student[n];
        }
        public Student()
        {
           
        }
        public Student(string name, string lastName, int kurs, int zachet, int n)
        {
            data = new Student[n];
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public int Zachet
        {
            get { return zachet; }
            set { zachet = value; }
        }
        public Student this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        public static Student AddStu(Student database,Aspirant database2, int a, int i, int m,int j,int x)
        {
            if (a != 0)
                {
                    database[i] = new Student();
                    Console.WriteLine("введите имя студента");
                    database[i].Name = Program.InStr();
                    Console.WriteLine("введите фамилию студента");
                    database[i].LastName = Program.InStr();
                    Console.WriteLine("введите курс обучения");
                    database[i].Kurs = Program.InNum();
                    Console.WriteLine("введите номер зачетной книжки");
                    database[i].Zachet = Program.InNum();
               /* Console.WriteLine(database[0].Name);*/
                return AddStu(database,database2, a - 1, i + 1, m, j,x);
                }
                else
                {
                    AddMoreStud(database,database2, i, m, j,x);
                    return database;
                } 
           

        }
        public static Student AddMoreStud(Student database, Aspirant database2, int i, int m, int j,int x)
        {
            Console.WriteLine("чтобы добавить ещё 1 студента нажмите 1");
            Console.WriteLine("чтобы выйти в меню нажмите любую цифру");
            int a = Program.InNum();
            if (a == 1)
            {
                Array.Resize(ref database.data, m + a);
                return AddStu(database, database2, a,  m, m + a,j,x);
            }
            else {

                Program.Switch(database,database2, i, m,j,x);
                return database;
            }
    

        }
        public static void PrintInfoStu(Student database, Aspirant database2, int m, int w,int j,int x)
        {
            if (m!=0)
            {
                Console.WriteLine("Для информации об одном из студентов нажмите 1 \n Для вывода информации о всех студентах в базе данных нажмите 2 \n Если передумали нажмите 3");
                string info = Console.ReadLine();
                switch (info)
                {
                    case "1":
                        Console.WriteLine("Введите номер студента в базе данных");
                        int a = Program.InNum();
                        PrintInfo(database,database2,a,w,m,j,x);
                        break;
                    case "2":
                        PrintAllInfo(database,database2,m,w,j,x);
                        break;
                    case "3":
                        Program.Switch(database,database2, w, m,j,x);
                        break;

                }
            }
            else
            {
                Console.WriteLine("Информация о студентах не была добавлена");
                Program.Main();
            }

        }

        public static void PrintInfo(Student database, Aspirant database2, int i,int w,int m,int j, int x)
        {

            Console.WriteLine($"имя фамилия студента: {database[i].Name} {database[i].LastName} \n номер зачетной книги: {database[i].Zachet}  \n курс обучения: {database[i].Kurs}");
            Program.Switch(database,database2, w, m,j, x);
        }
        public static void PrintAllInfo(Student database, Aspirant database2, int m, int w, int j,int x)
        {

            for (int i = 0; i < m; i++)
            {

                Console.WriteLine($"имя фамилия студента: {database[i].Name} {database[i].LastName} \n номер зачетной книги: {database[i].Zachet}  \n курс обучения: {database[i].Kurs}");

            }
            Program.Switch(database,database2, w, m,j,x);
        }
    }


    public class Aspirant : Student
    {
        private string diss;
       
        public Aspirant[] dataAsp;
        public Aspirant() { }
        public Aspirant(int n)
        {
            dataAsp = new Aspirant[n];
        }
        public Aspirant(string name, string lastName, int kurs, int zachet, string diss, int n)
            : base(name, lastName, kurs, zachet, n)
        {
            dataAsp = new Aspirant[n];
        }
        public string Diss
        {
            get { return diss; }
            set { diss = value; }
        }
        public new Aspirant this[int indexAsp]
        {
            get
            {
                return dataAsp[indexAsp];
            }
            set
            {
                dataAsp[indexAsp] = value;
            }
        }
        public static Aspirant AddAsp(Student database,Aspirant database2, int a, int i, int x,int w,int m)
        {
            if (a != 0)
            {
                database2[i] = new Aspirant();
                Console.WriteLine("введите имя студента");
                database2[i].Name = Program.InStr();
                Console.WriteLine("введите фамилию студента");
                database2[i].LastName = Program.InStr();
                Console.WriteLine("введите курс обучения");
                database2[i].Kurs = Program.InNum();
                Console.WriteLine("введите номер зачетной книжки");
                database2[i].Zachet = Program.InNum();
                Console.WriteLine("введите тему диссертации");
                database2[i].Diss = Program.InStr();
              /*  Console.WriteLine(database2[0].Name);*/

                return AddAsp(database, database2, a - 1, i + 1, x,w,m);
            }
            else
            {
                AddMoreAsp(database, database2, i, x,w,m);
                return database2;
            }


        }
        public static Aspirant AddMoreAsp(Student database,Aspirant database2, int i, int x,int w,int m)
        {
            Console.WriteLine("чтобы добавить ещё 1 аспиранта нажмите 1");
            Console.WriteLine("чтобы выйти в меню нажмите любую цифру");
            int a = Program.InNum();
            if (a == 1)
            {
                Array.Resize(ref database2.dataAsp, x + a);
                return AddAsp(database,database2, a, x, x + 1,w,m);
            }
            else
            {

                Program.Switch(database, database2, w, m,i,x);
                return database2;
            }


        }
        public static new void PrintInfoStu(Student database, Aspirant database2, int x, int w,int j,int m)
        {
            if (x != 0)
            {
                Console.WriteLine("Для информации об одном из студентов нажмите 1 \n Для вывода информации о всех студентах в базе данных нажмите 2 \n Если передумали нажмите 3");
                string info = Console.ReadLine();
                switch (info)
                {
                    case "1":
                        Console.WriteLine("Введите номер студента в базе данных");
                        int a = Program.InNum();
                        PrintInfo(database, database2, a, x, w,j,m);
                        break;
                    case "2":
                        PrintAllInfo(database,database2, x, w,j,m);
                        break;
                    case "3":
                        Program.Switch(database,database2, w, m,j,x);
                        break;

                }
            }
            else
            {
                Console.WriteLine("Информация о студентах не была добавлена");
                Program.Main();
            }

        }

        public static new void PrintInfo(Student database, Aspirant database2, int i, int x, int w, int j,int m)
        {

            Console.WriteLine($"имя фамилия студента: {database2[i].Name} {database2[i].LastName} \n номер зачетной книги: {database2[i].Zachet}  \n курс обучения: {database2[i].Kurs} \n тема диссертации: {database2[i].Diss}");
            Program.Switch(database,database2, w, m,j,x);
        }
        public static new void PrintAllInfo(Student database,Aspirant database2, int x, int w, int j, int m)
        {

            for (int i = 0; i < x; i++)
            {

                Console.WriteLine($"имя фамилия студента: {database2[i].Name} {database2[i].LastName} \n номер зачетной книги: {database2[i].Zachet}  \n курс обучения: {database2[i].Kurs} \n тема диссертации: {database2[i].Diss}");

            }
            Program.Switch(database,database2, w, m,j,x);
        }

    }
}

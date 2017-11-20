using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exercise8A
{
    class Program
    {
        static Student[] students;
        static int count = 0;

        static void Main(string[] args)
        {
            students = new Student[100];

            int choice = 0;

            do
            {
                if (choice == 0) Console.WriteLine("1. Добавяне на студент");
                else Console.WriteLine("\n1. Добавяне на студент");
                Console.WriteLine("2. Извеждане на среден успех");
                Console.WriteLine("3. Запис на файл");
                Console.WriteLine("4. Зареждане от файл");
                Console.WriteLine("5. Най-добър студент");
                Console.WriteLine("0. Изход\n");

                choice = ReadInt("Въведете команда: ");

                switch (choice)
                {
                    case 1:
                        Student student = new Student();
                        student.Name = ReadString("\nИме: ");
                        student.FacultyNumber = ReadString("Фак. №: ");
                        int marksCount = ReadInt("Брой оценки: ");
                        student.Marks = new decimal[marksCount];

                        for (int i = 0; i < marksCount; i++)
                            student.Marks[i] = ReadDecimal("Оценка " + (i + 1) + ": ");

                        students[count++] = student;
                        break;

                    case 2:
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine("\nФак. №: {0}\tИме: {1}\tСр. успех: {2}", students[i].FacultyNumber, students[i].Name, GetStudentAverage(i));
                        }

                        break;

                    case 3:

                        string[] lines = new string[count * 3];

                        for (int i = 0; i < count; i++)
                        {
                            lines[3 * i + 0] = students[i].Name;
                            lines[3 * i + 1] = students[i].FacultyNumber;
                            lines[3 * i + 2] = "";

                            foreach (var mark in students[i].Marks)
                                lines[3 * i + 2] += mark + " ";
                        }

                        File.WriteAllLines("data.txt", lines);
                        Console.WriteLine("\nФайлът е записан успешно!");

                        break;

                    case 4:
                        if (!File.Exists("data.txt"))
                        {
                            Console.WriteLine("Файлът не съществува!");
                            break;
                        }

                        count = 0;

                        string[] fileLines = File.ReadAllLines("data.txt");

                        for (int i = 0; i < fileLines.Length; i += 3)
                        {
                            Student _student = new Student();

                            _student.Name = fileLines[i];
                            _student.FacultyNumber = fileLines[i + 1];

                            string[] markTexts = fileLines[i + 2].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            _student.Marks = new decimal[markTexts.Length];

                            for (int k = 0; k < _student.Marks.Length; k++)
                                _student.Marks[k] = decimal.Parse(markTexts[k]);

                            students[count++] = _student;
                        }

                        break;
                    case 5:

                        decimal maxAverage = 0;
                        int bestStudentIndex = 0;

                        for (int i = 0; i < count; i++)
                        {
                            decimal average = GetStudentAverage(i);

                            if (average > maxAverage)
                            {
                                maxAverage = average;
                                bestStudentIndex = i;
                            }
                        }

                        Console.WriteLine("\nФак. №: {0}\tИме: {1}\tСр. успех: {2}\n", students[bestStudentIndex].FacultyNumber, students[bestStudentIndex].Name, GetStudentAverage(bestStudentIndex));
                        
                        foreach (decimal mark in students[bestStudentIndex].Marks)
                        {
                            Console.Write(mark + " ");
                            Console.WriteLine();
                        }

                        break;
                }
            } while (choice != 0);
        }

        static int ReadInt(string prompt)
        {
            int result;

            Console.Write(prompt);

            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write(prompt);
            }

            return result;
        }

        static decimal ReadDecimal(string prompt)
        {
            decimal result;

            Console.Write(prompt);

            while (!decimal.TryParse(Console.ReadLine(), out result))
            {
                Console.Write(prompt);
            }

            return result;
        }

        static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        static decimal GetStudentAverage(int index)
        {
            decimal avg = 0;

            foreach (var mark in students[index].Marks)
                avg += mark;

            if (students[index].Marks.Length != 0)
            {
                avg /= students[index].Marks.Length;
            }

            return avg;
        }
    }
}

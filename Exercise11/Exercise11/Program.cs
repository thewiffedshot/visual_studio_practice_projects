using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exercise11
{
    class Program
    {
        static string text;

        static void Main(string[] args)
        {
            try
            {
                using (var f = File.Open("storage.txt", FileMode.Open))
                {
                    byte[] buffer = new byte[5];
                    DynamicArray contents = new DynamicArray();

                    int read;

                    do
                    {
                        read = f.Read(buffer, 0, buffer.Length);

                        contents.AddRange(buffer, read);
                    }
                    while (read != 0);

                    text = DecodeBytes(contents.ToArray());
                }

                Console.WriteLine(text);
            }
            catch (FileNotFoundException e)
            {
                Console.Write("Файлът не е намерен: ");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Неочаквана грешка: " + e.Message);
            }

            Console.ReadKey();
        }

        static string DecodeBytes(byte[] buf)
        {
            return Encoding.UTF8.GetString(buf);
        }
    }
}

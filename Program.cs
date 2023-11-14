using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment12
{
    internal class Program
    {
        static string DefaultPath = @"D:\assign12\";

        static void Main(string[] args)
        {
            Console.WriteLine("File Handling Program");

            while (true)
            {
                Console.WriteLine("\n1. Create File\n2. Read File\n3. Append to File\n4. Delete File\n5. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateFile();
                        break;

                    case 2:
                        ReadFile();
                        break;

                    case 3:
                        AppendToFile();
                        break;

                    case 4:
                        DeleteFile();
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void CreateFile()
        {

            Console.Write("Enter the file name: ");
            string fileName = Console.ReadLine();

            Console.Write("Enter the content to write to the file: ");
            string content = Console.ReadLine();

            string filePath = Path.Combine(DefaultPath, fileName);

            try
            {
              
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                File.WriteAllText(filePath, content);

                Console.WriteLine($"File '{fileName}' created successfully at path: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating file: {ex.Message}");
            }


        }

        static void ReadFile()
        {
            Console.Write("Enter the file name to read: ");
            string fileName = Console.ReadLine();

            if (File.Exists(fileName))
            {
                string content = File.ReadAllText(fileName);
                Console.WriteLine($"\nContent of '{fileName}':\n{content}");
            }
            else
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
        }

        static void AppendToFile()
        {
            Console.Write("Enter the file name to append: ");
            string fileName = Console.ReadLine();

            if (File.Exists(fileName))
            {
                Console.Write("Enter the content to append to the file: ");
                string content = Console.ReadLine();

                File.AppendAllText(fileName, content);

                Console.WriteLine($"Content appended to '{fileName}' successfully.");
            }
            else
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
        }

        static void DeleteFile()
        {
            Console.Write("Enter the file name to delete: ");
            string fileName = Console.ReadLine();

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
                Console.WriteLine($"File '{fileName}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the directory path:");
        string directoryPath = Console.ReadLine();

        Console.WriteLine("Enter the file extension:");
        string extension = Console.ReadLine();

        Console.WriteLine("Enter the text to search:");
        string searchText = Console.ReadLine();

        SearchFiles(directoryPath, extension, searchText);
    }

    static void SearchFiles(string directoryPath, string extension, string searchText)
    {
        try
        {
            IEnumerable<string> files = Directory.EnumerateFiles(directoryPath, $"*.{extension}", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                try
                {
                    string fileContent = File.ReadAllText(file);

                    if (fileContent.Contains(searchText))
                    {
                        Console.WriteLine($"Found in file: {file}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading file {file}: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error searching files: {ex.Message}");
        }
    }
}

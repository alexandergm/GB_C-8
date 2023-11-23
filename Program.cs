using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: utility.exe <extension> <text>");
            return;
        }

        string extension = args[0];
        string searchText = args[1];

        string currentDirectory = Directory.GetCurrentDirectory();
        SearchFiles(currentDirectory, extension, searchText);
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

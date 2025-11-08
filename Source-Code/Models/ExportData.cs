// fix the UT [DONE]
namespace Data_Set_Analyzer;

using System;
using System.IO;
public class ExportData
{
    public ExportData() { }

    public static void Export(NumberSorter data)
    {
        Console.Clear();
        bool loop = true;
        while (loop)
        {
            Console.WriteLine(">> DSA\\ FileSelector\\ Modify/Properties Selection\\ Export Data\n");
            Program.title();
            Console.WriteLine
            (
                "Select Export Location\n" +
                "----------------------\n\n" +
                "Press 1: In The Exports Folder\n" +
                "Press 2: Custom Path\n" +
                "Press B: To Back To Modify/Properties Selection"
            );
            Console.Write("> ");
            string input = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(input, out int _))
            {
                input = input.ToUpper();
            }
            switch (input)
            {
                case "1":
                    loop = false;
                    ExportsFolder(data);
                    Console.Clear();
                    break;

                case "2":
                    loop = false;
                    CustomPath(data);
                    Console.Clear();
                    break;

                case "B":
                    loop = false;
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Please enter a valid option!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
            }

        }
    }
    
    public static void ExportsFolder(NumberSorter data) 
    // fix the interface [DONE]
    // ask to give a .txt file name[DONE]
    // chack if it's valid[DONE]
    // then make and save the data in that .txt file [DONE]
    // chack if the there is another file of same name[DONE]
    // if there is, tell user to change the name[DONE]
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine(">> DSA\\ FileSelector\\ Modify/Properties Selection\\ Export Data\\ Exports Folder\n");
            Program.title();
            Console.WriteLine("Add Name for the export file? (Y/N)");
            Console.Write("> ");

            string input = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(input, out int _))
            {
                input = input.ToUpper();
            }

            if (input == "Y")
            {
                Console.Clear();
                while (true)
                {
                    Console.WriteLine(">> DSA\\ FileSelector\\ Modify/Properties Selection\\ Export Data\\ Exports Folder\\ File Name\n");
                    Program.title();
                    Console.WriteLine("Please Enter a Valid File Name:");
                    Console.Write("> ");
                    string fileName = Console.ReadLine() ?? string.Empty;

                    if (ValidFileName(fileName))
                    {
                        fileName += ".txt";
                        string exportPath = Path.Combine(Directory.GetCurrentDirectory(), "Exports");
                        // gets the working directory's path; in this case it is D:\*********\Data Set Analyzer
                        // returns D:\*********\Data Set Analyzer\Exports

                        string filePath = Path.Combine(exportPath, fileName);

                        List<int> eData = data.ConvertToList();
                        string[] toExport = new string[eData.Count];
                        for (int i = 0; i < eData.Count; i++)
                        {
                            string numbers = eData[i].ToString();
                            toExport[i] = numbers;
                        }
                        Console.WriteLine($"Exporting In.. ");
                        for (int i = 1; i < 4; i++)
                        {
                            Console.WriteLine($"> {4 - i}");
                            Thread.Sleep(1000);
                        }
                        File.WriteAllLines(filePath, toExport);
                        Console.WriteLine($"> DONE!");
                        Thread.Sleep(1500);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nFile Name Is Not Valid!");
                        Thread.Sleep(1500);
                        Console.Clear();
                        continue;
                    }
                }
                break;
            }
            else if (input == "N")
            {
                string exportPath = Path.Combine(Directory.GetCurrentDirectory(), "Exports");
                string filePath = Path.Combine(exportPath, $"{DateTime.Now:yyyy-MM-dd--HH-mm-ss}.txt");
                // just DataTime causes error as there will be \ : which is not allowed in file names
                List<int> eData = data.ConvertToList();
                string[] toExport = new string[eData.Count];
                for (int i = 0; i < eData.Count; i++)
                {
                    string numbers = eData[i].ToString();
                    toExport[i] = numbers;
                }
                Console.WriteLine($"Exporting In.. ");
                for (int i = 1; i < 4; i++)
                {
                    Console.WriteLine($"> {4 - i}");
                    Thread.Sleep(1000);
                }
                File.WriteAllLines(filePath, toExport);
                Console.WriteLine($"> DONE!");
                Thread.Sleep(1500);
                break;
            }
            else
            {
                Console.WriteLine("Enter A Valid Input!");
                Thread.Sleep(1500);
                Console.Clear();
                continue;
            }
        }
    }

    public static void CustomPath(NumberSorter data)
    {
        Console.Clear();
        //string path = "B";
        while (true)
        {
            Console.WriteLine(">> DSA\\ FileSelector\\ Modify/Properties Selection\\ Export Data\\ By Path(Export Folder Location)\n");
            Program.title();
            Console.WriteLine
            (
                "Enter B: To Go Back\n\n" +
                "Enter The Full Path Of The Custom Export Folder\n" +
                "-----------------------------------------------"
            );
            string folderPath = Console.ReadLine() ?? string.Empty;
            if (folderPath.ToUpper() == "B")
            {
                Console.Clear();
                Export(data);
                break;
            }

            if (!Directory.Exists(folderPath) /* || !folderPath.Contains(".txt")*/)
            {
                Console.WriteLine("\nEnter A Valid Path!");
                Thread.Sleep(1500);
                Console.Clear();
                continue;
            }
            else
            {
                Console.Clear();
                while (true)
                {
                    Console.WriteLine(">> DSA\\ FileSelector\\ Modify/Properties Selection\\ Export Data\\ Exports Folder\\ By Path(Export Folder Location)\\ File Name\n");
                    Program.title();
                    Console.WriteLine("Please Enter a Valid File Name:");
                    Console.Write("> ");
                    string fileName = Console.ReadLine() ?? string.Empty;

                    if (ValidFileName(fileName))
                    {
                        fileName += ".txt";
                        string filePath = Path.Combine(folderPath, fileName);

                        List<int> eData = data.ConvertToList();
                        string[] toExport = new string[eData.Count];
                        for (int i = 0; i < eData.Count; i++)
                        {
                            string numbers = eData[i].ToString();
                            toExport[i] = numbers;
                        }
                        Console.WriteLine($"Exporting In.. ");
                        for (int i = 1; i < 4; i++)
                        {
                            Console.WriteLine($"> {4 - i}");
                            Thread.Sleep(1000);
                        }
                        File.WriteAllLines(filePath, toExport);
                        Console.WriteLine($"> DONE!");
                        Thread.Sleep(1500);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nFile Name Is Not Valid!");
                        Thread.Sleep(1500);
                        Console.Clear();
                        continue;
                    }
                }
                break;
            }
        }
    }

    public static bool ValidFileName(string fileName)
    {
        string exportPath = Path.Combine(Directory.GetCurrentDirectory(), "Exports");
        // gets the working directory's path; in this case it is D:\*********\Data Set Analyzer
        // returns D:\*********\Data Set Analyzer\Exports

        bool isValid = !string.IsNullOrEmpty(fileName) &&
                      fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0 &&
                      !File.Exists(Path.Combine(exportPath, fileName));
        // core logic of chacking the validity is taken from this Source - https://stackoverflow.com/a/4650495 Posted by Phil Hunt
        return isValid;
    }
}

// NotJustNumber.txt type data files should not cause an error [DONE]
// should only take the valid integers[DONE]

//FileSelecter should also take data from different input data formats e.g. [DONE]
//(1 1 1 1) [DONE]
//(1, 1, 1, 1, 1) [DONE]
//(1   1, 1   ,  1 , , 1)[DONE]
// make .txt file with different data types and formats[DONE]

// add select from Data folder or select by path[DONE]
namespace Data_Set_Analyzer;

using System;
using System.IO;
using System.Threading;

public class FileSelecter
{
    public FileSelecter() { }
    public static NumberSorter SelectFileFromFolder()
    {
        Console.Clear();
        NumberSorter numberList = new NumberSorter();
        string cd = Directory.GetCurrentDirectory();
        // gets the working directory's path; in this case it is D:\*********\Data Set Analyzer

        string dataPath = Path.Combine(cd, "Data");
        // returns D:\*********\Data Set Analyzer\Data

        string[] allFiles = Directory.GetFiles(dataPath, "*.txt");
        // makes an array with the name of all the files/folders in dataPath's 
        // path, "*.txt" specifies to only select files with .txt extension 

        List<string> dataFiles = new List<string>();

        for (int i = 0; i < allFiles.Length; i++)
        {
            string[] buffer = allFiles[i].Split('\\');
            // in strings \\ means "\"

            dataFiles.Add(buffer[buffer.Length - 1]);
        }
        // separates and makes a list of .txt file names from their paths

        string filePath = "";
        while (true)
        {
            Console.WriteLine(">> DSA\\ FileSelector\n");
            Program.title();
            Console.WriteLine("Available Files:");
            if (allFiles.Length == 0)
            {
                Console.WriteLine
                (
                    "\nNo Data File Found!\n" +
                    "[Press Ctrl + C to Exit]\n"
                );
            }
            for (int i = 0; i < dataFiles.Count; i++)
            {
                Console.WriteLine($"{i + 1}-> {dataFiles[i]}");
            }
            Console.WriteLine("\nType the File Name or Enter the File number, Containing the Number Data: ");
            Console.Write("> ");
            // prints all the .txt file names for selection

            string fileName = Console.ReadLine() ?? string.Empty;
            // Just an extra masure, if for any reson input is 
            // null then [string.Empty = ""] fileName set to "".

            if (!dataFiles.Contains(fileName))
            {
                if (!int.TryParse(fileName, out int fNumber) || fNumber < 1 || fNumber > dataFiles.Count)
                {
                    Console.WriteLine("\nFile does not exist!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    continue;
                }
            }
            // chacks if the input is valid for file numbers and names
            // inputs will go any further if its not valid beacuse of continue
            // so we do no need to chack it its valid or not later. we can just select file the based on the input

            if (int.TryParse(fileName, out int fiNumber))
            {
                string fName = dataFiles[fiNumber - 1];
                // -1 beacuse file is selected base on its index number which starts at 0
                filePath = Path.Combine(dataPath, fName);
                break;
            }
            else
            {
                filePath = Path.Combine(dataPath, fileName);
                break;
            }
        }

        string[] inputNumbers = File.ReadAllLines(filePath);
        // takes the full path of the data file and reads it line by line

        foreach (string input in inputNumbers)
        {
            string[] stringPart = input.Split(",");
            foreach (string part in stringPart)
            {
                string[] stringParts = part.Split(" ");
                foreach (string parts in stringParts)
                {
                    if (int.TryParse(parts, out int number))
                    {
                        numberList.AddTONumberSorter(number);
                    }
                }
            }
        }
        // Converts the line (this case: there is one number per line ) strings to int and adds to the NumberSorter numberList

        Console.Clear();
        return numberList;
        //returns NumberSorter numberList
    }

    public static string SelectFileFromPath() // this mathod might look small it took me 2 and half hour to make it work properly
    {
        Console.Clear();
        string path = "B";
        while (true)
        {
            Console.WriteLine(">> DSA\\ FileSelector\n");
            Program.title();
            Console.WriteLine
            (
                "Enter B: To Go Back\n\n" +
                "Enter The Full Path Of The Data File\n" +
                "------------------------------------"
            );
            string filePath = Console.ReadLine() ?? string.Empty;
            if (filePath.ToUpper() == "B")
            {
                Console.Clear();
                return path;
            }

            if (!File.Exists(filePath) || !filePath.Contains(".txt"))
            {

                Console.WriteLine("\nEnter A Valid Path!");
                Thread.Sleep(1500);
                Console.Clear();
                continue;
            }
            else
            {
                return filePath;
            }
        }
    }
}

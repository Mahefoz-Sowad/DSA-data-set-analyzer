// redesign the terminal [Done]
// add location on top [Done] Learn a better way
// Add all the mathod for NS [DONE]
// add option to save and export the analyzed data to a .txt file in a different folder called Exports (make a separate cs file for this) [DONE]
// add export folder or custom path[DONE]



//TO-DO

//QUALITY OF LIFE IMPROVEMENTS
//----------------------------
// Add cancel option
// Add restore last change
// add press and enter type inputs

namespace Data_Set_Analyzer;

using System;
using System.Threading;
public class UserTerminal
{
    private /*readonly*/ NumberSorter sorter;
    // readonly makes it so that the sorter variable can only be assigned once

    public UserTerminal()
    {
        sorter = new NumberSorter();
        SelectFile();
    }
    // after the constructor assigns the returning value from FileSelecter.SelectFile() to sorter variable
    // it can not be reassigned to any other value(of NumberSorter type) again in the class
    public void SelectFile() //add new mathod from FS [DONE]
    {
        sorter = new NumberSorter();
        Console.Clear();
        bool loop = true;
        while (loop)
        {

            Console.WriteLine(">> DSA\n");
            Program.title();
            Console.WriteLine
            (
                "Press 1: To Select File From The Data Folder\n" +
                "Press 2: To Select File By The File's Path\n"
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
                    loop = false;//when exiting a mathod make sure to break it. We can call it later if we need to.
                    sorter = FileSelecter.SelectFileFromFolder();
                    break; // break; breaks out of the switch loop not the while loop

                case "2":
                    string path = FileSelecter.SelectFileFromPath();
                    if (path == "B")
                    {
                        break;
                    }
                    else
                    {
                        string[] inputLines = File.ReadAllLines(path);
                        foreach (string inputLine in inputLines)
                        {
                            string[] linePart = inputLine.Split(",");
                            foreach (string part in linePart)
                            {
                                string[] lineParts = part.Split(" ");
                                foreach (string parts in lineParts)
                                {
                                    if (int.TryParse(parts, out int number))
                                    {
                                        sorter.AddTONumberSorter(number);
                                    }
                                }
                            }
                        }

                        /*
                        foreach (string num in inputNumbers)
                        {
                            int number = Convert.ToInt32(num);
                            sorter.AddTONumberSorter(number);
                        }
                        */
                        Console.Clear();
                        loop = false;
                        break;

                    }

                default:
                    Console.WriteLine("\nPlease enter a valid option!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
            }
        }
    }
    
    public void MakeTerminal()
    {
        Functionalities();
    }

    private void Functionalities()
    {
        // add all mathods from NS and 
        // Last task (add options inside options, option to go back a to the mother option and change the name ) 

        bool loop = true;
        while (loop)
        {
            if (sorter.size() == 0)
            {
                for (int i = 1; i < 4; i++)
                {
                    Console.Write
                    (
                        "No Data Was Found To Be Analyzed!\n" +
                        "\n" +
                        $"Exiting In.. {4 - i}"
                    );
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                break;
            }
            Console.WriteLine(">> DSA\\ FileSelector\\ Modify/Properties Selection\n");
            Program.title();
            sorter.NumberCount();
            Console.WriteLine
            (
                "Press 1: To Modify The Data Set\n" +
                "Press 2: To See Data Set's Properties\n" +
                "Press 3: To Export Data as A .txt File\n" +
                "Press B: To Go Back To File Selection\n" +
                "Enter X: To Exit"
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
                    loop = false;//when exiting a mathod make sure to break it. We can call it later if we need to.
                    ModifyingFunctionalities();
                    break; // break; breaks out of the switch loop not the while loop

                case "2":
                    loop = false;
                    PropertiesFunctionalities();
                    break;

                case "3":
                    ExportData.Export(sorter);
                    break;

                case "B":
                    Console.Clear();
                    SelectFile();
                    //sorter = FileSelecter.SelectFileFromFolder();
                    break;

                case "X":
                    loop = false;
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("\nPlease enter a valid option!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
            }
        }
    }

    private void ModifyingFunctionalities()
    {
        bool loop = true;
        while (loop)
        {
            Console.Clear();
            Console.WriteLine(">> DSA\\ FileSelector\\ Modify/Properties Selection\\ Modifying Functionalities\n");
            Program.title();
            Console.WriteLine
            ("All Available Modifying Functionalities\n" +
            printHLine("All Available Modifying Functionalities")
            );

            sorter.NumberCount();

            Console.WriteLine
            (
                "Press 1: To Sort The Data Set\n" +
                "Press 2: To Remove Duplicate Numbers From The Data Set\n" +
                "Press 3: To Select All Unique Numbers From The Data Set\n" +
                "Press 4: To Print The Data Set\n" +
                "\n" +
                "Press 5: To Add Numbers In The Data Set\n" +
                "Press 6: To Print All User Added Numbers\n" +
                "Press 7: To Remove All User Added Numbers From The Data Set\n" +
                "\n" +
                "Press R: To Restore The Original Data Set\n" +
                "Press B: To Go Back To Modify/Properties Selection \n" +
                "Enter X: To Exit"
            );
            Console.Write("> ");

            string input = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(input, out int x)) { input = input.ToUpper(); }

            switch (input)
            {
                case "1":
                    sorter.SortSet();
                    break;

                case "2":
                    sorter.RemoveDuplicates();
                    break;

                case "3":
                    sorter.SelectAllUniqueNumbers();
                    break;

                case "4":
                    sorter.PrintModifiedSet();
                    break;

                case "5":
                    sorter.AddNumber();
                    break;

                case "6":
                    sorter.PrintUserAddedNumbers();
                    break;

                case "7":
                    sorter.RemoveUserAddedNumbers();
                    break;

                case "R":
                    sorter.RestoreToOriginalSet();
                    break;

                case "B":
                    Console.Clear();
                    loop = false;
                    Functionalities();
                    break;

                case "X":
                    Console.Clear();
                    loop = false;
                    break;

                default:
                    Console.WriteLine("\nPlease enter a valid option!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
            }
        }
    }

    private void PropertiesFunctionalities()
    {
        bool loop = true;
        while (loop)
        {
            Console.Clear();
            Console.WriteLine(">> DSA\\ FileSelector\\ Modify/Properties Selection\\ Properties\n");
            Program.title();
            Console.WriteLine
            ("Data Set's Properties\n" +
            printHLine("Data Set's Properties")
            );

            sorter.NumberCount();
            string Unique = $"Unique {((sorter.CountNonDuplicates() <= 1) ? "Number" : "Numbers")} In The Data Set";
            string TotalUnique = $"Total Unique {(((sorter.CountNonDuplicates() + sorter.CountDuplicates()) <= 1) ? "Number" : "Numbers")} In The Data Set";
            string Odd = $"Total Odd {((sorter.CountOddNumbers() <= 1) ? "Number" : "Numbers")}";
            string Even = $"Total Even {((sorter.CountEvenNumbers() <= 1) ? "Number" : "Numbers")}";
            string Prime = $"Total Prime {((sorter.CountPrimeNumbers() <= 1) ? "Number" : "Numbers")}";
            Console.WriteLine
            (
                "-------------------------------------------------------\n" +
                $"> {"Samllest Number In the Data Set",-40}: {sorter.SmallestNumber()}\n" +
                $"> {"Largest Number In the Data Set",-40}: {sorter.LargestNumber()}\n" +
                $"> {Unique,-40}: {sorter.CountNonDuplicates()}\n" +
                $"> {TotalUnique,-40}: {sorter.CountNonDuplicates() + sorter.CountDuplicates()}\n" +
                $"> {"Total Sum of All Numbers",-40}: {sorter.Sum()}\n" +
                $"> {"Average of All Numbers",-40}: {sorter.Average():F4}\n" +
                $"> {Odd,-40}: {sorter.CountOddNumbers()}\n" +
                $"> {Even,-40}: {sorter.CountEvenNumbers()}\n" +
                $"> {Prime,-40}: {sorter.CountPrimeNumbers()}\n" +
                "-------------------------------------------------------\n\n"

            );
            Console.WriteLine
            (
                "Press M: For More Details \n" +
                "Press B: To Go Back To Modify/Properties Selection \n" +
                "Enter X: To Exit"
            );
            Console.Write("> ");
            string input = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(input, out int x)) { input = input.ToUpper(); }

            switch (input)
            {
                case "M":
                    Console.Clear();
                    loop = false;
                    PropertiesFunctionalities_MoreDetails();
                    break;

                case "B":
                    Console.Clear();
                    loop = false;
                    Functionalities();
                    break;

                case "X":
                    Console.Clear();
                    loop = false;
                    break;

                default:
                    Console.WriteLine("\nPlease enter a valid option!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
            }
        }

    }
    
    private void PropertiesFunctionalities_MoreDetails()
    {
        bool loop = true;
        while (loop)
        {
            Console.Clear();
            Console.WriteLine(">> DSA\\ FileSelector\\ Modify/Properties Selection\\ Properties\\ More Details\n");
            Program.title();
            Console.WriteLine
            ("More Details\n" +
            printHLine("More Details")
            );
            Console.WriteLine
            (
                $"Press 1: To Print The Odd {((sorter.CountOddNumbers() <= 1) ? "Number" : "Numbers")} From The Data Set\n" +
                $"Press 2: To Print The Even {((sorter.CountEvenNumbers() <= 1) ? "Number" : "Numbers")} From The Data Set\n" +
                $"Press 3: To Print The Prime {((sorter.CountPrimeNumbers() <= 1) ? "Number" : "Numbers")} From The Data Set\n" +
                "\n" +
                $"Press 4: To Print The Non Duplicate {((sorter.CountNonDuplicates() <= 1) ? "Number" : "Numbers")} From The Data Set\n" +
                $"Press 5: To Print The Duplicate {((sorter.CountDuplicates() <= 1) ? "Number" : "Numbers")} From The Data Set\n" +
                "\n" +
                "Press B: To Go Back To Data Set Properties\n" +
                "Enter X: To Exit"
            );
            Console.Write("> ");

            string input = Console.ReadLine() ?? string.Empty;
            if (!int.TryParse(input, out int x)) { input = input.ToUpper(); }

            switch (input)
            {
                case "1":
                    sorter.ShowOddNumbers();
                    break;

                case "2":
                    sorter.ShowEvenNumbers();
                    break;

                case "3":
                    sorter.ShowPrimeNumbers();
                    break;

                case "4":
                    sorter.ShowNonDuplicates();
                    break;

                case "5":
                    sorter.ShowDuplicates();
                    break;

                case "B":
                    Console.Clear();
                    loop = false;
                    PropertiesFunctionalities();
                    break;

                case "X":
                    Console.Clear();
                    loop = false;
                    break;

                default:
                    Console.WriteLine("\nPlease enter a valid option!");
                    Thread.Sleep(1500);
                    Console.Clear();
                    break;
            }
        }
    }

    public static string printHLine(string text)
    // makes a horizontal line of given strings size when called
    // make it so that if just number is given as text it will a Line of that size 
    {
        string line = "";
        int size = text.Length;
        for (int i = 0; i < size; i++)
        {
            line += "-";
        }
        line += "\n";
        return line;
    }
}

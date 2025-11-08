// add return to original list, sum, avg, find odd, find even, show number count at all time mathods and call them in UT[DONE]
// make a mathod to show the duplicate number and how many times they are present in the set[DONE]
// make a mathod to add number form the terminal, input can be given in diffrent formats [DONE]

namespace Data_Set_Analyzer;

using System;
using System.Collections.Generic;
using System.Threading; // for printing text for a short duration

public class NumberSorter
{
    private List<int> numbers;
    public List<int> copy;
    public List<int> userAddedNumber;
    public List<int> bufferList;
    public List<int> dupNum;

    public NumberSorter() //this. is not necessary other than a few situations
    {
        this.numbers = new List<int>();
        this.copy = new List<int>();
        this.userAddedNumber = new List<int>();
        this.bufferList = new List<int>();
        this.dupNum = new List<int>();
    }
    public int size()
    {
        return this.copy.Count;
    }
    public List<int> ConvertToList()
    {
        List<int> numberList = new List<int>(this.copy);
        return numberList;
    }
    public void NumberCount()
    {
        Console.WriteLine($"[Current Total {(this.copy.Count <= 1 ? "Number" : "Numbers")} Set: {this.copy.Count}]\n");
    }

    public void AddTONumberSorter(int number)
    {
        this.numbers.Add(number);
        this.copy = new List<int>(this.numbers);
    }

    public void PrintSet(List<int> setToPint)
    {
        setToPint.ForEach(Console.WriteLine);
    }

    public int LargestNumber()
    {
        return this.copy.Max();
    }

    public int SmallestNumber()
    {
        return this.copy.Min();
    }

    public int Sum() //new
    {
        int sum = 0;
        foreach (int num in this.copy)
        {
            sum += num;
        }
        return sum;
    }

    public double Average()//new
    {
        int sum = 0;
        foreach (int num in this.copy)
        {
            sum += num;
        }
        double avg = (double)sum / this.copy.Count;
        return avg;
    }

    public int CountOddNumbers()
    {
        int oddNumbers = 0;
        foreach (int num in this.copy)
        {
            if (num % 2 == 1)
            {
                oddNumbers++;
            }
        }
        return oddNumbers;
    }

    public void ShowOddNumbers()
    {
        Console.Clear();
        Console.WriteLine(">> DSA\\ FileSelector\\ Modify/Properties Selection\\ Properties\\ More Details\\ Print Odd\n");
        Console.WriteLine
        (
            "Odd Number Set\n" +
            "--------------"
        );
        this.bufferList = new List<int>();
        for (int i = 0; i < this.copy.Count; i++)
        {
            if (this.copy[i] % 2 == 1)
            {
                this.bufferList.Add(this.copy[i]);
            }
        }
        this.bufferList.Sort();
        PrintSet(this.bufferList);
        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }

    public int CountEvenNumbers()
    {
        int evenNumbers = 0;
        foreach (int num in this.copy)
        {
            if (num % 2 == 0)
            {
                evenNumbers++;
            }
        }
        return evenNumbers;
    }

    public void ShowEvenNumbers()
    {
        Console.Clear();
        Console.WriteLine(">> DSA\\ FileSelector\\ Modify/Properties Selection\\ Properties\\ More Details\\ Print Even\n");
        Console.WriteLine
        (
            "Even Number Set\n" +
            "---------------"
        );
        this.bufferList = new List<int>();
        for (int i = 0; i < this.copy.Count; i++)
        {
            if (this.copy[i] % 2 == 0)
            {
                this.bufferList.Add(this.copy[i]);
            }
        }
        this.bufferList.Sort();
        PrintSet(this.bufferList);
        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }

    public int CountPrimeNumbers()
    //https://en.wikipedia.org/wiki/Prime_number#Trial_division
    // this mathod has something wrong with it, this alone uses more then 14gigs of ram!!!
    {
        //List<int> bList = [.. this.copy]; // same as List<int> primes = new List<int>(this.copy); but works on .Net8 or newer
        //List<int> primes = [];
        /* 1st try!
        foreach (int num in bList)
        {
            while (true)
            {
                if (num <= 1) { break; }
                if (num == 2) { primes.Add(num); break; }
                if (num % 2 == 0) { break; }
                bool isPrime = true;
                for (int i = 3; i * i <= num; i += 2)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime) { primes.Add(num); }
            }
        }
        return primes.Count;
        */

        int primes = 0;
        foreach (int num in this.copy) //problem was the While Loop
        {
            if (num <= 1) { continue; }
            if (num == 2) { primes++; continue; }
            if (num % 2 == 0) { continue; }

            bool isPrime = true;
            for (int i = 3; i * i <= num; i += 2)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime) { primes++; }
        }
        return primes;
    }

    public void ShowPrimeNumbers()
    {
        Console.Clear();
        Console.WriteLine(">> DSA\\ FileSelector\\ Modify/Properties Selection\\ Properties\\ More Details\\ Print Prime\n");
        Console.WriteLine
        (
            "Prime Number Set\n" +
            "----------------"
        );
        List<int> primes = [];

        foreach (int num in this.copy)
        {
            if (num <= 1) { continue; }
            if (num == 2) { primes.Add(num); continue; }
            if (num % 2 == 0) { continue; }
            bool isPrime = true;
            for (int i = 3; i * i <= num; i += 2)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime) { primes.Add(num); }
        }
        primes.Sort();
        PrintSet(primes);
        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }

    public int CountNonDuplicates() // inprove the loop [DONE?]
    {
        this.bufferList = new List<int>();
        List<int> bufferList2 = new List<int>(this.copy);
        foreach (int num in this.copy)
        {
            bufferList2.Remove(num);
            if (!this.bufferList.Contains(num) && !bufferList2.Contains(num))
            {
                this.bufferList.Add(num);
            }
            bufferList2.Add(num);
        }
        return this.bufferList.Count;
    }

    public void ShowNonDuplicates() // inprove the loop [DONE?]
    {
        Console.Clear();
        Console.WriteLine(">> DSA\\ FileSelector\\ Modify/Properties Selection\\ Properties\\ More Details\\ Show Non-Duplicate\n");
        Console.WriteLine
        (
            "Non Duplicate's Number Set\n" +
            "-------------------------"
        );
        this.bufferList = new List<int>();
        List<int> bufferList2 = new List<int>(this.copy);
        foreach (int num in this.copy)
        {
            bufferList2.Remove(num);
            if (!this.bufferList.Contains(num) && !bufferList2.Contains(num))
            {
                this.bufferList.Add(num);
            }
            bufferList2.Add(num);
        }
        this.bufferList.Sort();
        PrintSet(this.bufferList);
        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }

    public int CountDuplicates()
    {
        // finds non dup numbers
        this.bufferList = new List<int>();
        List<int> bufferList2 = new List<int>(this.copy);
        foreach (int num in this.copy)
        {
            bufferList2.Remove(num);
            if (!this.bufferList.Contains(num) && !bufferList2.Contains(num))
            {
                this.bufferList.Add(num);
            }
            bufferList2.Add(num);
        }
        // removes all non dup numbers and sorts it
        this.dupNum = new List<int>(this.copy);
        foreach (int num in this.bufferList)
        {
            this.dupNum.Remove(num);
        }
        this.dupNum.Sort();

        // makes a list of individual dup numbers
        this.bufferList = new List<int>();
        foreach (int num in this.dupNum)
        {
            if (!this.bufferList.Contains(num))
            {
                this.bufferList.Add(num);
            }
        }
        return this.bufferList.Count;
    }

    public void ShowDuplicates()// make a mathod to show the duplicate number and how many times they are present in the set
    {
        Console.Clear();
        Console.WriteLine(">> DSA\\ FileSelector\\ Modify/Properties Selection\\ Properties\\ More Details\\ Show Duplicate\n");
        Console.WriteLine
        (
            "Duplicate's Number Set\n" +
            "---------------------"
        );

        // finds non dup numbers
        this.bufferList = new List<int>();
        List<int> bufferList2 = new List<int>(this.copy);
        foreach (int num in this.copy)
        {
            bufferList2.Remove(num);
            if (!this.bufferList.Contains(num) && !bufferList2.Contains(num))
            {
                this.bufferList.Add(num);
            }
            bufferList2.Add(num);
        }
        // removes all non dup numbers and sorts it
        this.dupNum = new List<int>(this.copy);
        foreach (int num in this.bufferList)
        {
            this.dupNum.Remove(num);
        }
        this.dupNum.Sort();

        // makes a list of individual dup numbers
        this.bufferList = new List<int>();
        foreach (int num in this.dupNum)
        {
            if (!this.bufferList.Contains(num))
            {
                this.bufferList.Add(num);
            }
        }
        //makes a list of how many times the dup number is present
        List<string> outputDupNum = new List<string>();
        foreach (int num1 in this.bufferList)
        {
            int count = 0;
            foreach (int num2 in this.dupNum)
            {
                if (num2 > num1)
                { break; } // as the list is sorted, we don't have to chack the whole list
                if (num2 == num1)
                {
                    count++;
                }
            }
            string output = $"{count} {(count <= 1 ? "time" : "times")}, {num1}";
            outputDupNum.Add(output);
        }

        // prints the list
        Console.WriteLine
        (
            "X time, The value\n" +
            "-----------------\n"
        );
        outputDupNum.ForEach(Console.WriteLine);
        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }

    public void SortSet()
    {
        this.copy.Sort(); //does the same
        Console.WriteLine("\nData Set Is Now Sorted!");
        Thread.Sleep(1500); // in milliseconds

        // I can explain this loop (if you are interested). But this is just downright ridiculous compared to .sort()
        /*
        while (true)
        {
            int x = 0;
            int i = 0;

            while ((i + 1) <= (this.copy.Count - 1))
            {
                if (this.copy[i] > this.copy[i + 1])
                {
                    int buffer = this.copy[i];
                    this.copy[i] = this.copy[i + 1];
                    this.copy[i + 1] = buffer;
                    x = 1;
                }
                i++;
            }
            if (x == 0)
            {
                break;
            }
        }
        */
    }

    public void RemoveDuplicates()//should not remove any user added numbers, ask user [DONE]
                                  // Should show how many numbers were removed [DONE]
    {
        if (this.userAddedNumber.Count > 0)
        {
            int totalNumbers = this.copy.Count;
            Console.WriteLine
            (
                "Including The User Added Numbers?"
            );
            bool loop1 = true;
            while (loop1)
            {
                Console.Write
                (
                "Y/N -> "
                );
                string input = Console.ReadLine() ?? string.Empty;
                if (!int.TryParse(input, out int _)) { input = input.ToUpper(); }
                // _ tells it not to store the value. If we put for example x. It will store the value in x. 
                // But this case we do not have any use for the value. we just want to know is it a integer or not? 
                switch (input)
                {
                    case "Y":
                        loop1 = false;
                        break;
                    case "N":
                        loop1 = false;
                        break;
                    default:
                        break;
                }

                if (input == "Y")
                {
                    //removes user added numbers
                    foreach (int number in this.userAddedNumber)
                    {
                        if (this.copy.Contains(number))
                        {
                            this.copy.Remove(number);
                        }
                    }
                    //removes duplicates
                    this.bufferList = new List<int>();
                    List<int> bufferList2 = new List<int>(this.copy);
                    foreach (int number in this.copy)
                    {
                        bufferList2.Remove(number);
                        if (!this.bufferList.Contains(number) && !bufferList2.Contains(number))
                        {
                            this.bufferList.Add(number);
                        }
                        bufferList2.Add(number);
                    }
                    this.copy = this.bufferList;

                    // adds back the user added numbers if they are not dup, if they are dup removes it from the list of userAddedNumber.
                    this.bufferList = new List<int>(this.userAddedNumber);
                    foreach (int number in this.userAddedNumber)
                    {
                        if (!this.copy.Contains(number))
                        {
                            this.copy.Add(number);
                        }
                        else
                        {
                            this.bufferList.Remove(number);
                        }
                    }
                    this.userAddedNumber = this.bufferList;
                    totalNumbers -= this.copy.Count;
                    Console.WriteLine($"[Total {totalNumbers} {(totalNumbers <= 1 ? "Number" : "Numbers")} Removed]");
                    Console.Write("\nAll Duplicate Numbers Are Removed!");
                    Thread.Sleep(3000);
                }
                else
                {
                    //removes user added numbers
                    foreach (int number in this.userAddedNumber)
                    {
                        if (this.copy.Contains(number))
                        {
                            this.copy.Remove(number);
                        }
                    }
                    //removes duplicates
                    this.bufferList = new List<int>();
                    List<int> bufferList2 = new List<int>(this.copy);
                    foreach (int number in this.copy)
                    {
                        bufferList2.Remove(number);
                        if (!this.bufferList.Contains(number) && !bufferList2.Contains(number))
                        {
                            this.bufferList.Add(number);
                        }
                        bufferList2.Add(number);
                    }
                    this.copy = this.bufferList;
                    // adds back the user added numbers
                    foreach (int number in this.userAddedNumber)
                    {
                        this.copy.Add(number);
                    }
                    totalNumbers -= this.copy.Count;
                    Console.WriteLine($"[Total {totalNumbers} {(totalNumbers <= 1 ? "Number" : "Numbers")} Removed]");
                    Console.Write("\nAll Duplicate Numbers Are Removed!  |  All Privious User Added Numbers Are Still In The Data Set!");
                    Thread.Sleep(3000);
                }
            }
        }
        else
        {
            //removes duplicates
            int totalNumbers = this.copy.Count;
            this.bufferList = new List<int>();
            List<int> bufferList2 = new List<int>(this.copy);
            foreach (int number in this.copy)
            {
                bufferList2.Remove(number);
                if (!this.bufferList.Contains(number) && !bufferList2.Contains(number))
                {
                    this.bufferList.Add(number);
                }
                bufferList2.Add(number);
            }
            this.copy = this.bufferList;
            totalNumbers -= this.copy.Count;
            Console.WriteLine($"[Total {totalNumbers} {(totalNumbers <= 1 ? "Number" : "Numbers")} Removed]");
            Console.Write("\nAll Duplicate Numbers Are Removed!");
            Thread.Sleep(2000);
        }
    }

    public void SelectAllUniqueNumbers()
    {
        int totalNumbers = this.copy.Count;
        this.bufferList = new List<int>();
        List<int> bufferList2 = new List<int>(this.copy);
        foreach (int number in this.copy)
        {
            bufferList2.Remove(number);
            if (!this.bufferList.Contains(number) && !bufferList2.Contains(number))
            {
                this.bufferList.Add(number);
            }
        }
        this.copy = this.bufferList;
        totalNumbers -= this.copy.Count;
        Console.WriteLine($"[Total {totalNumbers} {(totalNumbers <= 1 ? "Number" : "Numbers")} Removed]");
        Console.Write("\nAll Unique Numbers Selected!");
        Thread.Sleep(2000);
    }

    public void PrintModifiedSet() //new
    {
        Console.Clear();
        Console.WriteLine(">> DSA\\FileSelector\\Modify/Properties Selection\\Modifying Functionalities\\Data Set\n");
        Console.WriteLine
        (
            "Numbers\n" +
            "-------"
        );
        this.copy.ForEach(Console.WriteLine);
        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }

    public void AddNumber()// make a mathod to add number form the terminal, input can be given in diffrent formats, [DONE]
                           // should ask the user after they press to add the numbers if they wanted to add more numbers or not? [DONE]
                           // save all the numbers in a new list first then add them to the main list so that they can also be shown separately [DONE]
                           // add show user added numbers [DONE]
                           // and remove all user added numbers form the set, [DONE]

    // resoring to og should ask the user if they want to keep the added numbers or not, if not 
    // it should also reset the list of added numbers but after notifying the user [DONE]
    {
        this.bufferList = new List<int>();
        Console.Clear();
        Console.WriteLine(">> DSA\\FileSelector\\Modify/Properties Selection\\Modifying Functionalities\\Add Numbers\n");
        string line = UserTerminal.printHLine("Enter Numbers Separated by Space or Comma");
        Console.WriteLine("Enter Numbers Separated by Space or Comma\n" + line);
        bool loop = true;
        while (loop)
        {
            Console.Write("> ");
            string inputNum = Console.ReadLine() ?? string.Empty;
            if (inputNum.Contains(","))
            {
                string[] inputs = inputNum.Split(",");
                foreach (string input in inputs)
                {
                    string[] buffer = input.Split(" ");
                    foreach (var item in buffer)
                    {
                        if (int.TryParse(item, out int num))
                        {
                            this.userAddedNumber.Add(num);
                        }
                    }
                }
            }
            else
            {
                string[] buffer = inputNum.Split(" ");
                foreach (var item in buffer)
                {
                    if (int.TryParse(item, out int num))
                    {
                        this.userAddedNumber.Add(num);
                    }
                }
            }

            bool loop2 = true;
            while (loop2)
            {
                Console.Write
                (
                "Add More Numbers?\n" +
                "Y/N -> "
                );
                string addMore = Console.ReadLine() ?? string.Empty;
                if (!int.TryParse(addMore, out int x)) { addMore = addMore.ToUpper(); }
                switch (addMore)
                {
                    case "Y":
                        loop2 = false;
                        break;
                    case "N":
                        loop = false;
                        loop2 = false;
                        break;
                    default:
                        break;

                }
            }
        }
        foreach (int num in this.userAddedNumber)
        {
            this.copy.Add(num);
        }
    }

    public void PrintUserAddedNumbers()
    {
        Console.Clear();
        Console.WriteLine(">> DSA\\FileSelector\\Modify/Properties Selection\\Modifying Functionalities\\User Added Numbers\n");
        Console.WriteLine
        (
            "User Added Numbers In The Data Set\n" +
            "----------------------------------"
        );
        this.userAddedNumber.ForEach(Console.WriteLine);
        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }

    public void RemoveUserAddedNumbers()
    {
        foreach (int num in this.userAddedNumber)
        {
            this.copy.Remove(num);
        }
        this.userAddedNumber = new List<int>();
        Console.WriteLine("\nAll User Added Numbers Are Removed!");
        Thread.Sleep(3000);
    }

    public void RestoreToOriginalSet()
    {
        if (this.userAddedNumber.Count > 0)
        {
            Console.WriteLine("Remove All The User Added Numbers Aswell?");
            bool loop1 = true;
            while (loop1)
            {
                Console.Write
                (
                "Y/N -> "
                );
                string input = Console.ReadLine() ?? string.Empty;
                if (!int.TryParse(input, out int x)) { input = input.ToUpper(); }
                switch (input)
                {
                    case "Y":
                        loop1 = false;
                        break;
                    case "N":
                        loop1 = false;
                        break;
                    default:
                        break;
                }

                if (input == "Y")
                {
                    this.copy = new List<int>(this.numbers);
                    this.userAddedNumber = new List<int>();
                    Console.WriteLine("Original Data Set Restored!  |  User Added Numbers Removed!\n");
                    Thread.Sleep(3000);
                }
                else
                {
                    this.copy = [.. this.numbers, .. this.userAddedNumber];
                    // new syntax, same as
                    //this.copy = new List<int>(this.numbers);
                    //foreach(int num in this.userAddedNumber)
                    //{
                    //    this.copy.Add(num);
                    //}
                    Console.WriteLine("Original Data Set Restored!  |  All Privious User Added Numbers Are Still In The Data Set!\n");
                    Thread.Sleep(3000);
                }
            }
        }
        else
        {
            this.copy = [.. this.numbers];
            Console.Write("Original Data Set Restored!");
            Thread.Sleep(1500);
        }
    }
}
namespace Data_Set_Analyzer;

using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        UserTerminal terminal = new UserTerminal();
        terminal.MakeTerminal();

    }
    
    public static void title()
    {
        Console.WriteLine
        (
            UserTerminal.printHLine("!Data Set Analyzer!") +
                                    "!Data Set Analyzer!\n" +
            UserTerminal.printHLine("!Data Set Analyzer!") +
            "\n"
        );
    }
}

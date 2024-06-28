using System;
using CommandPrompt_CSharp;
using CommandPrompt_CSharp;

namespace CommandPrompt_CSharp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter commands. Type 'showCommands' to see a list of available commands.");

        while (true)
        {
            Console.Write(">");
            string command = Console.ReadLine();
            try
            {
                CommandManager.OperateCommand(command);
            }
            catch (Exception ex) 
            {
                Logger.WriteLine(ex.Message, ConsoleColor.Red);
            }
        }
    }
}

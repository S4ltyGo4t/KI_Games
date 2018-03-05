using System;

namespace FSM
{
    class Program
    {
        static void Main(string[] args)
        {
            Process p = new Process();
            //User Input
            string s = "";
            while (true)
            {
                Console.WriteLine("Type {W,A,S,D,} to toggle the characters movement and {Exit} to Exit.\n");
                //Fancy state is desplayed in green
                Console.Write("Current State: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(p.CurrentState +"\n");
                Console.ForegroundColor = ConsoleColor.White;
                s = Console.ReadLine();
                Console.Clear();
                switch (s)
                {
                    case "W":
                    case "w":
                        p.MoveNext(Command.W);
                        break;
                    case "A":
                    case "a":
                        p.MoveNext(Command.A);
                        break;
                    case "S":
                    case "s":
                        p.MoveNext(Command.S);
                        break;
                    case "D":
                    case "d":
                        p.MoveNext(Command.D);
                        break;
                    case "EXIT":
                    case "exit":
                        p.MoveNext(Command.Exit);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
    }
}
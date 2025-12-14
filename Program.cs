using System;
using System.Collections.Generic;
using System.Media;
using System.IO;

class Program
{ 
    static List<string> jorts = new List<string>();
    static string file =  "jorts.txt";

    static void Main()
    {
	Console.Title = "jort to-do-list";
	Console.ForegroundColor = ConsoleColor.Cyan;
	Console.BackgroundColor = ConsoleColor.DarkBlue;
	Console.Clear();

	PrintJortBanner();

	if (File.Exists(file))
	    jorts.AddRange(File.ReadAllLines(file));

	while (true)
	{
	    Console.Clear();
	    PrintJortBanner();
	    Console.WriteLine("ayaaa ljort:\n");

	    for (int i = 0; i <jorts.Count; i++)
	    {
		 Console.WriteLine($" [{(i+1)}] {jorts[i]}");
	    }

	    Console.WriteLine("\n" + new string('=', 50));
	    WriteColor(" [A]dd jort  [D]elete jort [Q]uit ", ConsoleColor.Yellow);
	    Console.WriteLine("\n" + new string('=', 50));

	    var key = Console.ReadKey(true).Key;

	    if (key == ConsoleKey.A) Addjort();
	    if (key == ConsoleKey.D) Deletejort();
	    if (key == ConsoleKey.Q) break;
        }
    
        File.WriteAllLines(file, jorts);
        Console.WriteLine("\nJorts saved. pdiddy ahh.");
        Thread.Sleep(1500);
    }

    static void Addjort()
    {
	Console.Clear();
	PrintJortBanner();
	WriteColor("wha u adding ",ConsoleColor.Magenta);
	string jort = Console.ReadLine()!;
	if (!string.IsNullOrWhiteSpace(jort))
	{
	    jorts.Add(jort);
	    WriteColor("ayaa jort added\nPress any key", ConsoleColor.Green);
	}
	Console.ReadKey();
    }

    static void Deletejort()
    {
	if (jorts.Count == 0)
	{
	    WriteColor("ayaa no jort found to delete.\n", ConsoleColor.Red);
	    Console.ReadKey();
	    return;
	}

	Console.Clear();
	PrintJortBanner();
	WriteColor("ayaaa wha jort you completing (number): ", ConsoleColor.Yellow);
	if (int.TryParse(Console.ReadLine(), out int num) && num > 0 && num <= jorts.Count)
	{
	    Console.WriteLine($" ayaa jort completed: {jorts[num-1]}");
	    jorts.RemoveAt(num-1);
	    WriteColor("ayaa jort deleted \nPress any key", ConsoleColor.Green);
	}
	else
	{
	    WriteColor("wrong number vro.\n", ConsoleColor.Red);
	}
	Console.ReadKey();
    }

    static void PrintJortBanner()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.BackgroundColor = ConsoleColor.DarkBlue;

        string banner = @"
        ╔═══════════════════════════════════════╗
        ║           J O R T   L I S T           ║
        ║           jorts jerk twice            ║
        ║            made by ghlue              ║
        ╚═══════════════════════════════════════╝
        ";

        Console.WriteLine(banner);
        Console.ResetColor();
   }

    static void WriteColor(string text, ConsoleColor color)
    {
	Console.ForegroundColor = color;
	Console.WriteLine(text);
	Console.ResetColor();
    }
}

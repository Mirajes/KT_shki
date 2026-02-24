using System;

namespace KT_shki
{
    static class Helper
    {
        static public void ActionReseter(ref string action)
        {
            Console.Write("\n\n >> ");
            action = Console.ReadLine();
        }

        static public void MakeAnIndentation(string name)
        {
            Console.WriteLine($"\n===============\n{name}\n===============\n");
        }

        static public void ClearConsole()
        {
            Console.Clear();
        }

        static public Random random = new Random();
    }
}



// perevod Enum v Array => Enum.GetValues(typeof(Countries)).Cast<Countries>()

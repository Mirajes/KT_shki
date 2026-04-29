using KT_shki.KTs;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_shki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CodeExecuter executer = new CodeExecuter();
            string action = "";

            while (true)
            {
                Helper.MakeAnIndentation("     KT's     ");
                Console.Write(
                    "\n" +
                    ">> Выберите КТ: \n" +
                    "  >> 1 \n" +
                    "  >> 2 \n" +
                    "  >> 3 \n" +
                    "  >> 0 - Выход \n");

                Helper.ActionReseter(ref action);

                switch (action)
                {
                    case "1":
                        Console.WriteLine("\n >> Переход к КТ1 \n");

                        KT1_PapersPlease KT1 = new KT1_PapersPlease();
                        executer.CodeExecution(KT1);
                        break;
                    case "2":
                        Console.WriteLine("\n >> Переход к КТ2 \n");

                        KT2_MarioKart KT2 = new KT2_MarioKart();
                        executer.CodeExecution(KT2);
                        break;
                    case "3":
                        KT3_GenericCrafter KT3 = new KT3_GenericCrafter();
                        executer.CodeExecution(KT3);
                        break;
                    case "0":
                        Console.WriteLine("\n >> ливаем \n");
                        return;
                    default:
                        Console.WriteLine("\n >> инвалид \n");
                        break;
                }
            }
        }
    }
}



// perevod Enum v Array => Enum.GetValues(typeof(Countries)).Cast<Countries>()

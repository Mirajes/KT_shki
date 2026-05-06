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
                    "  >> 7 \n" +
                    "  >> 0 - Выход \n");

                Helper.ActionReseter(ref action);

                switch (action)
                {
                    case "1":
                        Console.WriteLine("\n >> Переход к КТ1 \n");

                        KT1_PapersPlease KT1 = new KT1_PapersPlease();
                        KT1.Execute();
                        break;
                    case "2":
                        Console.WriteLine("\n >> Переход к КТ2 \n");

                        KT2_MarioKart KT2 = new KT2_MarioKart();
                        KT2.Execute();
                        break;
                    case "3":
                        KT3_GenericCrafter KT3 = new KT3_GenericCrafter();
                        KT3.Execute();
                        break;
                    case "7":
                        KT7_Async KT7 = new KT7_Async();
                        KT7.Execute();
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

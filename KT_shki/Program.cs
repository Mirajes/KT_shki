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
                Console.Write("\nInit: \n\n" +
                    ">> Выберите КТ: \n  " +
                    ">> 1 \n  " +
                    ">> 2 \n  " +
                    ">> 0 - Выход");
                Helper.ActionReseter(ref action);

                switch (action)
                {
                    case "1":
                        Console.WriteLine("\n >> Переход к КТ1 ");

                        KT1_PapersPlease KT1 = new KT1_PapersPlease();
                        executer.CodeExecution(KT1);
                        break;
                    case "2":
                        Console.WriteLine("\n >> Переход к КТ2 ");

                        KT2_MarioKart KT2 = new KT2_MarioKart();
                        executer.CodeExecution(KT2);
                        break;
                    case "0":
                        Console.WriteLine("\n >> ливаем ");
                        return;
                    default:
                        Console.WriteLine("\n >> инвалид ");
                        break;
                }
            }
        }
    }
}



// perevod Enum v Array => Enum.GetValues(typeof(Countries)).Cast<Countries>()

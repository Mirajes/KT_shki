using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_shki
{
    internal partial class KT3_GenericCrafter : KT
    {
        private List<Item> _inventory = new List<Item>();
        private Workbench _workbench = new Workbench();

        string _whereAmI = "на улице";

        public override void Execute()
        {
            string action = string.Empty;

            Helper.MakeAnIndentation("KT3: Обобщения");

            while (true)
            {
                #region Info
                Console.WriteLine("---\n");
                WhereAmI();
                Console.WriteLine("\n---");
                Console.WriteLine($"\n Количество предметов в инвентаре: {_inventory.Count}");
                #endregion

                Console.WriteLine("\n\nСовершите действие >>");
                Console.WriteLine("\n >> 1 - найти предмет" +
                    "\n >> 2 - открыть инвентарь" +
                    "\n >> 3 - зайти в Мастерскую" +
                    "\n >> 9 - lazy debug" +
                    "\n >> 0 - завершить debug");

                Helper.ActionReseter(ref action);

                Helper.ClearConsole();

                switch (action)
                {
                    case "1":

                        break;
                    case "2":
                        OpenInventory();
                        break;
                    case "3":
                        _whereAmI = "в Мастерской";
                        InWorkshop();
                        break;
                    case "9":

                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("chto ti sdelal");
                        break;
                }
            }
        }

        private void WhereAmI()
        {
            Console.WriteLine($"Вы {_whereAmI}");
        }

        private void OpenInventory()
        {
            Helper.ClearConsole();

            Console.WriteLine("Ваш инвентарь: ");
            WriteInventory();

            string action = string.Empty;
            Helper.ActionReseter(ref action);

            switch (action)
            {
                case "0":
                    return;
                default:
                    // invalid / try catch
                    break;
            }
        }

        private void CheckDescription(int itemIndex)
        {
            var item = _inventory[itemIndex];

            Console.WriteLine(item.GetDescription());
        }

        private void WriteInventory()
        {
            for (int i = 0; i < _inventory.Count; i++)
            {
                var item = _inventory[i];
                Console.WriteLine($"[{i}] Предмет: [{item.GetType().Name}]");
            }
        }

        private void InWorkshop()
        {
            while (true)
            {
                string action = string.Empty;

                WhereAmI();
                Console.WriteLine("");

                Helper.ActionReseter(ref action);
            }
        }
    }
}
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

        private List<Item> _itemPool = new List<Item>();
        private readonly Random random = new Random();

        public override void Execute()
        {
            _itemPool.Add(new Stick());
            _itemPool.Add(new Stone());

            /*
            * Init
            */

            string action = string.Empty;

            Helper.MakeAnIndentation("KT3: Обобщения");

            while (true)
            {
                #region Info

                WhereAmI();

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
                        ScoutItem();
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
            Console.WriteLine($"---\nВы {_whereAmI}\n---");
        }

        private void OpenInventory()
        {

            while (true)
            {
                Helper.ClearConsole();

                WriteInventory();

                Console.WriteLine("\nСовершите действие:" +
                    "\n > 0 - Закрыть инвентарь" +
                    "\n > [x] - Узнать информацию о предмете");

                string action = string.Empty;
                Helper.ActionReseter(ref action);

                switch (action)
                {
                    case "0":
                        Console.WriteLine("закрытие инвентаря...");
                        return;
                    default:
                        if (FindItemInInventory(action, out int index))
                        {
                            CheckDescription(index);
                        }
                        else
                        {
                            Console.WriteLine("нет такого...");
                        }
                        break;
                }
            }
        }

        private bool FindItemInInventory(string action, out int index)
        {
            if (int.TryParse(action, out index))
            {
                if (index >= 0 && index <= _inventory.Count)
                {
                    return true;
                }
            }

            return false;
        }

        private void CheckDescription(int itemIndex)
        {
            var item = _inventory[itemIndex];

            Console.WriteLine($"\n\n Предмет - {item.GetType().Name}" +
                $"{item.GetDescription()}");

            while (true)
            {
                string action = string.Empty;
                Helper.ActionReseter(ref action);

                switch (action)
                {
                    default:
                        return;
                }
            }
        }

        private void WriteInventory()
        {
            Console.WriteLine("Ваш инвентарь");
            if (_inventory.Count == 0)
                Console.WriteLine("пусто :O");

            for (int i = 0; i < _inventory.Count; i++)
            {
                var item = _inventory[i];
                Console.WriteLine($"[{i}] Предмет: [{item.GetType().Name}]");
            }
        }

        private void WriteCrafts()
        {
            Console.WriteLine("\n---\nРецепты\n---\n" +
                "\n[Spear] = Stone + Stick + Stick" +
                "\n[Axe] = Stone + Stone + Stick");
        }

        private void InWorkshop()
        {
            Workbench workbench = new Workbench();

            while (true)
            {
                string action = string.Empty;

                WhereAmI();

                Console.WriteLine("");

                Console.WriteLine(
                    "\n Действие:" +
                    "\n >> 1 - Создать оружие" +
                    "\n >> 2 - Установить элемент на оружие" +
                    "\n >> 9 - Открыть инвентарь" +
                    "\n >> 0 - Покинуть мастерскую");

                Helper.ActionReseter(ref action);

                switch (action)
                {
                    case "1":
                        Console.WriteLine();
                        WriteInventory();
                        WriteCrafts();

                        var selectedIndexies = SelectThreeUniqueItems();

                        if (selectedIndexies.Count != 3)
                        {
                            Console.WriteLine("Создание отменено");
                            break;
                        }

                        var item1 = _inventory[selectedIndexies[0]];
                        var item2 = _inventory[selectedIndexies[1]];
                        var item3 = _inventory[selectedIndexies[2]];

                        var weapon = _workbench.CreateWeapon(item1, item2, item3);
                        if (weapon != null)
                        {
                            RemoveItemsFromInventory(selectedIndexies);
                            _inventory.Add(weapon);
                            Console.WriteLine($"Вы создали - {weapon.GetType().Name}");
                        }
                        else
                        {
                            Console.WriteLine($"Такого крафта не нашлось {item1} + {item2} + {item3}");
                        }

                            break;
                    case "2":
                        var weaponIndixes = ShowWeaponOnly();
                        if (weaponIndixes.Count == 0)
                        {
                            Console.WriteLine("У вас оружия");
                            break;
                        }

                        Console.WriteLine("\nВыберите оружия для зачарования");
                        string weaponInput = Console.ReadLine();

                        if (!FindItemInInventory(weaponInput, out int index) 
                            && weaponIndixes.Contains(index))
                        {
                            Console.WriteLine("Неверный выбор");
                            break;
                        }

                        var selectedWeapon = _inventory[index] as Weapon;

                        Console.WriteLine("\nВыберите элемент для зачарования" +
                            "\n > 1 - Fire" +
                            "\n > 2 - Ice" +
                            "\n > 3 - Fire + Ice");

                        string elementChoice = string.Empty;
                        Helper.ActionReseter(ref elementChoice);

                        Element newElement;

                        switch (elementChoice)
                        {
                            case "1":
                                newElement = new Fire();
                                selectedWeapon.SetElement(newElement);
                                Console.WriteLine($"Применён {newElement}");
                                break;
                            case "2":
                                newElement = new Ice();
                                selectedWeapon.SetElement(newElement);
                                Console.WriteLine($"Применён {newElement}");
                                break;
                            case "3":
                                Element fire = new Fire();
                                Element ice = new Ice();
                                selectedWeapon.SetElement(fire + ice);
                                Console.WriteLine($"Применён {fire + ice}");
                                break;
                            default:
                                Console.WriteLine("ты что наделал");
                                break;
                        }

                        break;
                    case "9":
                        OpenInventory();
                        break;
                    case "0":
                        _whereAmI = "на Улице";
                        return;
                    default:
                        break;
                }
            }
        }

        private void ScoutItem()
        {
            Random random = new Random();
            double chance = random.NextDouble();

            if (chance >= 0.5d)
            {
                Item newItem = FindNewItem();
                _inventory.Add(newItem);
            }
            else
            {
                Console.WriteLine("Вы ничего не нашли! :(");
            }
        }

        private Item FindNewItem()
        {            
            int rndItemInPool = random.Next(_itemPool.Count);
            Item newItem = _itemPool[rndItemInPool];
            
            Console.WriteLine($"Вы нашли {newItem}");
            return newItem;
        }

        private List<int> SelectThreeUniqueItems()
        {
            var selectedIndices = new List<int>();

            while (selectedIndices.Count < 3)
            {
                Console.WriteLine("\n---");
                Console.WriteLine($"Выбрано предметов: {selectedIndices.Count}/3");
                Console.WriteLine("Введите индекс предмета (или 'cancel' - для отмены)");
                Console.WriteLine("---\n");

                string input = Console.ReadLine();

                if (input.ToLower() == "cancel")
                {
                    selectedIndices.Clear();
                    break;
                }

                if (!FindItemInInventory(input, out int index))
                {
                    Console.WriteLine($"Вы ввели неправильный символ - {input}");
                    continue;
                }

                if (selectedIndices.Contains(index))
                {
                    Console.WriteLine($"Данный индекс уже есть в списке выбора - {index}");
                    continue;
                }

                selectedIndices.Add(index);
                Console.WriteLine($"Предмет с индексом [{index}] был добавлен");
            }

            return selectedIndices;
        }

        private void RemoveItemsFromInventory(List<int> indixesToRemove)
        {
            indixesToRemove.Sort((a, b) => b.CompareTo(a));
            foreach (int index in indixesToRemove)
            {
                _inventory.RemoveAt(index);
            }
        }

        private List<int> ShowWeaponOnly()
        {
            var weaponIndixes = new List<int>();
            Console.WriteLine("\n --- Оружие в инвентаре ---");
            for (int i = 0; i < _inventory.Count; i++)
            {
                if (_inventory[i] is Weapon weapon)
                {
                    weaponIndixes.Add(i);
                    var elementName = weapon.GetElement()?.GetType().Name ?? "Нет Элемента";

                    Console.WriteLine($"[{i}] {weapon.GetType().Name} (Элемент: {elementName})");
                }
            }

            return weaponIndixes;
        }
    }
}
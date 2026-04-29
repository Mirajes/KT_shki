using System;
using System.Collections.Generic;

namespace KT_shki
{
    internal partial class KT1_PapersPlease : KT
    {
        public enum Countries
        {
            Arstotzka,
            Kolechia,
            Obristan
        }

        // test

        public override void Execute()
        {
            KT1_PapersPlease.BorderGuard guard = new KT1_PapersPlease.BorderGuard();
            string action = "";

            List<KT1_PapersPlease.Visa> visas = new List<KT1_PapersPlease.Visa>();
            int visasToCreate = 0;
            int visasBase = 5;

            Helper.MakeAnIndentation("КТ1: Инкапсуляция");

            while (true)
            {
                Console.Write($"\nКоличество Виз на создание {visasToCreate}");
                Console.Write($"\nВиз на столе: {visas.Count}");

                Console.WriteLine();

                Console.Write("\nВыберите действие:" +
                    " \n >> 1 - Применить базовые значения" +
                    " \n >> 2 - Инициализация Виз" +
                    " \n >> 3 - Ввести собственное кол-во Виз" +
                    " \n >> 4 - Вывести всю информацию" +
                    " \n >> 5 - Проверить Визы" +
                    " \n >> 6 - Вывести всю информацию и проверить" +
                    " \n ..." +
                    " \n >> 8 - Ленивая проверка" +
                    " \n >> 9 - Сбросить" +
                    " \n >> 0 - Выход");

                Helper.ActionReseter(ref action);

                switch (action)
                {
                    case "1":
                        visasToCreate = visasBase;
                        Console.WriteLine($"\n >> Применено: {visasToCreate}");
                        break;
                    case "2":
                        this.InitVisas(ref visas, visasToCreate);
                        break;
                    case "3":
                        Console.Write("\n >> Введите число");
                        string userAnswer = "";

                        Helper.ActionReseter(ref userAnswer);

                        if (int.TryParse(userAnswer, out int userVisasCount))
                        {
                            visasToCreate = userVisasCount;
                            Console.WriteLine($"\n >> Применено: {visasToCreate}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("invalid int");
                            break;
                        }
                    case "4":
                        Helper.MakeAnIndentation("Вывод Инфы Виз");
                        //Console.WriteLine("\n >> Вывод Инфы Виз");
                        this.ShowAllVisasInfo(visas);
                        break;
                    case "5":
                        Helper.MakeAnIndentation("Проверка Виз");
                        //Console.WriteLine("\n >> Проверка Виз");
                        this.CheckAllVisas(visas, guard);
                        break;
                    case "6":
                        Helper.MakeAnIndentation("Полный набор действий");
                        //Console.WriteLine("\n >> Полный набор действий");
                        this.ShowAndCheckAllVisas(visas, guard);
                        break;
                    case "8": // копирка для теста
                        Helper.MakeAnIndentation("лень");
                        visasToCreate = visasBase;
                        this.InitVisas(ref visas, visasToCreate);
                        this.ShowAndCheckAllVisas(visas, guard);
                        Console.WriteLine("\n >> Reseting...");
                        visasToCreate = 0;
                        visas.Clear();
                        break;
                    case "9":
                        Console.WriteLine("\n >> Reseting...");
                        visasToCreate = 0;
                        visas.Clear();
                        break;
                    case "0":
                        Console.WriteLine("\n >> Возращение");
                        return;
                    default:
                        Console.WriteLine("\n >> овощ");
                        break;
                }
            }
        }

        public void InitVisas(ref List<Visa> visas, int createCount)
        {
            if (createCount < 0) { Console.WriteLine(">> плохое число"); return; }

            visas.Clear();

            for (int i = 0; i < createCount; i++)
            {
                visas.Add(new Visa());
            }
        }

        public void ShowAllVisasInfo(List<Visa> visas)
        {
            if (visas.Count == 0) { Console.WriteLine(">> Пустой стол виз"); return; }

            foreach (var item in visas)
            {
                item.ShowInfo();
                Console.WriteLine();
            }
        }

        public void CheckAllVisas(List<Visa> visas, BorderGuard guard)
        {
            if (visas.Count == 0) { Console.WriteLine(">> Пустой стол виз"); return; }

            foreach (var item in visas)
            {
                Console.WriteLine(guard.CheckVisa(item));
                Console.WriteLine();
            }
        }

        public void ShowAndCheckAllVisas(List<Visa> visas, BorderGuard guard)
        {
            if (visas.Count == 0) { Console.WriteLine(">> Пустой стол виз"); return; }

            foreach (var item in visas)
            {
                item.ShowInfo();
                Console.Write($">> Вывод: {guard.CheckVisa(item)}\n\n");
            }
        }
    }
}
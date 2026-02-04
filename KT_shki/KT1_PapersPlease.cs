using System;
using System.Collections.Generic;

namespace KT_shki
{
    internal class KT1_PapersPlease
    {
        public class Visa
        {
            private Countries _country;
            private bool _isValid;
            private int _year;

            public Countries Country => _country;
            public bool IsValid => _isValid;
            public int Year => _year;

            public Visa() // v ideale v otdel'nui metod
                // раньше random находился в этой области
            {   
                int whichCountry = Helper.random.Next(0, Enum.GetValues(typeof(Countries)).Length );
                _country = (Countries)whichCountry;

                int isValid = Helper.random.Next(2);
                _isValid = isValid == 1 ? true : false;

                _year = Helper.random.Next(2000, 2051);
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Страна \n >> {Country}");
                Console.WriteLine($"Валидный \n >> {IsValid}");
                Console.WriteLine($"Год выпуска \n >> {Year}");
            }
        }

        public class BorderGuard
        {
            private int _todaysYear = 2026;

            public string CheckVisa(Visa visa)
            {
                if (visa == null) return "GDE VISA";

                if (visa.Country != Countries.Arstotzka && visa.Country != Countries.Obristan)
                    return "Враждебная страна";
                else if (!visa.IsValid)
                    return "ПОДДЕЛКА!";
                else if ((visa.Year <= _todaysYear - 5 || visa.Year > _todaysYear))
                    return "Некорректныый год выпуска";

                return "Въезд разрешён";
            }
        }
        public enum Countries
        {
            Arstotzka,
            Kolechia,
            Obristan
        }

        // test

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
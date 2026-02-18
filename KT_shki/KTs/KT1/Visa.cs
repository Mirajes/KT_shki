using System;

namespace KT_shki
{
    internal partial class KT1_PapersPlease
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
    }
}
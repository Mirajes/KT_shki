namespace KT_shki
{
    internal partial class KT1_PapersPlease
    {
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
    }
}
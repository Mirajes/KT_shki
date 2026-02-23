using System;

namespace KT_shki.KTs
{
    internal partial class KT2_MarioKart
    {
        private Driver _mario = new Driver("Mario", 0.5f);
        private Driver _peach = new Driver("Peach", 0.7f);
        private Driver _bouzer = new Driver("Bouzer", 1f);

        public void Execute()
        {
            Console.WriteLine("KT2");


        }

        public enum TransportType
        {
            Car,
            Plane,
            Boat
        }

        public interface IExtremeTransport
        {
            bool CanDoStunts(); // да / нет
            void PerformStunt(); // метод трюка
            float RiskFactor(); // промежуток от 0.0 - 1.0
        }
    }
}

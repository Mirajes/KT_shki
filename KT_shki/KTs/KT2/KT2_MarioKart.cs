using System;

namespace KT_shki.KTs
{
    internal partial class KT2_MarioKart
    {

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
            bool CanDoStunts();
            void PerformStunt();
            float RiskFactor();
        }
    }
}

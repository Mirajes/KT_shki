using System;

namespace KT_shki.KTs
{
    internal partial class KT2_MarioKart
    {
        public class Airplane : Transport, IExtremeTransport
        {
            public bool CanDoStunts()
            {
                throw new NotImplementedException();
            }

            public void PerformStunt()
            {
                if (!CanDoStunts()) return;
            }

            public float RiskFactor()
            {
                throw new NotImplementedException();
            }

            protected override void FuelConsumption()
            {
                throw new NotImplementedException();
            }

            protected override void StartMoving()
            {
                throw new NotImplementedException();
            }

            protected override void TransportType()
            {
                throw new NotImplementedException();
            }
        }
    }
}

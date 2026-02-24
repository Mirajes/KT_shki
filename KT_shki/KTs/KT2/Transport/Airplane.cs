using System;

namespace KT_shki.KTs
{
    internal partial class KT2_MarioKart
    {
        public class Airplane : Transport, IExtremeTransport
        {
            public Airplane(Driver pilot, string model, double baseSpeed, TransportType transportsType, string howStartsMoving) : base(pilot, model, baseSpeed, transportsType, howStartsMoving) { }

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

            public override void FuelConsumption()
            {
                throw new NotImplementedException();
            }

            public override void StartMoving()
            {
                throw new NotImplementedException();
            }

            public override void TransportType()
            {
                throw new NotImplementedException();
            }
        }
    }
}

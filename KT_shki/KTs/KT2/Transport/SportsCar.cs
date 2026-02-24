using System;

namespace KT_shki.KTs
{
    internal partial class KT2_MarioKart
    {
        public class SportsCar : Transport, IExtremeTransport
        {
            public SportsCar(Driver pilot, string model, double baseSpeed, TransportType transportsType, string howStartsMoving) : base(pilot, model, baseSpeed, transportsType, howStartsMoving) { }

            public bool CanDoStunts()
            {
                return true;
            }

            public void PerformStunt()
            {
                if (CanDoStunts())
                {

                }
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
                Console.WriteLine($"this is {TransportsType}");
            }

            public override void MaxSpeed(double driverSkill)
            {
                base.MaxSpeed(driverSkill * 1.5f);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KT_shki.KTs
{
    internal partial class KT2_MarioKart
    {
        public class Taxi : Transport
        {
            public Taxi(Driver pilot, string model, double baseSpeed, TransportType transportsType, string howStartsMoving) : base(pilot, model, baseSpeed, transportsType, howStartsMoving) { }

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

using System;

namespace KT_shki.KTs
{
    internal partial class KT2_MarioKart
    {
        public abstract class Transport
        {
            #region PublicFields
            public Driver Pilot => _Pilot;
            public string Model => _Model;
            public double BaseSpeed => _BaseSpeed;
            public double MaxSpeed => _MaxSpeed;
            public float FuelConsumption => _FuelConsumption;
            public float FuelCount => _FuelCount;
            public TransportType TransportType => _TransportType;
            public string HowStartsMoving => _HowStartsMoving;
            #endregion

            #region PrivateFields
            protected Driver _Pilot;
            protected string _Model;

            protected double _BaseSpeed;
            protected double _MaxSpeed;
            protected float _FuelConsumption;
            protected float _FuelCount;

            protected TransportType _TransportType;
            protected string _HowStartsMoving;
            #endregion
            
            public Transport(Driver pilot, string model, double baseSpeed, 
            float fuelConsumption, TransportType transportType, string howStartsMoving)
            {
                _Pilot = pilot;
                _Model = model;
                _BaseSpeed = baseSpeed;
                _FuelConsumption = fuelConsumption;
                _TransportType = transportType;
                _HowStartsMoving = howStartsMoving;
            }

            protected virtual void MaxSpeed(double driverSkill)
            {
                // по экспоненте можно
                _MaxSpeed = Math.Pow(3, driverSkill) * _BaseSpeed;
            }

            protected abstract void FuelConsumption();
            protected abstract void TransportType();
            protected abstract void StartMoving();
        }
    }
}

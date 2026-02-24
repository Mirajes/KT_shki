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
            public double MaxTransportSpeed => _MaxTransportSpeed;
            public float FuelCount => _FuelCount;
            public TransportType TransportsType => _TransportsType;
            public string HowStartsMoving => _HowStartsMoving;
            #endregion

            #region PrivateFields
            protected Driver _Pilot;
            protected string _Model;

            protected double _BaseSpeed;
            protected double _MaxTransportSpeed;
            protected float _FuelCount;

            protected TransportType _TransportsType;
            protected string _HowStartsMoving;
            #endregion
            
            public Transport(Driver pilot, string model, double baseSpeed, TransportType transportsType, string howStartsMoving)
            {
                _Pilot = pilot;
                _Model = model;
                _BaseSpeed = baseSpeed;
                _TransportsType = transportsType;
                _HowStartsMoving = howStartsMoving;
            }

            public virtual void MaxSpeed(double driverSkill)
            {
                // по экспоненте можно
                _MaxTransportSpeed = Math.Pow(3, driverSkill) * _BaseSpeed;
            }

            public abstract void FuelConsumption(); // л/100км? и он абстрактный? зачем?
            public abstract void TransportType(); // и чё это за метод
            public abstract void StartMoving();
        }
    }
}

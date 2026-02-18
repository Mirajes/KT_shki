namespace KT_shki.KTs
{
    internal partial class KT2_MarioKart
    {
        public abstract class Transport
        {
            protected Driver _Pilot;

            protected string _Model;

            protected double _MaxSpeed;
            protected float _FuelConsumption;
            protected TransportType _TransportType;
            protected string _howStartsMoving;

            public Transport(Driver pilot, string model, double maxSpeed, float fuelConsumption, TransportType transportType, string howStartsMoving)
            {
                _Pilot = pilot;
                _Model = model;
                _MaxSpeed = maxSpeed;
                _FuelConsumption = fuelConsumption;
                _TransportType = transportType;
                _howStartsMoving = howStartsMoving;
            }

            protected virtual void MaxSpeed(double driverSkill)
            {
                // по экспоненте можно
                _MaxSpeed = driverSkill;
            }

            protected abstract void FuelConsumption();
            protected abstract void TransportType();
            protected abstract void StartMoving();
        }
    }
}

using System;

namespace KT_shki.KTs
{
    internal partial class KT2_MarioKart
    {
        interface IExtremeTransport
        {
            bool CanDoStunts();
            void PerformStunt();
            float RiskFactor();
        }

        public abstract class Driver
        {
            public string Name => _Name;
            public float DriverSkill => _DriverSkill;

            protected string _Name;
            protected float _DriverSkill;

            public Driver(string name, float driverSkill)
            {
                _Name = name;
                _DriverSkill = driverSkill;
            }
        }

        public abstract class Transport
        {
            protected Driver _Pilot;

            protected string _Model;

            protected float _MaxSpeed;
            protected float _FuelConsumption;
            protected TransportType _TransportType;
            protected string _howStartsMoving;



            protected virtual void MaxSpeed(float driverSkill)
            {
                if (driverSkill > 1f || driverSkill < 0f) { Console.WriteLine($"\n invalid {driverSkill} для ?"); return; }

                // по экспоненте можно
                _MaxSpeed = driverSkill;
            }

            protected abstract void FuelConsumption();
            protected abstract void TransportType();
            protected abstract void StartMoving();
        }

        public enum TransportType
        {
            Car,
            Plane,
        }
    }
}

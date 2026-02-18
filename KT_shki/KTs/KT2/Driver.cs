namespace KT_shki.KTs
{
    public abstract class Driver
    {
        public string Name => _Name;
        public double DriverSkill => _DriverSkill;

        protected string _Name;
        protected double _DriverSkill;

        public Driver(string name, double driverSkill)
        {
            _Name = name;

            if (driverSkill > 1)
                _DriverSkill = 1;
            else if (driverSkill < 0)
                _DriverSkill = 0;
            else
                _DriverSkill = driverSkill;
        }
    }
}

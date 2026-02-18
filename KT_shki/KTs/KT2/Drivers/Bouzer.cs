namespace KT_shki.KTs
{
    public class Bouzer : Driver
    {
        public Bouzer(string name = "Bouzer", float driverSkill = 1f) : base(name, driverSkill)
        {
            _Name = name;
            _DriverSkill = driverSkill;
        }
    }
}

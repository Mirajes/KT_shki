namespace KT_shki.KTs
{
    public class Peach : Driver
    {
        public Peach(string name = "Peach", float driverSkill = 0.7f) : base(name, driverSkill)
        {
            _Name = name;
            _DriverSkill = driverSkill;
        }
    }
}

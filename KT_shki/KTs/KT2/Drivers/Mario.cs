namespace KT_shki.KTs
{
    public class Mario : Driver
    {
        public Mario(string name = "Mario", float driverSkill = 0.5f) : base(name, driverSkill)
        {
            _Name = name;
            _DriverSkill = driverSkill;
        }
    }
}

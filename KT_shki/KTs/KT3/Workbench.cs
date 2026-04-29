namespace KT_shki
{
    public class Workbench
    {
        public Weapon CreateWeapon<T1, T2, T3>(T1 a, T2 b, T3 c)
            where T1 : Item where T2 : Item where T3 : Item
        {
            Weapon weapon;

            if (a is Stone && b is Stick && c is Stick)
            {
                weapon = new Spear(
                    ReturnDamageAmount(a, b, c, 1.2f),
                    ReturnAttackSpeedAmount(a, b, c, 2));
                return weapon;
            }
            else if (a is Stone && b is Stick && c is Stick)
            {
                weapon = new Spear(
                    ReturnDamageAmount(a, b, c, 1.5f),
                    ReturnAttackSpeedAmount(a, b, c, 3));
                return weapon;
            }
            else
            {
                return null;
            }
        }

        private double ReturnDamageAmount<T1, T2, T3>(T1 a, T2 b, T3 c, double mult) 
            where T1 : Item 
            where T2 : Item
            where T3 : Item
        {
            return (a.Damage + b.Damage + c.Damage) * mult;
        }

        private double ReturnAttackSpeedAmount<T1, T2, T3>(T1 a, T2 b, T3 c, double divider)
            where T1 : Item
            where T2 : Item
            where T3 : Item
        {
            return (a.AttackSpeed + b.AttackSpeed + c.AttackSpeed) / divider;
        }
    }
}
namespace KT_shki
{
    public abstract class Item
    {
        protected double _Damage;
        protected double _AttackSpeed;

        public double DPS => _Damage * _AttackSpeed;
        public double Damage => _Damage;
        public double AttackSpeed => _AttackSpeed;

        protected Item(double damage, double attackSpeed)
        {
            _Damage = damage;
            _AttackSpeed = attackSpeed;
        }

        public virtual string GetDescription()
        {
            return $"\nDamage - {_Damage} \nAttack Speed - {_AttackSpeed} \n DPS - {DPS}";
        }
    }
}
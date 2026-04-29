namespace KT_shki
{
    public class Ice : Element
    {
        protected float _DamageRate;

        public Ice(float damage = 5f, float damageRate = .2f) : base(damage)
        {
            _DamageRate = damageRate;
        }
    }
}
namespace KT_shki
{
    public class Fire : Element
    {
        protected float _DamageRate;

        public Fire(float damage = 15f, float damageRate = .3f) : base(damage)
        {
            _DamageRate = damageRate;
        }
    }
}
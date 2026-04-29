namespace KT_shki
{
    public class Steam : Element
    {
        protected float _DamageRate;
        public Steam(float damage, float damageRate = .5f) : base(damage)
        {
            _DamageRate = damageRate;
        }
    }
}
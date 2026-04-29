namespace KT_shki
{
    public abstract class Element
    {
        protected float _Damage;
        protected float _DamageRate;

        public float Damage => _Damage;
        public float DamageRate => _DamageRate;

        public static Element operator +(Element element1, Element element2)
        {
            if ((element1 is Fire && element2 is Ice) 
                || (element1 is Ice && element2 is Fire))
            {

                return new Steam();
            }
            return null;
        }
    }
}
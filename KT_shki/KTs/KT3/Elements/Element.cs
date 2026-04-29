namespace KT_shki
{
    public abstract class Element
    {
        protected float _Damage;
        public float Damage => _Damage;

        public static Element operator +(Element element1, Element element2)
        {
            if ((element1 is Fire && element2 is Ice) 
                || (element1 is Ice && element2 is Fire))
            {
                float damage = (element1.Damage + element2.Damage) * 1.2f;
                return new Steam(damage);
            }
            return null;
        }

        public Element(float damage)
        {
            _Damage = damage;
        }
    }
}
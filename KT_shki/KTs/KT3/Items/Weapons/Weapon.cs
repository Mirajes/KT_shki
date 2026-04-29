namespace KT_shki
{
    public class Weapon : Item
    {
        protected Element _Element;

        public Weapon(double damage, double attackSpeed) : base(damage, attackSpeed) { }

        public override string GetDescription()
        {
            return $"Weapon! {this.GetType()} \n{base.GetDescription()}";
        }
        public void SetElement(Element element)
        {
            _Element = element;
        }
        public void SetElement(Element element1, Element element2)
        {
            _Element = element1 + element2;
        }
    }
}
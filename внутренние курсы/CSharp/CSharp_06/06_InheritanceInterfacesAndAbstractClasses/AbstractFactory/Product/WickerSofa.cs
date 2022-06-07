namespace AbstractFactory
{
    public class WickerSofa : IWickerFurniture
    {
        public string GetWickerFurnitureName()
        {
            return this.GetType().Name;
        }

        public override string ToString()
        {
            return GetWickerFurnitureName();
        }
    }
}
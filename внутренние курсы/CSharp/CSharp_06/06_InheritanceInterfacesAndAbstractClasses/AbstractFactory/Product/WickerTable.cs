namespace AbstractFactory
{
    public class WickerTable : IWickerFurniture
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
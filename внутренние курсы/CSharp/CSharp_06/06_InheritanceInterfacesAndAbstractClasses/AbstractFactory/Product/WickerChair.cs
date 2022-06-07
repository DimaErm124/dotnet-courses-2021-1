namespace AbstractFactory
{
    public class WickerChair : IWickerFurniture
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
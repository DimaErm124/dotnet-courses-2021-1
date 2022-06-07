namespace AbstractFactory
{
    public class OfficeChair : IOfficeFurniture
    {
        public string GetOfficeFurnitureName()
        {
            return this.GetType().Name;
        }

        public override string ToString()
        {
            return GetOfficeFurnitureName();
        }
    }
}
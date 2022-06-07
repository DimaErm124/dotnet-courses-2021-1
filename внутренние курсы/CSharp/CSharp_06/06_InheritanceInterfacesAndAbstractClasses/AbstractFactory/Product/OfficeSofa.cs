namespace AbstractFactory
{
    public class OfficeSofa : IOfficeFurniture
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
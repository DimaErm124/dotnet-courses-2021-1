using System;

namespace AbstractFactory
{
    public class OfficeTable : IOfficeFurniture
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
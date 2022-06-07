namespace AbstractFactory
{
    public interface IFurnitureFactory
    {
        IWickerFurniture CreateWickerFurniture();

        IOfficeFurniture CreateOfficeFurniture();

        IDinningRoomFurniture CreateDinningRoomFurniture();
    }
}
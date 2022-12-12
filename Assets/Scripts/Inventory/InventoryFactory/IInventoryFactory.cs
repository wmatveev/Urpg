namespace Inventory.InventoryFactory
{
    public interface IInventoryFactory
    {
        public IItem CreateItem(string idItem);
    }
}
using System.Collections.Generic;

namespace Inventory
{
    public class InventoryController : IInventoryController
    {
        public Dictionary<string, int> inventory { get; }

        public void AddObject()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteObject()
        {
            throw new System.NotImplementedException();
        }

        public void TakeObjectFromInventory()
        {
            throw new System.NotImplementedException();
        }

        public void ReturnObjectToInventory()
        {
            throw new System.NotImplementedException();
        }

        public void SplitObject()
        {
            throw new System.NotImplementedException();
        }

        public void FreeSpaceCheckForObject()
        {
            throw new System.NotImplementedException();
        }
    }
}
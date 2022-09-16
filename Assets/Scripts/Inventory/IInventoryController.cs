using System.Collections.Generic;

namespace Rpg.Inventory
{
    public interface IInventoryController
    {
        Dictionary<string, int> inventory { get; }

        void AddObject();                   // Добавить предмет в инвентарь
        void DeleteObject();                // Удалить / выбросить предмет из инвентаря
        void TakeObjectFromInventory();     // Взять предмет из инвентаря
        void ReturnObjectToInventory();     // Вернуть предмет обратно в инвентарь

        void SplitObject();                 // Разделить предмет

        void FreeSpaceCheckForObject();     // Проверка свободного места в инвентаре для объекта
    }
}
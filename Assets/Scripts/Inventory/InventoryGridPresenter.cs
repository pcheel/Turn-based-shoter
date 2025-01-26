using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InventoryGridPresenter
{
    private readonly List<InventorySlotPresenter> _slotPresenters = new List<InventorySlotPresenter>();
    public InventoryGridPresenter(IInventoryGrid inventoryGrid, InventoryGridView view, DiContainer container)
    {
        Vector2Int size = inventoryGrid.Size;
        IInventorySlot[,] slots = inventoryGrid.GetSlots();
        int lineLength = size.y;

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                int index = x * lineLength + y;
                InventorySlotView slotView = view.GetInventorySlotView(index);
                IInventorySlot slot = slots[x, y];
                _slotPresenters.Add(new InventorySlotPresenter(slot, slotView, container));
            }
        }
    }
}

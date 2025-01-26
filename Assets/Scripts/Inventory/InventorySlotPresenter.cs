using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class InventorySlotPresenter
{
    private readonly InventorySlotView _slotView;

    public InventorySlotPresenter(IInventorySlot slot, InventorySlotView view, DiContainer container)
    {
        _slotView = view;

        slot.OnItemIDChanged += ItemIDChanged;
        slot.OnItemAmountChanged += ItemAmountChanged;
        view.Icon = container.Resolve<Dictionary<string, Sprite>>()[slot.ItemID];
        view.Amount = slot.Amount;
    }

    private void ItemIDChanged(string newItemID)
    {
        _slotView.Icon = GetItemIcon(newItemID);
    }
    private void ItemAmountChanged(int newAmount)
    {
        _slotView.Amount = newAmount;
    }
    private Sprite GetItemIcon(string itemID)
    {
        return null;
    }
}

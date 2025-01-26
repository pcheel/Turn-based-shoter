using System;
using UnityEngine;

public class InventorySlot : IInventorySlot
{
    public string ItemID
    {
        get => _data.itemID;
        set
        {
            if (_data.itemID != value)
            {
                _data.itemID = value;
                OnItemIDChanged?.Invoke(value);
            }
        }
    }
    public int Amount
    {
        get => _data.amount;
        set
        {
            if (_data.amount != value)
            {
                _data.amount = value;
                OnItemAmountChanged?.Invoke(value);
            }
        }
    }
    public bool IsEmpty => Amount == 0 && string.IsNullOrEmpty(ItemID);

    private readonly InventorySlotData _data;

    public InventorySlot(InventorySlotData data)
    {
        _data = data;
    }

    public event Action<string> OnItemIDChanged;
    public event Action<int> OnItemAmountChanged;
}

using System;
using UnityEngine;

public interface IInventorySlot
{
    public event Action<string> OnItemIDChanged;
    public event Action<int> OnItemAmountChanged;

    public string ItemID { get; }
    public int Amount { get; }
    public bool IsEmpty { get; }
}

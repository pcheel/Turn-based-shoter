using System;
using UnityEngine;

public interface IInventoryGrid
{
    public event Action<string, int> OnIntemsAdded;
    public event Action<string, int> OnItemsRemoved;
    public event Action<Vector2Int> OnSizeChanged;

    public Vector2Int Size { get; }

    public int GetAmount(string itemID);
    public bool Has(string itemID, int amount);
    public IInventorySlot[,] GetSlots(); 
}

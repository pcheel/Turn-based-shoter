using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : IInventoryGrid
{
    public Vector2Int Size
    {
        get => _data.size;
        set
        {
            if (_data.size != value)
            {
                _data.size = value;
                OnSizeChanged?.Invoke(value);
            }
        }
    }

    public event Action<string, int> OnIntemsAdded;
    public event Action<string, int> OnItemsRemoved;
    public event Action<Vector2Int> OnSizeChanged;

    private readonly InventoryGridData _data;
    private readonly InventorySlot[,] _slotsMap; 

    public InventoryGrid(InventoryGridData data)
    {
        _data = data;
        //_slotsMap = new Dictionary<Vector2Int, InventorySlot>();
        _slotsMap = new InventorySlot[_data.size.x,_data.size.y];
        FillSlotsMap();
    }
    public void AddItems(string itemID, int amount)
    {
        int remainingAmount = amount;
        int itemsAddedToSlotsWithSameItemaAmount = AddToSlotsWithSameItems(itemID, remainingAmount, out remainingAmount);

        int itemsAddedToAvailableSlotsAmount = AddToFirstAvailableSlot(itemID, remainingAmount, out remainingAmount);
    }
    public void AddItems(Vector2Int slotPosition, string itemID, int amount)
    {
        InventorySlot slot = _slotsMap[slotPosition.x, slotPosition.y];
        int newAmount = slot.Amount + amount;
        int itemsAddedAmount = 0;

        if (slot.IsEmpty)
        {
            slot.ItemID = itemID;
        }

        int itemSlotCapacity = GetItemSlotCapacity(itemID);

        if (newAmount > itemSlotCapacity)
        {
            int remainingItems = newAmount - itemSlotCapacity;
            int itemsToAddAmount = itemSlotCapacity - slot.Amount;
            itemsAddedAmount += itemsToAddAmount; //?
            slot.Amount = itemSlotCapacity;
            AddItems(itemID, remainingItems);
        }
        else
        {
            slot.Amount = newAmount;
        }
    }
    public void RemoveItems(string itemID, int amount)
    {
        if (!Has(itemID, amount))
            return;

        int amountToRemove = amount;

        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                InventorySlot slot = _slotsMap[x, y];

                if (slot.ItemID != itemID)
                    continue;

                if (amountToRemove > slot.Amount)
                {
                    amountToRemove -= slot.Amount;
                    RemoveItems(new Vector2Int(x, y), itemID, slot.Amount);
                }
                else
                    RemoveItems(new Vector2Int(x, y), itemID, amountToRemove);
            }
        }
    }
    public void RemoveItems(Vector2Int slotPosition, string itemID, int amount)
    {
        InventorySlot slot = _slotsMap[slotPosition.x , slotPosition.y];
        if (slot.IsEmpty || slot.ItemID != itemID || slot.Amount < amount)
        {
            return;
        }

        slot.Amount -= amount;
        if (slot.Amount == 0)
        {
            slot.ItemID = null;
        }
    }
    public int GetAmount(string itemID)
    {
        int amount = 0;
        foreach (InventorySlot slot in _slotsMap)
        {
            if (slot.ItemID == itemID)
                amount += slot.Amount;
        }

        return amount; 
    }
    public IInventorySlot[,] GetSlots()
    {
        IInventorySlot[,] slotsMap = new IInventorySlot[Size.x, Size.y];
        Vector2Int size = Size;
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                slotsMap[x, y] = _slotsMap[x, y];
            }
        }
        return slotsMap;
    }
    public bool Has(string itemID, int amount)
    {
        return GetAmount(itemID) >= amount;
    }
    public void SwitchSlots(Vector2Int firstSlotPosition, Vector2Int secondSlotPosition)
    {
        InventorySlot firstSlot = _slotsMap[firstSlotPosition.x, firstSlotPosition.y];
        InventorySlot secondSlot = _slotsMap[secondSlotPosition.x, secondSlotPosition.y];
        string additionalSlotItemID = firstSlot.ItemID;
        int additionalSlotAmount = firstSlot.Amount;
        firstSlot.ItemID = secondSlot.ItemID;
        firstSlot.Amount = secondSlot.Amount;
        secondSlot.ItemID = additionalSlotItemID;
        secondSlot.Amount = additionalSlotAmount;
    }
    private void FillSlotsMap()
    {
        Vector2Int size = Size;
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                int index = x * size.y + y;
                InventorySlotData slotData = _data.slots[index];
                InventorySlot slot = new InventorySlot(slotData);
                _slotsMap[x,y] = slot;
            }
        }
    }
    private int GetItemSlotCapacity(string itemID)
    {
        return 10;
    }
    private int AddToSlotsWithSameItems(string itemID, int amount, out int remainingAmount)
    {
        int itemsAddedAmount = 0;
        remainingAmount = amount;

        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                InventorySlot slot = _slotsMap[x, y];
                if (slot.IsEmpty)
                    continue;

                if (slot.ItemID != itemID)
                    continue;

                int slotItemCapacity = GetItemSlotCapacity(slot.ItemID);
                if (slot.Amount == slotItemCapacity)
                    continue;

                int newAmount = slot.Amount + remainingAmount;
                if (newAmount > slotItemCapacity)
                {
                    remainingAmount = newAmount - slotItemCapacity;
                    int itemsToAddAmount = slotItemCapacity - slot.Amount;
                    itemsAddedAmount += itemsToAddAmount;
                    slot.Amount = slotItemCapacity;

                    if (remainingAmount == 0)
                    {
                        return itemsAddedAmount;
                    }
                }
                else
                {
                    itemsAddedAmount += remainingAmount;
                    slot.Amount = newAmount;
                    remainingAmount = 0;
                    return itemsAddedAmount;
                }
            }
        }

        return itemsAddedAmount;
    }
    private int AddToFirstAvailableSlot(string itemID, int amount, out int remainingAmount)
    {
        int itemsAddedAmount = 0;
        remainingAmount = amount;

        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                InventorySlot slot = _slotsMap[x, y];
                if (!slot.IsEmpty)
                    continue;

                slot.ItemID = itemID;
                int newAmount = remainingAmount;
                int slotItemCapacity = GetItemSlotCapacity(slot.ItemID);

                if (newAmount > slotItemCapacity)
                {
                    remainingAmount = newAmount - slotItemCapacity;
                    int itemsToAddAmount = slotItemCapacity;
                    itemsAddedAmount += itemsToAddAmount;
                    slot.Amount = slotItemCapacity;
                }
                else
                {
                    itemsAddedAmount += remainingAmount;
                    slot.Amount = newAmount;
                    remainingAmount = 0;

                    return itemsAddedAmount;
                }
            }
        }

        return itemsAddedAmount;
    }
}

using System.Runtime.CompilerServices;
using UnityEngine;

public class InventoryGridView : MonoBehaviour
{
    [SerializeField] InventorySlotView[] _slots;
    
    public InventorySlotView GetInventorySlotView(int index)
    {
        return _slots[index];
    }
}

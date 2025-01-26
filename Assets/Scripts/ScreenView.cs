using UnityEngine;

public class ScreenView : MonoBehaviour
{
    [SerializeField] private InventoryGridView _inventoryGridView;

    public InventoryGridView inventoryGridView => _inventoryGridView;
}

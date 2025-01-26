using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class InventorySlotView : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TMP_Text _itemAmount;

    public Sprite Icon
    {
        get => _itemIcon.sprite;
        set => _itemIcon.sprite = value;
    }
    public int Amount
    {
        get => Convert.ToInt32(_itemAmount.text);
        set => _itemAmount.text = value == 0 ? "" : value.ToString();
    }

}

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ModestTree;

public class ItemPopupView : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private Image _itemIcon;
    [SerializeField] private Image _armorIcon;
    [SerializeField] private TMP_Text _armor;
    [SerializeField] private Image _healthIcon;
    [SerializeField] private TMP_Text _health;
    [SerializeField] private Image _weightIcon;
    [SerializeField] private TMP_Text _weight;
    [SerializeField] private Image _amountIcon;
    [SerializeField] private TMP_Text _amount;

    public void ShowPopup(ItemPopupData data)
    {
        ShowName(data.name);
        ShowIcon(data.icon);
        if (!data.armor.IsEmpty())
            ShowArmor(data.armor);
        if (!data.health.IsEmpty())
            ShowHealth(data.health);
        if (!data.weight.IsEmpty())
            ShowWeight(data.weight);
        if (!data.amount.IsEmpty())
            ShowAmount(data.amount);
    }
    private void ShowName(string name)
    {
        _itemName.text = name;
    }
    private void ShowIcon(Sprite icon)
    {
        _itemIcon.sprite = icon;
    }
    private void ShowArmor(string armor)
    {
        _armorIcon.gameObject.SetActive(true);
        _armor.gameObject.SetActive(true);
        _armor.text = armor;
    }
    private void ShowHealth(string health)
    {
        _healthIcon.gameObject.SetActive(true);
        _health.gameObject.SetActive(true);
        _health.text = health;
    }
    private void ShowWeight(string weight)
    {
        _weightIcon.gameObject.SetActive(true);
        _weight.gameObject.SetActive(true);
        _weight.text = weight;
    }
    private void ShowAmount(string amount)
    {
        _amountIcon.gameObject.SetActive(true);
        _amount.gameObject.SetActive(true);
        _amount.text = amount;
    }
    private void ClosePopup()
    {
        _armorIcon.gameObject.SetActive(false);
        _armor.gameObject.SetActive(false);
        _weightIcon.gameObject.SetActive(false);
        _weight.gameObject.SetActive(false);
        _amountIcon.gameObject.SetActive(false);
        _amount.gameObject.SetActive(false);
    }
}

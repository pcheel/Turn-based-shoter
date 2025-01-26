using UnityEngine;

public class ItemPopupPresenter
{
    private readonly ItemPopup _itemPopup;
    private readonly ItemPopupView _itemPopupView;
    public ItemPopupPresenter(ItemPopup itemPopup, ItemPopupView itemPopupView)
    {
        _itemPopup = itemPopup;
        _itemPopupView = itemPopupView;


    }

    public void ShowItem(ItemPopupData data)
    {
        _itemPopupView.ShowPopup(data);
    }
}

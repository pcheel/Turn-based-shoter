using UnityEngine;

public class ScreenPresenter
{
    private readonly ScreenView _screenView;
    private readonly InventoryGridPresenter _intenotoryGridPresenter;

    public ScreenPresenter(ScreenView screenView, InventoryGridPresenter inventoryPresenter)
    {
        _screenView = screenView;
        _intenotoryGridPresenter = inventoryPresenter;
    }
}

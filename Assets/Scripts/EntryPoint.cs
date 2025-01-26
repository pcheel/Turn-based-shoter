using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private InventoryGridView _inventoryGridView;
    [SerializeField] private GameStateProvider _gameStateProvider;
    [SerializeField] private IconsData _iconsData;

    private InventoryGrid _inventoryGrid;
    private InventoryGridPresenter _inventoryGridPresenter;
    private GameData _gameData;
    private Dictionary<string, Sprite> _iconsMap;
    private DiContainer _container;

    [Inject]
    public void Construct(DiContainer container)
    {
        _container = container;
    }
    private void Start()
    {
        _gameData = _gameStateProvider.LoadGame();
        InitializeIconsMap();
        InventoryGrid inventoryGrid = new InventoryGrid(_gameData.inventory);
        InventoryGridPresenter inventoryGridPresenter = new InventoryGridPresenter(inventoryGrid, _inventoryGridView, _container);
    }

    private void InitializeIconsMap()
    {
        _iconsMap = new Dictionary<string, Sprite>();
        foreach(IconData iconData in _iconsData.iconsData)
        {
            _iconsMap.Add(iconData.itemID, iconData.icon);
        }
        _container.Bind<Dictionary<string, Sprite>>().FromInstance(_iconsMap);
        Debug.Log("end");
    }
}

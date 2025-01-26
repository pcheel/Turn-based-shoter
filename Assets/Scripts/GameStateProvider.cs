using UnityEngine;
using System.Collections.Generic;

public class GameStateProvider : MonoBehaviour
{
    [SerializeField] private DefaultGameData _defaultGameData;
    private string _dataPath;
    private GameData _gameData;

    public GameData gameData => _gameData;

    public void Awake()
    {
        _dataPath = Application.persistentDataPath + $"/GameData.json";
    }
    public void SaveGame()
    {

    }
    public GameData LoadGame()
    {
        _gameData = new GameData();
        if (System.IO.File.Exists(_dataPath))
        {
            string gameDataJson = System.IO.File.ReadAllText(_dataPath);
            _gameData = JsonUtility.FromJson<GameData>(gameDataJson);
        }
        else
        {
            InventoryGridData inventoryGridData = new InventoryGridData();
            inventoryGridData.slots = new List<InventorySlotData>();
            inventoryGridData.size = _defaultGameData.inventoryData.size;
            for (int i = 0; i < _defaultGameData.inventoryData.slotsData.Count; i++)
            {
                InventorySlotData slotData = new InventorySlotData();
                slotData.itemID = _defaultGameData.inventoryData.slotsData[i].itemID;
                slotData.amount = _defaultGameData.inventoryData.slotsData[i].amount;
                inventoryGridData.slots.Add(slotData);
            }
            _gameData.inventory = inventoryGridData;
        }
        return _gameData;
    }
}

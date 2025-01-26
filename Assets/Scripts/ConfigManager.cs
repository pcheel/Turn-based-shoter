using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ConfigManager
{
    [SerializeField] private IconsData _iconsData;

    private Dictionary<string, Sprite> _iconsMap;
    private DiContainer _container;

    public ConfigManager(DiContainer container)
    {
        _container = container;
        InitializeIconsMap();
    }

    private void InitializeIconsMap()
    {
        _iconsMap = new Dictionary<string, Sprite>();
        foreach (IconData iconData in _iconsData.iconsData)
        {
            _iconsMap.Add(iconData.itemID, iconData.icon);
        }
        _container.Bind<Dictionary<string, Sprite>>().FromInstance(_iconsMap);
    }
}

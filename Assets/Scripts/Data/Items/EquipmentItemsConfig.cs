using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "EquipmentItemsConfig", menuName = "Scriptable Objects/EquipmentItemsConfig")]
public class EquipmentItemsConfig : ScriptableObject
{
    public List<EquipmentItemConfig> items;
}

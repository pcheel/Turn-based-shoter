using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentItemConfig", menuName = "Scriptable Objects/EquipmentItemConfig")]
public class EquipmentItemConfig : ScriptableObject
{
    public string itemID;
    public string name;
    public ArmorType armorType;
    public int armor;
    public int maxAmount;
    public float weight;
}

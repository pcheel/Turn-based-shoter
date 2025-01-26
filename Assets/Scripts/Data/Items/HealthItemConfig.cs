using UnityEngine;

[CreateAssetMenu(fileName = "HealthItemConfig", menuName = "Scriptable Objects/HealthItemConfig")]
public class HealthItemConfig : ScriptableObject
{
    public string itemID;
    public string name;
    public int healValue;
    public int maxAmount;
    public float weight;
}

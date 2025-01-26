using UnityEngine;

[CreateAssetMenu(fileName = "BulletItemConfig", menuName = "Scriptable Objects/BulletItemConfig")]
public class BulletItemConfig : ScriptableObject
{
    public string itemID;
    public string name;
    public Calibre calibre;
    public int maxAmount;
    public float weight;
}

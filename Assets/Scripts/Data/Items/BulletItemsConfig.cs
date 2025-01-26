using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "BulletItemsConfig", menuName = "Scriptable Objects/BulletItemsConfig")]
public class BulletItemsConfig : ScriptableObject
{
    public List<BulletItemConfig> items;
}

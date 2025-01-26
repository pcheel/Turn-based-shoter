using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "DefaultInventoryData", menuName = "Scriptable Objects/DefaultInventoryData")]
public class DefaultInventoryData : ScriptableObject
{
    public List<DefaultSlotData> slotsData;
    public Vector2Int size;
}

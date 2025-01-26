using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "MedicalItemsConfig", menuName = "Scriptable Objects/MedicalItemsConfig")]
public class MedicalItemsConfig : ScriptableObject
{
    public List<HealthItemConfig> items;
}

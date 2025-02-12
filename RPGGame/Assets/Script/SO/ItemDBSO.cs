using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

[CreateAssetMenu]
public class ItemDBSO : ScriptableObject
{
    public List<ItemSO> itemList;
}

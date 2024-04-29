using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Material,Food,Weapon}

public class ItemScriptable : ScriptableObject
{
    public GameObject ItemObject;
    public ItemType itemType;
    public string ItemName;
    public int maxAmount;
    public string itemDescription;
    public Sprite icon;
}

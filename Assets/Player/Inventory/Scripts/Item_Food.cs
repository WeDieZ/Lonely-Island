using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Food Item", menuName = "Inventory/Items/Food Item")]

public class Item_Food : ItemScriptable
{
    public float foodAmount;

    private void Start()
    {
        itemType = ItemType.Food;
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : List<Item>
{
    public void combine()
    {

    }

    public void print()
    {
        Debug.Log(this.Count > 0 ? "List of Items:" : "No Items stored ...");

        foreach(Item i in this)
        {
            Debug.Log(i.item_name);
        }
    }
}

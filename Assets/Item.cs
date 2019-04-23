using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public readonly string item_name;

    public Item(string item_name)
    {
        this.item_name = item_name;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("item collided");
    }
}

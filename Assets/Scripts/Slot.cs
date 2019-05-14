using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public int ID;
    public string item_name;
    public string description;
    public bool combinable;
    public bool empty;
    public Sprite icon;


    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
    }

}

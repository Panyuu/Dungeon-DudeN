using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    
    private bool inventoryEnabled;
    public GameObject inventory;

    private int slotnum;
    private GameObject[] slot;

    public GameObject slotHolder;

    void Start()
    {
        slotnum = 9;

        slot = new GameObject[slotnum];

        for (int i = 0; i < slotnum; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            inventoryEnabled = !inventoryEnabled;

        if (inventoryEnabled == true)
        {
            inventory.SetActive(true);
        } else{
            inventory.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("N collided!");
        if (collision.gameObject.name == "Item")
        {
            //AddItem(collision.gameObject.ID, collision.gameObject.name, collision.gameObject.description, collision.gameObject.icon);
            GameObject itemPickedUp = collision.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();
            AddItem(itemPickedUp, item.ID, item.item_name, item.description, item.combinable, item.icon); 
            Destroy(collision.gameObject);
        }
    }

    void AddItem(GameObject itemObject, int itemID, string itemName, string itemDescription, bool itemCombinable, Sprite itemIcon)
    {


        Debug.Log("test");
        Debug.Log(itemID);
        Debug.Log(itemName);
        Debug.Log(itemDescription);
        Debug.Log(itemCombinable);

        for (int i = 0; i < slotnum; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().item_name = itemName;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().combinable = itemCombinable;
                slot[i].GetComponent<Slot>().description = itemDescription;


                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
            }
            return;
        }
    }


}

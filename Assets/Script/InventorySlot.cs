using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private int maxSize;

    private InventoryMaster master;

    [SerializeField]
    private Item currentItem;

    /// <summary>
    /// Start function
    /// </summary>
    /// <param name="a_Master"></param>
    public void Assign(InventoryMaster a_Master)
    {
        master = a_Master;
    }

    public void OnLeftClick()
    {
        Debug.Log("Click on inventoryslot");

        Item playerItemHolding = master.GetCurrentItem();
        if (playerItemHolding == null)
        {
            // grab
            Debug.Log("Grab");
        }
        else
        {
            if (currentItem == null)
            {
                Debug.Log("Insert");

                // set new item in slot
                Insert(playerItemHolding);
            }
            else
            {
                if (currentItem == playerItemHolding)
                {
                    // add item
                }
                else
                {
                    // put item into player hand
                    // put playerhand item into the item slot
                }
            }
        }
    }

    /// <summary>
    /// on click slot while its empty
    /// </summary>
    /// <param name="a_Item"></param>
    private void Insert(Item a_Item)
    {
        if (a_Item == null)
        {
            return;
        }
        else
        {
            currentItem = a_Item;
            master.SetCurrentItem(null);
        }
    }

    public void OnRightClick()
    {
        Debug.Log("Right click inventoryslot");
    }
}
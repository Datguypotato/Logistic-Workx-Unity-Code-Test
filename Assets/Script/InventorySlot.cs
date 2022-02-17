using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private int maxSize;

    private InventoryMaster master;

    private Item currentItem;

    /// <summary>
    /// Start function
    /// </summary>
    /// <param name="a_Master"></param>
    public void Assign(InventoryMaster a_Master)
    {
        master = a_Master;
    }

    public void OnClick()
    {
        Debug.Log("Click on inventoryslot");

        Item playerItemHolding = master.GetCurrentItem();
        if (playerItemHolding == null)
        {
            // grab
        }
        else
        {
            if (currentItem == null)
            {
                // set new item in slot
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
        }
    }
}
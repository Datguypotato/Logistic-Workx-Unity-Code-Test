using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// TODO Item splitting

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    private int maxSize;

    private InventoryMaster master;

    [SerializeField]
    private Item slotItem;

    [SerializeField]
    private Image slotSprite;

    [SerializeField]
    private TMP_Text counter;

    /// <summary>
    /// Start function
    /// </summary>
    /// <param name="a_Master"></param>
    public void Assign(InventoryMaster a_Master)
    {
        master = a_Master;
        UpdateGraphics();
    }

    public void OnLeftClick()
    {
        Debug.Log("Click on inventoryslot");

        Item playerItemHolding = master.GetCurrentItem();
        if (playerItemHolding == null)
        {
            // grab
            Debug.Log("Grab");
            Grab();
        }
        else
        {
            if (slotItem == null)
            {
                Debug.Log("Insert");

                // set new item in slot
                Insert(playerItemHolding);
            }
            else
            {
                if (slotItem == playerItemHolding)
                {
                    // add item
                    Add(playerItemHolding.currentAmount);
                }
                else
                {
                    // put item into player hand
                    // put playerhand item into the item slot
                    Swap(playerItemHolding);
                }
            }
        }

        UpdateGraphics();
    }

    public void OnRightClick()
    {
        Debug.Log("Right click inventoryslot");
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
            slotItem = a_Item;
            slotSprite.sprite = a_Item.itemSprite;
            master.SetCurrentItem(null);
        }
    }

    private void Add(int a_Amount)
    {
        slotItem.currentAmount += a_Amount;
        master.SetCurrentItem(null);
    }

    private void Grab()
    {
        master.SetCurrentItem(slotItem);
        slotItem = null;
    }

    private void Swap(Item a_Item)
    {
        Item temp = slotItem;

        slotItem = a_Item;
        master.SetCurrentItem(temp);
    }

    private void UpdateGraphics()
    {
        if (slotItem == null)
        {
            slotSprite.color = Color.clear;
            counter.text = "";
        }
        else
        {
            slotSprite.color = Color.white;
            counter.text = slotItem.currentAmount.ToString();
            slotSprite.sprite = slotItem.itemSprite;
        }
    }
}
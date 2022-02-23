using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// TODO Item splitting

public class InventorySlot : InventoryBaseSlot
{
    [SerializeField]
    private int maxSize;

    [SerializeField]
    private Item slotItem;

    [SerializeField]
    private Image slotSprite;

    [SerializeField]
    private TMP_Text counter;

    public override void Assign(InventoryMaster a_Master)
    {
        base.Assign(a_Master);
        UpdateGraphics();
    }

    #region Left click

    public override void OnLeftClick()
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
                Debug.Log(slotItem.itemName + " == " + playerItemHolding.itemName);
                if (slotItem.itemName == playerItemHolding.itemName)
                {
                    // add item
                    Add(playerItemHolding.currentAmount);
                }
                else // doesnt come through
                {
                    // put item into player hand
                    // put playerhand item into the item slot
                    Swap(playerItemHolding);
                }
            }
        }

        UpdateGraphics();
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

    #endregion Left click

    #region Right click

    public override void OnRightClick()
    {
        Item playerItemHolding = master.GetCurrentItem();

        if (playerItemHolding != null)
        {
            // put one in the slot
            slotItem = Item.CopyOneAmount(playerItemHolding.itemName, playerItemHolding.itemSprite, playerItemHolding.maxStack);
            playerItemHolding.currentAmount--;

            if (playerItemHolding.currentAmount <= 0)
                master.SetCurrentItem(null);
        }
        else
        {
            // split grab the item

            int half = slotItem.currentAmount / 2;
            master.SetCurrentItem(Item.CreateInstance(slotItem.itemName, slotItem.itemSprite, slotItem.maxStack, half));
            slotItem.currentAmount -= half;
        }

        UpdateGraphics();
    }

    #endregion Right click

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
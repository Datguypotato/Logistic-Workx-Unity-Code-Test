using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGarbageSlot : InventoryBaseSlot
{
    public override void OnLeftClick()
    {
        master.SetCurrentItem(null);
    }

    public override void OnRightClick()
    {
        master.GetCurrentItem().currentAmount--;
    }
}
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
        if (master.GetCurrentItem() == null)
            return;

        master.GetCurrentItem().currentAmount--;

        if (master.GetCurrentItem().currentAmount <= 0)
            master.SetCurrentItem(null);
    }
}
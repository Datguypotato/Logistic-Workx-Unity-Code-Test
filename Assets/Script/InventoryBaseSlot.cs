using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryBaseSlot : MonoBehaviour
{
    protected InventoryMaster master;

    /// <summary>
    /// Calls when left click the inventory slots
    /// </summary>
    public abstract void OnLeftClick();

    /// <summary>
    /// Calls when right click the inventory slots
    /// </summary>
    public abstract void OnRightClick();

    /// <summary>
    /// Start function
    /// </summary>
    /// <param name="a_Master"></param>
    public virtual void Assign(InventoryMaster a_Master)
    {
        master = a_Master;
    }
}
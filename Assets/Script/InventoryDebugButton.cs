using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryDebugButton : MonoBehaviour
{
    [SerializeField] private Item copyItem;
    [SerializeField] private TMP_InputField inputField;

    public void CreateCopy()
    {
        InventoryMaster master = FindObjectOfType<InventoryMaster>();

        if (master.GetCurrentItem() != null)
            return;

        Item wood = Item.CreateInstance(copyItem.itemName, copyItem.itemSprite, copyItem.maxStack, int.Parse(inputField.text));
        master.SetCurrentItem(wood);
    }
}
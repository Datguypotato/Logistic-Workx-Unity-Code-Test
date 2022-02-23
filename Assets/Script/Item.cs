using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New item", menuName = "Item", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField]
    public string itemName;

    public Sprite itemSprite;

    public int maxStack;
    public int currentAmount = 1;

    public void init(string a_ItemName, Sprite a_ItemSprite, int a_MaxStack, int a_Amount)
    {
        itemName = a_ItemName;
        itemSprite = a_ItemSprite;
        maxStack = a_MaxStack;
        currentAmount = a_Amount;
    }

    public static Item CreateInstance(string a_ItemName, Sprite a_ItemSprite, int a_MaxStack, int a_Amount)
    {
        var item = CreateInstance<Item>();
        item.init(a_ItemName, a_ItemSprite, a_MaxStack, a_Amount);
        return item;
    }

    /// <summary>
    /// for putting one item in a slot
    /// for the rightclick mechanic
    /// </summary>
    /// <param name="a_ItemName"></param>
    /// <param name="a_ItemSprite"></param>
    /// <param name="a_MaxStack"></param>
    /// <returns></returns>
    public static Item CopyOneAmount(string a_ItemName, Sprite a_ItemSprite, int a_MaxStack)
    {
        var item = CreateInstance<Item>();
        item.init(a_ItemName, a_ItemSprite, a_MaxStack, 1);
        return item;
    }
}
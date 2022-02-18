using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Item", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField]
    public string itemName;

    public Sprite itemSprite;

    public int maxStack;
    public int currentAmount = 1;
}
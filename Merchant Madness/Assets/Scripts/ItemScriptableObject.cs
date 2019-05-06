using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemScriptableObject : ScriptableObject {
    [Header("Item Info")]
    public string itemDisplayName;
    public string itemCodeName;
    public string itemLore;

    [Header("Item Type")]
    public itemType itemtype;

    [Header("Item Stats")]
    public float entityDefaultDamage;
    public float treeDefaultDamage;
    public float rockDefaultDamage;


    public enum itemType {Item, Sword, Axe, Pickaxe, Special }
}
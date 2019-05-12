using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Merchant", menuName = "Merchant")]
public class MerchantScriptableObject : ScriptableObject
{
    [Header("Merchant Info")]
    public new string name;
    public int welcomeText;
    public int thankYouText;

    [Header("1 = Green, 2 = Red, 3 = Blue, 4 = Yellow, 5 = Grey")]
    public int color;

    [Header("Total amount of items this merchant sells")]
    public int totalItemAmount;

    [Header("Item Info")]
    public ItemScriptableObject item;

    public string itemDisplayName;
    public string itemCodeName;
    public int itemAmount;
    public int itemPrice;
    public List<ItemScriptableObject> itemRequirments;
}

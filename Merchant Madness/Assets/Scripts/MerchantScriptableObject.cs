using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Merchant", menuName = "Merchant")]
public class MerchantScriptableObject : ScriptableObject
{
    public new string name;
    public string welcomeText;
    public string thankYouText;

    public int totalItemAmount;

    public string itemDisplayName;
    public string itemCodeName;
    public int itemAmount;
    public int itemPrice;
}

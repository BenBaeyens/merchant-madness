using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Merchant", menuName = "Merchant")]
public class MerchantScriptableObject : ScriptableObject
{
    public new string name;
    public string welcomeText;
    public string thankYouText;

    public string item1DisplayName;
    public string item1CodeName;
    public int item1Amount;
    public int item1Price;

    public string item2DisplayName;
    public string item2CodeName;
    public int item2Amount;
    public int item2Price;
}

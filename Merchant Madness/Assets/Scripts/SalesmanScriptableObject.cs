using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Salesman", menuName = "Salesman")]
public class SalesmanScriptableObject : ScriptableObject
{
    [Header("Salesman Info")]
    public new string name;
    public int welcomeText;
    public int thankYouText;

    [Header("1 = GREEN, 2 = RED, 3 = BLUE, 4 = YELLOW")]
    public int color;

    [Header("Total amount of items you can sell the salesman")]
    public int totalItemAmount;

    [Header("Item you want to sell - Info")]
    public string itemDisplayName;
    public string itemCodeName;
    public int itemAmount;
    public int itemCompensation;
    public string itemRequirement;
}

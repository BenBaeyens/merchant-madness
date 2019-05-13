using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int goldCoins;
    public List<ItemScriptableObject> inventory;

    public TextMeshProUGUI balanceDisplay;

    private void Start() {
        inventory = new List<ItemScriptableObject>();
    }

    private void Update() {
        balanceDisplay.text = goldCoins.ToString();
    }
}

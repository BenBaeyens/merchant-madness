using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int goldCoins;
    public List<string> inventory;

    [SerializeField] TextMeshProUGUI balanceDisplay;

    private void Start() {
        inventory = new List<string>();
    }

    private void Update() {
        balanceDisplay.text = goldCoins.ToString();
    }
}

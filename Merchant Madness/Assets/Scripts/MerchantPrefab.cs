using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MerchantPrefab : MonoBehaviour
{
    [Header("Define")]
    [SerializeField] MerchantScriptableObject merchant;

    [Header("Predefined (DO NOT TOUCH)")]
    [SerializeField] Player player;
    [SerializeField] GameObject clickText;
    [SerializeField] AudioSource source;

    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemPrice;
    [SerializeField] TextMeshProUGUI itemAmount;

    bool isPlayerInRange = false;

    private void Start() {
        source = gameObject.AddComponent<AudioSource>();
       
        player = FindObjectOfType<Player>();
        GameObject[] tempobjects = Resources.FindObjectsOfTypeAll<GameObject>();
        for (int i = 0; i < tempobjects.Length; i++)
        {
            if(tempobjects[i].name == "ClickText")
            {
                clickText = tempobjects[i];
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        isPlayerInRange = true;
        clickText.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other) {
        isPlayerInRange = false;
        clickText.gameObject.SetActive(false);
    }

    void Update()
    {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            source.clip = Resources.Load<AudioClip>(merchant.welcomeText);
            source.Play();
            itemName.text = merchant.item1DisplayName;
            itemPrice.text = merchant.item1Price.ToString() + " Gold Coins";
            itemAmount.text = merchant.item1Amount.ToString() + "x";
        }
    }


    public void Purchase() {
        if(player.goldCoins >= merchant.item1Price)
        {
            source.clip = Resources.Load<AudioClip>(merchant.thankYouText);
            source.Play();
            player.goldCoins -= merchant.item1Price;
            player.inventory.Add(merchant.item1CodeName.ToString());
            Debug.Log(merchant.item1DisplayName + " aquired.");
            Debug.Log(player.goldCoins);

            StopTransaction();
        }
    }

    public void StopTransaction() {
        transform.GetChild(0).gameObject.SetActive(false);
        Debug.Log("Transaction ended.");
    }

    
}

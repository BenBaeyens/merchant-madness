using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MerchantPrefab : MonoBehaviour
{
    [Header("Define the merchant type")]
    [SerializeField] MerchantScriptableObject merchant;

    Player player;
    GameObject clickText;
    AudioSource source;
    GameObject soldOutText;

    
    TextMeshProUGUI itemName;
    TextMeshProUGUI itemPrice;
    TextMeshProUGUI itemAmount;

    bool isPlayerInRange = false;
    int totalAmountOfItems;

    private void Start() {
        GenerateColor();
        totalAmountOfItems = merchant.totalItemAmount;
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
        tempobjects = Resources.FindObjectsOfTypeAll<GameObject>();
        for (int i = 0; i < tempobjects.Length; i++)
        {
            if (tempobjects[i].name == "SoldOutText")
            {
                soldOutText = tempobjects[i];
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
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.Space) && totalAmountOfItems > 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            source.clip = Resources.Load<AudioClip>(merchant.welcomeText);
            source.Play();
            itemName.text = merchant.itemDisplayName;
            itemPrice.text = merchant.itemPrice.ToString() + " Gold Coins";
            itemAmount.text = merchant.itemAmount.ToString() + "x";
        }
       else  if (isPlayerInRange && Input.GetKeyDown(KeyCode.Space) && totalAmountOfItems == 0)
        {
            StartCoroutine(SoldOut());
        }
    }


    public void Purchase() {
        if(player.goldCoins >= merchant.itemPrice)
        {
            source.clip = Resources.Load<AudioClip>(merchant.thankYouText);
            source.Play();
            player.goldCoins -= merchant.itemPrice;
            player.inventory.Add(merchant.itemCodeName.ToString());
            Debug.Log(merchant.itemDisplayName + " aquired.");
            Debug.Log(player.goldCoins);
            totalAmountOfItems--;

            StopTransaction();
        }
    }

    public void StopTransaction() {
        transform.GetChild(0).gameObject.SetActive(false);
        Debug.Log("Transaction ended.");
    }

    public void GenerateColor() {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    IEnumerator SoldOut() {
        soldOutText.SetActive(true);
        yield return new WaitForSeconds(1);
        soldOutText.SetActive(false);
    }
    
}

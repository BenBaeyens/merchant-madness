using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MerchantPrefab : MonoBehaviour
{
    [Header("Define the merchant type")]
    public MerchantScriptableObject merchant;

    Player player;
    AudioSource source;
    GameObject soldOutText;
    GameObject merchantEntity;

    MerchantEntity me;

    
    [HideInInspector] public TextMeshProUGUI itemName;
    [HideInInspector] public TextMeshProUGUI itemPrice;
    [HideInInspector] public TextMeshProUGUI itemAmount;

    int totalAmountOfItems;

    private void Start() {
        merchantEntity = GameObject.Find(gameObject.name + "Entity");
       

        me = GameObject.Find(gameObject.name + "Entity").GetComponent<MerchantEntity>();
        totalAmountOfItems = merchant.totalItemAmount;
        source = gameObject.AddComponent<AudioSource>();
       
        player = FindObjectOfType<Player>();

        GameObject[] tempobjects;
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

    void Update()
    {
        if(me.isPlayerInRange && Input.GetKeyDown(KeyCode.Space) && totalAmountOfItems > 0)
        {
            Time.timeScale = 0f;
            //Get the menu and set it active
            transform.GetChild(0).gameObject.SetActive(true); 

            source.clip = Resources.Load<AudioClip>(merchant.welcomeText);
            source.Play();
            itemName.text = merchant.itemDisplayName;
            itemPrice.text = merchant.itemPrice.ToString() + " Gold Coins";
            itemAmount.text = merchant.itemAmount.ToString() + "x";
        }
       else  if (me.isPlayerInRange && Input.GetKeyDown(KeyCode.Space) && totalAmountOfItems == 0)
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
        Time.timeScale = 1f;
    }

    IEnumerator SoldOut() {
        soldOutText.SetActive(true);
        yield return new WaitForSeconds(1);
        soldOutText.SetActive(false);
    }
    
}

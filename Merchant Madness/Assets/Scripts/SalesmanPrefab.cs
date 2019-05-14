using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SalesmanPrefab : MonoBehaviour
{
    [Header("Define the merchant type")]
    public SalesmanScriptableObject salesman;

    Player player;
    AudioSource source;

    MerchantEntity me;

    
    [HideInInspector] public TextMeshProUGUI itemName;
    [HideInInspector] public TextMeshProUGUI itemCompensation;
    [HideInInspector] public TextMeshProUGUI itemAmount;

    int _itemAmount;



    private void Start() {
       

        me = GameObject.Find(gameObject.name + "Entity").GetComponent<MerchantEntity>();
        source = gameObject.AddComponent<AudioSource>();
       
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if(me.isPlayerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            //Get the menu and set it active
            transform.GetChild(0).gameObject.SetActive(true); 

            source.clip = Resources.Load<AudioClip>("Welcome" + salesman.welcomeText);
            source.Play();
            itemName.text = salesman.item.itemDisplayName;
            itemCompensation.text = salesman.item.itemPrice.ToString() + " Gold Coins";
            itemAmount.text = _itemAmount.ToString() + "x";
            for (int i = 0; i < player.inventory.Count; i++)
            {
                Debug.Log(player.inventory.Count);
                if(player.inventory[i] == salesman.item)
                {
                   _itemAmount++;
                }
            }
            itemAmount.text = _itemAmount.ToString() + "x left";
            Time.timeScale = 0f;
        }
    }


    public void Purchase() {
        if(player.inventory.Contains(salesman.item))
        {
            player.goldCoins += (int)salesman.item.itemPrice;
            player.inventory.Remove(salesman.item);
            Debug.Log(salesman.item.itemDisplayName + " sold.");
            Debug.Log(player.goldCoins);
            _itemAmount--;
        }
    }

    public void StopTransaction() {
        transform.GetChild(0).gameObject.SetActive(false);
        Debug.Log("Transaction ended.");
        Time.timeScale = 1f;
        source.clip = Resources.Load<AudioClip>("ThankYou" + salesman.thankYouText);
        source.Play();
    }

   
    
}

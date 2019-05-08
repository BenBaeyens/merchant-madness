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


    private void Start() {
       

        me = GameObject.Find(gameObject.name + "Entity").GetComponent<MerchantEntity>();
        source = gameObject.AddComponent<AudioSource>();
       
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if(me.isPlayerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0f;
            //Get the menu and set it active
            transform.GetChild(0).gameObject.SetActive(true); 

            source.clip = Resources.Load<AudioClip>("Welcome" + salesman.welcomeText);
            source.Play();
            itemName.text = salesman.itemDisplayName;
            itemCompensation.text = salesman.itemCompensation.ToString() + " Gold Coins";
            itemAmount.text = salesman.itemAmount.ToString() + "x";
        }
    }


    public void Purchase() {
        if(player.inventory.Contains(salesman.itemCodeName))
        {
            player.goldCoins += salesman.itemCompensation;
            player.inventory.Remove(salesman.itemCodeName.ToString());
            Debug.Log(salesman.itemDisplayName + " sold.");
            Debug.Log(player.goldCoins);
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

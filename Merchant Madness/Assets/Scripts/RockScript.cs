using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour {

    public float rockHealth;

    bool hasPickaxe = false;

    public GameObject rockRange;
    public GameObject player;
    public Player pl;

    public ItemScriptableObject stonechunk;

    private void Start() {
        player = GameObject.Find("Player");
        pl = player.GetComponent<Player>();
        ItemScriptableObject[] tempstone = Resources.FindObjectsOfTypeAll<ItemScriptableObject>();
        foreach(ItemScriptableObject i in tempstone)
        {
            if (i.itemCodeName == "stone_chunk")
            {
                stonechunk = i;
                break;
            }
        }
    }

    private void Update() {


        if (!hasPickaxe) {
            for (int i = 0; i < pl.inventory.Count; i++)
            {
                if (pl.inventory[i].name.Contains("pickaxe"))
                {
                    hasPickaxe = true;
                    break;
                }
            }
        }

        if (rockRange.GetComponent<TreeHitboxScript>().isPlayerInRange
            && hasPickaxe
            && Input.GetMouseButtonDown(0))
        {
            Debug.Log("hit");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitobj = hit.transform.gameObject;
                if (hitobj.name == "RockActivationRange" && hitobj.transform.parent.name == gameObject.name)
                {
                    RockDamage();
                    pl.inventory.Add(stonechunk);
                }
            }
        }


        if(rockHealth <= 0)
        {
            Destroy(gameObject);
            pl.inventory.Add(stonechunk);
        }
    }

    void RockDamage() {

        for (int i = 0; i < pl.inventory.Count; i++)
        {
            if (pl.inventory[i].name.Contains("wooden"))
            {
              
              rockHealth =- 1f;
               
            }
            
        }
        
    }

    







}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour {

    public float treeHealth;

    bool hasAxe = false;

    public GameObject treeRange;
    public GameObject player;
    public Player pl;
    public ItemScriptableObject log;

    private void Start() {
        player = GameObject.Find("Player");
        pl = player.GetComponent<Player>();
    }

    private void Update() {


        if (!hasAxe) {
            for (int i = 0; i < pl.inventory.Count; i++)
            {
                if (pl.inventory[i].name.Contains("axe"))
                {
                    hasAxe = true;
                    break;
                }
            }
        }

        if (treeRange.GetComponent<TreeHitboxScript>().isPlayerInRange
            && hasAxe
            && Input.GetMouseButtonDown(0))
        {
            Debug.Log("hit");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitobj = hit.transform.gameObject;
                if (hitobj.name == "TreeActivationRange" && hitobj.transform.parent.name == gameObject.name)
                {
                    treeHealth = TreeDamage();
                    pl.inventory.Add(log);
                }
            }
        }


        if(treeHealth <= 0)
        {
            pl.inventory.Add(log);
            Destroy(gameObject);
        }
    }

    float TreeDamage() {
        for (int i = 0; i < pl.inventory.Count; i++)
        {
            if (pl.inventory[i].name.Contains("axe_wooden"))
            {
                return treeHealth - 1f;
                
            } else
            {
                return 0f;
            }
        }
        return 0;
    }

    







}

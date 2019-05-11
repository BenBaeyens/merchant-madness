using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour {

    public float treeHealth;

    bool hasPickaxe = false;

    public GameObject treeRange;
    public GameObject player;
    public Player pl;

    private void Start() {
        player = GameObject.Find("Player");
        pl = player.GetComponent<Player>();
    }

    private void Update() {


        if (!hasPickaxe) {
            for (int i = 0; i < pl.inventory.Count; i++)
            {
                if (pl.inventory[i].Contains("axe"))
                {
                    hasPickaxe = true;
                    break;
                }
            }
        }

        if (treeRange.GetComponent<TreeHitboxScript>().isPlayerInRange
            && hasPickaxe
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
                    pl.inventory.Add("wooden_log");
                }
            }
        }


        if(treeHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    float TreeDamage() {
        if (pl.inventory.Contains("axe_wooden"))
            return treeHealth - 1f;
        else
            return 0f;
    }

    







}

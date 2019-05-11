using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour {

    public float rockHealth;

    bool hasPickaxe = false;

    public GameObject rockRange;
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
                if (pl.inventory[i].Contains("pickaxe"))
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
                    rockHealth = TreeDamage();
                    pl.inventory.Add("stone_chunk");
                }
            }
        }


        if(rockHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    float TreeDamage() {
        if (pl.inventory.Contains("pickaxe_wooden"))
            return rockHealth - 1f;
        else
            return 0f;
    }

    







}

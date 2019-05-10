using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    Player player;
    public ItemScriptableObject key;

    bool isPlayerInRange;

    [Header("Assign Next Platform (If needed)")]
    public GameObject nextPlatform;

    GameObject gateClickText;

    private void Start() {
        player = FindObjectOfType<Player>();

        GameObject[] tempobjects = Resources.FindObjectsOfTypeAll<GameObject>();
        for (int i = 0; i < tempobjects.Length; i++)
        {
            if (tempobjects[i].name == "GateClickText")
            {
                gateClickText = tempobjects[i];
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        isPlayerInRange = true;
        if(player.inventory.Contains(key.itemCodeName))
            gateClickText.SetActive(true);
    }
    private void OnTriggerExit(Collider other) {
        isPlayerInRange = false;
        gateClickText.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && isPlayerInRange && player.inventory.Contains(key.itemCodeName))
        {
            player.inventory.Remove("key_1");
            gameObject.SetActive(false);
            nextPlatform.SetActive(true);
            gateClickText.SetActive(false);
        }
    }
}

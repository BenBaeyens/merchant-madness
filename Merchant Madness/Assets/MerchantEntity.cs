using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantEntity : MonoBehaviour
{

    GameObject clickText;
    MerchantPrefab mp;

    [HideInInspector]
    public bool isPlayerInRange;

    void Start()
    {
        mp = GameObject.Find(gameObject.name).GetComponent<MerchantPrefab>();

        GameObject[] tempobjects = Resources.FindObjectsOfTypeAll<GameObject>();
        for (int i = 0; i < tempobjects.Length; i++)
        {
            if (tempobjects[i].name == "ClickText")
            {
                clickText = tempobjects[i];
                break;
            }
        }
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        isPlayerInRange = true;
        clickText.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other) {
        isPlayerInRange = false;
        clickText.gameObject.SetActive(false);
    }

}

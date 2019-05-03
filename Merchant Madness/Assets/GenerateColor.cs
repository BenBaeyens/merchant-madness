using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateColor : MonoBehaviour
{
    GameObject merchant;

    public Color32 greencolor1 = new Color32(0, 10, 0, 255);
    public Color32 greencolor2 = new Color32(0, 255, 0, 255);

    private void Start() {
        merchant = GameObject.Find(gameObject.name);

        float rand = Random.Range(0f, 1f);

        merchant.GetComponent<Renderer>().material.color = Color.Lerp(greencolor1, greencolor2, rand);



    }
}

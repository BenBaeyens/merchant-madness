using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GenerateColor : MonoBehaviour
{
    GameObject merchant;

    public List<Color32> greencolors;
    public List<Color32> redcolors;
    public List<Color32> bluecolors;
    public List<Color32> yellowcolors;
    public List<Color32> greycolors;

    public Material merchantDefault;

    int color;




    public void Start() {
        Material[] tempm = Resources.FindObjectsOfTypeAll<Material>();
        foreach (Material m in tempm)
        {
            if (m.name == "MerchantDefault")
            {
                merchantDefault = m;
                break;
            }
        }

        greycolors = new List<Color32>
        {
            new Color32(200, 200, 200, 255),
            new Color32(100, 100, 100, 255)
        };

        greencolors = new List<Color32>
        {
            new Color32(0, 90, 0, 255),
            new Color32(0, 255, 0, 255)
        };

        redcolors = new List<Color32>
        {
            new Color32(90, 0, 0, 255),
            new Color32(255, 0, 0, 255)
        };

        bluecolors = new List<Color32>
        {
            new Color32(0, 0, 90, 255),
            new Color32(0, 0, 255, 255)
        };

        yellowcolors = new List<Color32>
        {
            new Color32(255,239,213, 255),
            new Color32(255,255,0,255)
        };

        merchant = GameObject.Find(gameObject.name + "Entity");

        GenerateRandomColor();

    }

    public void GenerateRandomColor() {
        float colorval = Random.Range(0f, 1f);
        

        if (gameObject.GetComponent<MerchantPrefab>() != null)
        {
            if (gameObject.GetComponent<MerchantPrefab>().merchant.color == 0 || gameObject.GetComponent<MerchantPrefab>().merchant.color > 5)
            {
                color = Random.Range(1, 6);
            } else
            {
                color = gameObject.GetComponent<MerchantPrefab>().merchant.color;
            }
        } else if (gameObject.GetComponent<SalesmanPrefab>() != null)
        {
            if (gameObject.GetComponent<SalesmanPrefab>().salesman.color == 0)
            {
                color = Random.Range(1, 5);
            } else
            {
                color = gameObject.GetComponent<SalesmanPrefab>().salesman.color;
            }
        }

        if (color == 1)
            merchant.GetComponent<Renderer>().material.color = Color.Lerp(greencolors[0], greencolors[1], colorval);
        if (color == 2)
            merchant.GetComponent<Renderer>().material.color = Color.Lerp(redcolors[0], redcolors[1], colorval);
        if (color == 3)
            merchant.GetComponent<Renderer>().material.color = Color.Lerp(bluecolors[0], bluecolors[1], colorval);
        if (color == 4)
            merchant.GetComponent<Renderer>().material.color = Color.Lerp(yellowcolors[0], yellowcolors[1], colorval);
        if (color == 5)
            merchant.GetComponent<Renderer>().material.color = Color.Lerp(greycolors[0], greycolors[1], colorval);
    }

    public void ResetColor() {
        Material[] tempm = Resources.FindObjectsOfTypeAll<Material>();
        foreach (Material m in tempm)
        {
            if (m.name == "MerchantDefault")
            {
                merchantDefault = m;
                break;
            }
        } 
        merchant.GetComponent<Renderer>().material = merchantDefault;
    }
}


[CustomEditor(typeof(GenerateColor))]
public class ColorInspector : Editor {

    public GenerateColor gc;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        GenerateColor gc = (GenerateColor)target;

        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Generate Color"))
        {
            gc.Start();
        }

        if(GUILayout.Button("Reset Default Color"))
        {
            gc.ResetColor();
        }
        GUILayout.EndHorizontal();
    }

}
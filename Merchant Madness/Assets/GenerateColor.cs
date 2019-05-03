using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GenerateColor : MonoBehaviour
{
    GameObject merchant;

    public List<Color32> greencolors;
    public List<Color32> redcolors;

    


    public void Start() {
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

        merchant = GameObject.Find(gameObject.name);

        GenerateRandomColor();

    }

    public void GenerateRandomColor() {
        float colorval = Random.Range(0f, 1f);
        int color = Random.Range(0, 2);

        Debug.Log(color);

        if (color == 0)
            merchant.GetComponent<Renderer>().material.color = Color.Lerp(greencolors[0], greencolors[1], colorval);
        if (color == 1)
            merchant.GetComponent<Renderer>().material.color = Color.Lerp(redcolors[0], redcolors[1], colorval);
    }
}


[CustomEditor(typeof(GenerateColor))]
public class ColorInspector : Editor {

    public GenerateColor gc;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        GenerateColor gc = (GenerateColor)target;

        if(GUILayout.Button("Generate Color"))
        {
            gc.Start();
        }
    }

}
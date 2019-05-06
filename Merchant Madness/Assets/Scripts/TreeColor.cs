using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeColor : MonoBehaviour
{

    public List<Color> TreeLog1Type;
    List<Color> TreeLog2Type;
    List <Color> TreeLeaves1Type;
    List <Color> TreeLeaves2Type;

    int treeType;

    private void Start() {
        
        ChangeColor();

        TreeLog1Type = new List<Color>();
        TreeLog2Type = new List<Color>();
        TreeLeaves1Type = new List<Color>();
        TreeLeaves2Type = new List<Color>();
    }

    public void ChooseTree() {
        // 1 = birch
        // 2 = pine
        // 3 = pink

        treeType = Random.Range(0, 2);
        Debug.Log(treeType);
    }

    public void ChangeColor() {

        Material[] colors = Resources.FindObjectsOfTypeAll<Material>();
        for (int i = 0; i < colors.Length; i++)
        {
            if (colors[i].name == "TreeLog1Type1")
                TreeLog1Type.Add(colors[i].color);

            Debug.Log("test");
            if (colors[i].name == "TreeLog1Type" + i)
                TreeLog1Type.Add(colors[i].color);
            if (colors[i].name == "TreeLog2Type" + i)
                TreeLog2Type.Add(colors[i].color);
            if (colors[i].name == "TreeLeaves1Type" + i)
                TreeLeaves1Type.Add(colors[i].color);
            if (colors[i].name == "TreeLeaves2Type" + i)
                TreeLeaves2Type.Add(colors[i].color);
            else
                Debug.Log(":(");

        }

        ChooseTree();

        transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = Color.Lerp(TreeLog1Type[1], TreeLog2Type[1], Random.Range(0f, 1f));
        Transform leaveParent = gameObject.transform.Find("Leaves");

        for (int i = 0; i < leaveParent.childCount; i++)
        {
            leaveParent.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.Lerp(TreeLeaves1Type[treeType], TreeLog2Type[treeType], Random.Range(0f, 1f));
        }
    }
}

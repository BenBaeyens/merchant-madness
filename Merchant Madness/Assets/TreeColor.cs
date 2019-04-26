using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeColor : MonoBehaviour
{

    Color TreeType1Log1;
    Color TreeType1Log2;
    Color TreeType1Leaves1;
    Color TreeType1Leaves2;

    Color TreeType2Log1;
    Color TreeType2Log2;
    Color TreeType2Leaves1;
    Color TreeType2Leaves2;

    Color TreeType3Log1;
    Color TreeType3Log2;
    Color TreeType3Leaves1;
    Color TreeType3Leaves2;

    int treeType;

    private void Start() {
        
        ChangeColor();
    }

    public void ChooseTree() {
        // 1 = birch
        // 2 = pine
        // 3 = pink

        treeType = Random.Range(1, 3);
    }

    public void ChangeColor() {

        Material[] colors = Resources.FindObjectsOfTypeAll<Material>();
        for (int i = 0; i < colors.Length; i++)
        {
            if (colors[i].name == "TreeType1Log1")
                TreeType1Log1 = colors[i].color;
            if (colors[i].name == "TreeType1Log2")
                TreeType1Log2 = colors[i].color;
            if (colors[i].name == "TreeType1Leaves1")
                TreeType1Leaves1 = colors[i].color;
            if (colors[i].name == "TreeType1Leaves2")
                TreeType1Leaves2 = colors[i].color;

            if (colors[i].name == "TreeType2Log1")
                TreeType2Log1 = colors[i].color;
            if (colors[i].name == "TreeType2Log1")
                TreeType2Log2 = colors[i].color;
            if (colors[i].name == "TreeType2Leaves1")
                TreeType2Leaves1 = colors[i].color;
            if (colors[i].name == "TreeType2Leaves2")
                TreeType2Leaves2 = colors[i].color;

            if (colors[i].name == "TreeType3Log1")
                TreeType3Log1 = colors[i].color;
            if (colors[i].name == "TreeType3Log1")
                TreeType3Log2 = colors[i].color;
            if (colors[i].name == "TreeType3Leaves1")
                TreeType3Leaves1 = colors[i].color;
            if (colors[i].name == "TreeType3Leaves2")
                TreeType3Leaves2 = colors[i].color;
        }

        ChooseTree();

        transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = Color.Lerp(("TreeType"+treeType+"Log1").color, BranchColor2.color, Random.Range(0f, 1f));
        Transform leaveParent = gameObject.transform.Find("Leaves");

        for (int i = 0; i < leaveParent.childCount; i++)
        {
            leaveParent.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.Lerp(LeavesColor1.color, LeavesColor2.color, Random.Range(0f, 1f));
        }
    }
}

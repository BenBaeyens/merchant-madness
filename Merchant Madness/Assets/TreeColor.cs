using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeColor : MonoBehaviour
{
    [SerializeField] Material BranchColor1;
    [SerializeField] Material BranchColor2;
    [SerializeField] Material LeavesColor1;
    [SerializeField] Material LeavesColor2;
    [SerializeField] GameObject branch;

    private void Start() {
        ChangeColor();
    }
    public void ChangeColor() {
        transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = Color.Lerp(BranchColor1.color, BranchColor2.color, Random.Range(0f, 1f));
        Transform leaveParent = gameObject.transform.Find("Leaves");

        for (int i = 0; i < leaveParent.childCount; i++)
        {
            leaveParent.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Color.Lerp(LeavesColor1.color, LeavesColor2.color, Random.Range(0f, 1f));
        }
    }
}

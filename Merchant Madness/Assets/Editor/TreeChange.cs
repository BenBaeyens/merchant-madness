using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TreeColor))]
public class TreeChange : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        TreeColor treeObject = (TreeColor)target;

        if (GUILayout.Button("Change Color"))
        {
            treeObject.ChangeColor();
        }
    }
}

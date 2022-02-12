using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SplineGenerator))]
public class GeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SplineGenerator myScript = (SplineGenerator)target;
        if (GUILayout.Button("Generate"))
        {
            myScript.Generate();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseAirplaneInput))]
public class BaseAirplaneInputEditor : Editor
{
    #region Variables
    private BaseAirplaneInput targetInput;
    #endregion

    #region Methods
    private void OnEnable()
    {
        targetInput = (BaseAirplaneInput)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        string debugInfo = "";
        debugInfo += "Pitch " + targetInput.Pitch + "\n";
        debugInfo += "Roll " + targetInput.Roll + "\n";
        debugInfo += "Yaw " + targetInput.Yaw + "\n";
        debugInfo += "Throttle " + targetInput.Throttle + "\n";
        debugInfo += "Flaps " + targetInput.Flaps + "\n";
        debugInfo += "Brake " + targetInput.Brake + "\n";

        //Custom editor
        EditorGUILayout.Space();
        EditorGUILayout.TextArea(debugInfo, GUILayout.Height(200));
        EditorGUILayout.Space();
    }
    #endregion
}

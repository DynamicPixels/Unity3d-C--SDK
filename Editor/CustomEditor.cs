using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomEditor : EditorWindow
{
    private string ClientID = "";
    private string ClientSecret = "";

    [MenuItem("MyMenu/Open Panel")]
    private static void OpenPanel()
    {
        CustomEditorPan window = GetWindow<CustomEditorPan>();
        window.titleContent = new GUIContent("Custom Panel");
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Enter ClientID:");
        ClientID = EditorGUILayout.TextField(ClientID);

        GUILayout.Label("Enter ClientSecret:");
        ClientSecret = EditorGUILayout.PasswordField(ClientSecret);

        if (GUILayout.Button("OK"))
        {
            CreateEmptyGameObject();
            Close();
        }
    }

    private void CreateEmptyGameObject()
    {
        GameObject emptyObject = new GameObject("SDKHandler");
        emptyObject.AddComponent<DynamicPixelsInitializer.DynamicPixelsInitializer>();
        emptyObject.GetComponent<DynamicPixelsInitializer.DynamicPixelsInitializer>().clientId = ClientID;
        emptyObject.GetComponent<DynamicPixelsInitializer.DynamicPixelsInitializer>().clientSecret = ClientSecret;
        Undo.RegisterCreatedObjectUndo(emptyObject, "Create Empty Object");
        Selection.activeGameObject = emptyObject;
    }
}
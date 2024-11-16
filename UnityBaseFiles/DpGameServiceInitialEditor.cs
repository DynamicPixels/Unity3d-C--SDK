using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR
public class DpGameServiceInitialEditor : UnityEditor.EditorWindow
{
    private string ClientID = "";
    private string ClientSecret = "";
    private bool developmentMode;
    private bool debugMode = false;
    private bool verboseMode = false;
    private const string PackageFirstTimeKey = "PackageFirstTimeOpenedCounter";
    public Texture2D logoTexture;


    [InitializeOnLoadMethod]
    private static void MyInit()
    {
        if (!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode)
        {
            // Check if the package has been opened before
            if (!EditorPrefs.HasKey(PackageFirstTimeKey))
            {
                // The package is being opened for the first time
                OpenPanel();

                // Set a flag to indicate that the package has been opened
                EditorPrefs.SetBool(PackageFirstTimeKey, true);
            }
        }
    }






    [MenuItem("dynamicpixels/Config")]
    private static void OpenPanel()
    {
        DpGameServiceInitialEditor window = GetWindow<DpGameServiceInitialEditor>();
        window.titleContent = new GUIContent("Custom Panel");
        window.Show();
        PlayerPrefs.SetInt("MyPackageInstalled", 1);

    }




    private void OnGUI()
    {
        if (logoTexture != null)
        {
            GUILayout.Label(new GUIContent(logoTexture));
        }

        GUILayout.Label("Enter ClientID:");
        ClientID = EditorGUILayout.TextField(ClientID);

        GUILayout.Label("Enter ClientSecret:");
        ClientSecret = EditorGUILayout.PasswordField(ClientSecret);
        developmentMode = EditorGUILayout.Toggle("Development Mode", developmentMode);
        debugMode = EditorGUILayout.Toggle("Debug Mode", debugMode);
        verboseMode = EditorGUILayout.Toggle("Verbose Mode", verboseMode);

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
        emptyObject.GetComponent<DynamicPixelsInitializer.DynamicPixelsInitializer>().developmentMode = developmentMode;
        emptyObject.GetComponent<DynamicPixelsInitializer.DynamicPixelsInitializer>().debugMode = debugMode;
        emptyObject.GetComponent<DynamicPixelsInitializer.DynamicPixelsInitializer>().verboseMode = verboseMode;
        Undo.RegisterCreatedObjectUndo(emptyObject, "Create Empty Object");
        Selection.activeGameObject = emptyObject;
    }

}
#endif

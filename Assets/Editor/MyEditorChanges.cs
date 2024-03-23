using System.IO;
using UnityEditor;
using UnityEngine;

public class MyEditorChanges : EditorWindow
{
    [MenuItem("Tools/MyEditorChanges")]
    public static void ShowWindow()
    {
        GetWindow<MyEditorChanges>("My Editor Changes");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Delete Json File"))
        {
            string filePath = Path.Combine(Application.dataPath, "LastPlayedLevel.json");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }   
            else
            {
                Debug.LogError("LastPlayedLevel.json file not found!");
            }
        }
    }
}
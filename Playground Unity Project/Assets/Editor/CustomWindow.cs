using UnityEngine;
using UnityEditor;

public class CustomWindow : EditorWindow
{
    [MenuItem("Window/CustomWindow")]
    public static void ShowWindow()
    {
        GetWindow<CustomWindow>();
    }

    void OnGUI()
    {
        GUILayout.Label("Select all objects with tag 'ParticleSystem'.");

        if (GUILayout.Button("Select PS objects"))
        {
            SelectAllObjectsWithTag("ParticleSystem");
        }
    }

    void AddToScene()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            //Create a room
            //Create a gameObject in the room
        }
    }

    void SelectChildObjects()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            //Select the child objects
        }
    }

    void OpenPrefabWindow()
    {
        if (Selection.gameObjects.Length == 1)
        {
            //Open its prefab window
        }
        else
        {
            Debug.Log("Multiple gameObjects are selected. Please select one");
        }
    }

    void OverridePrefab()
    {

    }

    void SelectAllObjectsWithTag(string _tag)
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(_tag);
        Selection.objects = objs;
    }
}

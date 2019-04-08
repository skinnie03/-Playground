using UnityEngine;
using UnityEditor;

public class CustomWindow : EditorWindow
{
    public int numberOfPrefabs = 3;
    public GameObject[] myPrefabs;

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

        //Prefab
        numberOfPrefabs = EditorGUILayout.IntField("Number of Prefabs", numberOfPrefabs);

        if (GUILayout.Button("Change the number of prefabs"))
        {
            myPrefabs = new GameObject[numberOfPrefabs];

            for (int i = 0; i < numberOfPrefabs; i++)
            {
                myPrefabs[i] = (GameObject)EditorGUILayout.ObjectField(myPrefabs[i], typeof(GameObject), false);
            }

            Debug.Log(myPrefabs.Length);
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

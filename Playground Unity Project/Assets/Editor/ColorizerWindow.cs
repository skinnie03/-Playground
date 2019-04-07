using UnityEngine;
using UnityEditor;

public class ColorizerWindow : EditorWindow {

    Color color;

    [MenuItem("Window/Colorizer")]
    public static void ShowWindow()
    {
        GetWindow<ColorizerWindow>("Colorizer");
    }

    void OnGUI()
    {
        GUILayout.Label("Color the selected object!.", EditorStyles.boldLabel);

        color = EditorGUILayout.ColorField("Color", color);

        if (GUILayout.Button("Colorize"))
        {
            Colorize();
        }
    }

    void Colorize()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }
}

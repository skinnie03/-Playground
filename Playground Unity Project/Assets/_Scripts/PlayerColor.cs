using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class PlayerColor : MonoBehaviour
{
    public GameSetup gameSetup;
    public Material[] allMaterials;
    private Renderer myRenderer;
    private int materialIndex = 0;

    void Start()
    {
        allMaterials = gameSetup._allMaterials;
        myRenderer = GetComponent<Renderer>();
        myRenderer.material = allMaterials[materialIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            materialIndex += 1;

            if (materialIndex >= allMaterials.Length)
            {
                materialIndex = 0;
            }
            myRenderer.material = allMaterials[materialIndex];
        }
    }
}

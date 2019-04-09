using System.Collections;
using UnityEngine;

public abstract class Ability : ScriptableObject {

    public new string name = "New Ability";
    public string description;

    public GameObject prefab;
    public Sprite artwork;
    public AudioClip sound; 

    public float damage;
    public float range;
    public float coolDown = 1f;
    public float castTime;

    /*
    public string targetingType;
    public string unitType;
    public string effectType;
    public string abilityType;
    */


    public abstract void Initialize(GameObject obj);
    public abstract void TriggerAbility();
}

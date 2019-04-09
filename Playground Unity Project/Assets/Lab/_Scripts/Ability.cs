using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability")]
public class Ability : ScriptableObject {

    public new string name;
    public string description;

    public GameObject prefab;
    public Sprite artwork;

    public float damage;
    public float coolDown;
    public float castTime;

    public string targetingType;
    public string unitType;
    public string effectType;
    public string abilityType;
    

    public void CastAbility()
    {

    }
}

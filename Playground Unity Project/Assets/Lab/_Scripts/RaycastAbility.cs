using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New RaycastAbility", menuName = "Ability/RaycastAbility")]
public class RaycastAbility : Ability {

    public float gunDamage = 1f;
    public float weaponRange = 50f;
    public float hitForce = 100f;
    public Color laserColor = Color.white;

    private RayCastShootTriggerable rcShoot;

    public override void Initialize(GameObject obj)
    {
        rcShoot = obj.GetComponent<RayCastShootTriggerable>();
        //rcShoot.Initi
    }

    public override void TriggerAbility()
    {
        throw new System.NotImplementedException();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastAbility : MonoBehaviour
{
    public Ability ability;
    public Transform firepoint;

    private float coolDownTimer;
    private float castTimeTimer;

    private void Start()
    {
        
    }

    /*
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PerformCastAbility();
        }

        if (coolDownTimer > 0) { coolDownTimer -= Time.deltaTime; }
        if (castTimeTimer > 0) { castTimeTimer -= Time.deltaTime; }
    }

    public void PerformCastAbility()
    {
        if (coolDownTimer <= 0)
        {
            coolDownTimer = ability.coolDown;
            castTimeTimer = ability.castTime;
            Instantiate(ability.prefab, firepoint.position, firepoint.rotation);
        }
    }
    */
}

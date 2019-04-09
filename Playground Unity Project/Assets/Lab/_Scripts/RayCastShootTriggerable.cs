using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShootTriggerable : MonoBehaviour
{
    [HideInInspector] public float gunDamage = 1f;
    [HideInInspector] public float weaponRange = 1f;
    [HideInInspector] public float hitForce = 1f;
    public Transform firepoint;
    [HideInInspector] public LineRenderer laserLine;


    private Camera fpsCam;

    public void Initialize()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    public void Fire()
    {
        //Create a vector at the center of our camera's near clip plane
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));

        //Draw a debug line which will show where our ray will eventually be
        Debug.DrawRay(rayOrigin, fpsCam.transform.forward * weaponRange, Color.green);

        //Declare a raycast hit to store information about what our raycast has hit.
        RaycastHit hit;

        //Start our ShotEffect coroutine to turn our laser line on and off

        ///        StartCoroutine(ShotEffect());


        //Set the start position for our visual effect for our laser to the position of gunEnd
        laserLine.SetPosition(0, firepoint.position);

        //Check if our raycast has hit anything
        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
        {
            //Set the end position for our laser line
            laserLine.SetPosition(1, hit.point);

            
        }

    }
}

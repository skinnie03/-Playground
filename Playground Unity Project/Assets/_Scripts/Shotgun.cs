using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public GameObject bullet;
    public Transform firepoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Shotgun shooting");
            ShootMultipleProjectiles();
        }
    }




    public void ShootMultipleProjectiles()
    {
        Vector3 rotVector = firepoint.rotation.eulerAngles;
        Debug.Log(rotVector);
        
        Instantiate(bullet, firepoint.position, firepoint.rotation);

        rotVector.y += 15f;
        Debug.Log(rotVector);
        Instantiate(bullet, firepoint.position, Quaternion.Euler(rotVector));

        rotVector.y -= 30f;
        Debug.Log(rotVector);
        Instantiate(bullet, firepoint.position, Quaternion.Euler(rotVector));
    }
}

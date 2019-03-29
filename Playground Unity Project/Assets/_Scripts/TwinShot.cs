using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwinShot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firepoint;
    public Animator animator;
    public Image iconCDMask;

    [SerializeField] private float startUp = 0.2f;
    [SerializeField] private float secondShot = 0.2f;
    [SerializeField] private float coolDown = 1f;
    private float coolDownTimer = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && coolDownTimer <= 0)
        {
            Debug.Log("Twin Shot!");
            CastTwinShot();
        }

        //control CD
        if (coolDownTimer > 0) { coolDownTimer -= Time.deltaTime; }

        //control icon CD mask
        iconCDMask.fillAmount = coolDownTimer / coolDown;
    }

    public void CastTwinShot()
    {
        Invoke("Shoot", startUp);
        Invoke("Shoot", secondShot);
        animator.SetTrigger("attackTrigger");
        coolDownTimer = coolDown;
    }

    public void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
}

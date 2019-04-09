using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider _other)
    {
        Debug.Log(_other.name);
        if (_other.CompareTag("Platform"))
        {
            _other.GetComponent<MovingPlatform>().Flip();

        }
    }
}

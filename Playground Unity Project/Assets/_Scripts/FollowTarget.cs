using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform targetTransform;

    private void Update()
    {
        transform.position = targetTransform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [Header("要跟隨的物件")]
    public Transform target;
    [Header("位移")]
    public float y = -3;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.position;
        targetPos.y += y;
        transform.position = targetPos;
    }
}

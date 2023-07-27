using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;
    public float yvalue;
    public float zvalue;
    public bool move = true;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        if (move)
        {
            Vector3 movePosition = new Vector3(target.position.x + offset.x, yvalue, zvalue);
            transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
        }
    }
}

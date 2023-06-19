using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float interpVelocity;
    public GameObject target;
    public Vector3 offset;
    private Vector3 targetPos;
    public float interpSpeed;

    private void Start()
    {
        transform.position = target.transform.position;
        targetPos = transform.position;
    }

    private void FixedUpdate()
    {
        if(target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);
            interpVelocity = targetDirection.magnitude * interpSpeed;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        }
    }
}

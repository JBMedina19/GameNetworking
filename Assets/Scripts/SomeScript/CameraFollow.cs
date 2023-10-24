using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public float smoothSpeed;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPos = Target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothPos;
    }
}

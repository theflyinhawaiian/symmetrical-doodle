using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Func<Vector3> GetCameraTarget;

    public void Setup(Func<Vector3> getCameraTarget)
    {
        GetCameraTarget = getCameraTarget;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraTarget = GetCameraTarget();
        cameraTarget.z = -10;
        Vector3 direction = (cameraTarget - transform.position).normalized;
        float distance = Vector3.Distance(cameraTarget, transform.position);
        float followSpeed = 2f;

        transform.position = transform.position + direction * distance * followSpeed * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField][Range(0, 90)] private float cameraPitch = 40;
    [SerializeField][Range(0, 90)] private float cameraYaw = 0;
    [SerializeField][Range(2, 10)] private float cameraDistance = 5;
    [SerializeField][Range(0f, 10f)] private float sensitivity = 1;
    // Update is called once per frame
    void Update()
    {
        cameraYaw += Input.GetAxis("Mouse X") * sensitivity;

        Quaternion qyaw = Quaternion.AngleAxis(cameraYaw, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(cameraPitch, Vector3.right);
        Quaternion rotation = qyaw * qpitch;

        transform.position = target.position + (rotation * Vector3.back * cameraDistance);
        transform.rotation = rotation;
    }
}

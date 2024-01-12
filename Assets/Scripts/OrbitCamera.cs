using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField][Range(0, 90)] private float defaultPitch = 40;
    [SerializeField][Range(0, 90)] private float cameraYaw = 0;
    [SerializeField][Range(2, 10)] private float cameraDistance = 5;
    [SerializeField][Range(0f, 10f)] private float sensitivity = 1;

    float pitch = 0;

    private void Start()
    {
        pitch = defaultPitch;
    }
    // Update is called once per frame
    void Update()
    {
        cameraYaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch += Input.GetAxis("Mouse X") * sensitivity;

        Quaternion qyaw = Quaternion.AngleAxis(cameraYaw, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right);
        Quaternion rotation = qyaw * qpitch;

        transform.position = target.position + (rotation * Vector3.back * cameraDistance);
        transform.rotation = rotation;
    }
}

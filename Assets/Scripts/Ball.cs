using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Movement")]
    [SerializeField][Range(1, 20)][Tooltip("force to move object")] private float force;

    public Rigidbody rb;

    private void Awake()
    {

    }

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            GetComponent<Rigidbody>().AddForce(transform.up * force, ForceMode.VelocityChange);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _2xScore : MonoBehaviour
{
    [SerializeField] Event _2xEvent = default;
    private void OnTriggerEnter(Collider other)
    {
        _2xEvent.RaiseEvent();
    }
}
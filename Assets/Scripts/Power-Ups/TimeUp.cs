using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUp : MonoBehaviour
{
    [SerializeField] Event timeUpEvent = default;
    private void OnTriggerEnter(Collider other)
    {
        timeUpEvent.RaiseEvent();
        PowerUpManager.Destroy(gameObject);
        FindObjectOfType<AudioManager>().Play("Power-UP");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] GameObject pickupPreFab = null;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.AddPoints(10);
        }

        Instantiate(pickupPreFab, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.0f);
    }
}

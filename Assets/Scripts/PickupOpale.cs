using System;
using UnityEngine;

public class PickupOpale : MonoBehaviour
{
    private Inventory _inventory;
    
    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _inventory.AddOpals(1);
            Destroy(gameObject);
        }
    }
}

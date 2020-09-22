using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _isPlayerInZone;
    private bool _isOpen;
    private Animator _animator;
    private Inventory _inventory;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInZone = false;
        }
    }

    private void Update()
    {
        if (_isPlayerInZone && !_isOpen && Input.GetButtonDown("Open Door"))
        {
            if (_inventory.UseKey())
            {
                _isOpen = true;
                _animator.SetTrigger("Open");
            }
        }
    }
}

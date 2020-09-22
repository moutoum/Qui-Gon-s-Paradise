using UnityEngine;

public class Tentacle : MonoBehaviour
{
    public int damages;
    
    private Animator _animator;
    private Collider2D _collider;
    private bool _spawned = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;
    }

    public void Spawn()
    {
        if (!_spawned)
        {
            _animator.SetTrigger("Spawn");
            _collider.enabled = true;
            _spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Health>().TakeDamages(damages);
        }
    }
}

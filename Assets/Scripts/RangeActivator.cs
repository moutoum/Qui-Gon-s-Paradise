using UnityEngine;
using UnityEngine.Events;

public class RangeActivator : MonoBehaviour
{
    public UnityEvent onPlayerEnter;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onPlayerEnter?.Invoke();
        }
    }
}

using UnityEngine;

public class Portal : MonoBehaviour
{
    private static Portal _portalA;
    private static Portal _portalB;

    private bool _isDestination;
    private Transform _player;
    
    private void Awake()
    {
        // If no portal yet, set portal A.
        if (_portalA == null)
        {
            _portalA = this;
        }
        // If there is a first portal and not linked to an other one.
        else if (_portalB == null)
        {
            _portalB = this;
        }
        // If 2 portals already exist, swap B with A, and set A to the new one.
        else
        {
            Destroy(_portalA.gameObject);
            _portalA = _portalB;
            _portalB = this;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _player = null;
        }
    }

    private void Update()
    {
        if (_player && Input.GetButtonDown("Enter Portal"))
        {
            if (this == _portalA && _portalB != null)
            {
                TeleportTo(_portalB.transform.position);
            }

            if (this == _portalB && _portalA != null)
            {
                TeleportTo(_portalA.transform.position);
            }
        }
    }

    private void TeleportTo(Vector3 position)
    {
        _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _player.position = position;
    }
}

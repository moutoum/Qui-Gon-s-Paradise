using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private Transform _player;
    private Transform _spawn;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var rb = _player.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        _player.position = _spawn.position;
    }

    private void OnDrawGizmos()
    {
        var collider = GetComponent<BoxCollider2D>();
        Gizmos.color = new Color(1f, 0f, 0f, .3f);
        var center = transform.position + new Vector3(collider.offset.x, collider.offset.y);
        Gizmos.DrawCube(center, collider.size);
    }
}

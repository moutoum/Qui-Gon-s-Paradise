using UnityEngine;

public class Spell : MonoBehaviour
{
    public float speed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody.velocity = new Vector2(speed, 0);
        if (speed < 0)
        {
            var localScale = transform.localScale;
            transform.localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
        if (other.CompareTag("Plateform"))
        {
            Destroy(gameObject);
        }
    }
}

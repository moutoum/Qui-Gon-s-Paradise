using UnityEngine;

namespace Collect
{
    public class Collectible : MonoBehaviour
    {
        private ICollector _collector;

        private void Awake()
        {
            _collector = GetComponent<ICollector>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _collector.Pickup();
                Destroy(gameObject);
            }
        }
    }
}

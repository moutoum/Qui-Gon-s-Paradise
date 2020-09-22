using UnityEngine;

namespace Collect
{
    [RequireComponent(typeof(Collectible))]
    public class KeyCollector : MonoBehaviour, ICollector
    {
        private Inventory _inventory;
    
        private void Start()
        {
            _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        }
        
        public void Pickup()
        {
            _inventory.AddKey();
        }
    }
}
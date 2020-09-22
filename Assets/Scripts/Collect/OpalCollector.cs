using UnityEngine;

namespace Collect
{
    [RequireComponent(typeof(Collectible))]
    public class OpalCollector : MonoBehaviour, ICollector
    {
        public int opalsPerPick = 1;
        private Inventory _inventory;
    
        private void Start()
        {
            _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        }
        
        public void Pickup()
        {
            _inventory.AddOpals(opalsPerPick);
        }
    }
}
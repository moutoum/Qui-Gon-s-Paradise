using UnityEngine;

namespace Collect
{
    [RequireComponent(typeof(Collectible))]
    public class SapphireCollector : MonoBehaviour, ICollector
    {
        public int sapphiresPerPick = 1;
        private Inventory _inventory;
    
        private void Start()
        {
            _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        }
        
        public void Pickup()
        {
            _inventory.AddSapphires(sapphiresPerPick);
        }
    }
}
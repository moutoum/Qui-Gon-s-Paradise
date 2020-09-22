using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private GameObject portalPrefab;
    [SerializeField] private Spell spellPrefab;
    
    private Inventory _inventory;
    private Transform _spawn;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        _spawn = GameObject.FindGameObjectWithTag("Spawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Use Opal"))
        {
            if (_inventory.UseOpal())
            {
                _spawn.position = transform.position;
            }
        }
 
        if (Input.GetButtonDown("Create Portal"))
        {
            if (_inventory.UseSapphire())
            {
                Instantiate(portalPrefab, transform.position, Quaternion.identity);
            }
        }

        if (Input.GetButtonDown("Attack"))
        {
            _animator.SetTrigger("Attack");
        }
    }

    // Method called by the animation.
    public void Attack()
    {
        Instantiate(spellPrefab, transform.position, Quaternion.identity);
    }
}

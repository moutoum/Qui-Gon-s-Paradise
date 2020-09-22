using UnityEngine;
using UnityEngine.UI;

public class SapphiresText : MonoBehaviour
{
    private Text _text;
    private Inventory _inventory;

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    private void Update()
    {
        _text.text = _inventory.sapphires.ToString();
    }
}

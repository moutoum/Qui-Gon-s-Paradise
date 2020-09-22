using UnityEngine;

public class Parallax : MonoBehaviour
{
    public bool infinite = true;
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    
    private Transform _camera;
    private Vector3 _lastCameraPosition;
    private float _textureUnitSizeX;

    private void Awake()
    {
        _camera = Camera.main.transform;
        _lastCameraPosition = _camera.transform.position;
        var sprite = GetComponent<SpriteRenderer>().sprite;
        _textureUnitSizeX = sprite.texture.width / sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        var deltaMovement = _camera.position - _lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y, 0);
        _lastCameraPosition = _camera.position;

        if (infinite && Mathf.Abs(_camera.position.x - transform.position.x) >= _textureUnitSizeX)
        {
            var offsetPositionX = (_camera.position.x - transform.position.x) % _textureUnitSizeX;
            transform.position = new Vector3(_camera.position.x + offsetPositionX, transform.position.y);
        }
    }
}

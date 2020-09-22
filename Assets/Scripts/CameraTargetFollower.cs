using UnityEngine;

public class CameraTargetFollower : MonoBehaviour
{
    public Vector3 offset;
    public float timeBeforeMoving;
    
    private Transform _target;
    private Vector3 _velocity = Vector3.zero;

    private void Awake()
    {
        _target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position =
            Vector3.SmoothDamp(transform.position, _target.position + offset, ref _velocity, timeBeforeMoving);
    }
}

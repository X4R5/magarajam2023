using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class OneWayBoxCollider : MonoBehaviour
{
    [SerializeField]
    private Vector3 _entryDirection = Vector3.up;
    [SerializeField]
    private bool _localDirection = false;
    [SerializeField]
    private Vector3 _triggerScale = Vector3.one * 1.25f;
    [SerializeField]
    private float _penetrationDepthThreshold = 0.2f;
    private new BoxCollider _collider = null;
    private BoxCollider _collisionCheckTrigger = null;

    public Vector3 PassthroughDirection => _localDirection ? transform.TransformDirection(_entryDirection.normalized) : _entryDirection.normalized;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();

        _collisionCheckTrigger = gameObject.AddComponent<BoxCollider>();
        _collisionCheckTrigger.size = new Vector3(
            _collider.size.x * _triggerScale.x,
            _collider.size.y * _triggerScale.y,
            _collider.size.z * _triggerScale.z
        );
        _collisionCheckTrigger.center = _collider.center;
        _collisionCheckTrigger.isTrigger = true;
    }

    private void OnValidate()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.isTrigger = false;
    }

    private void OnTriggerStay(Collider other)
    {
        TryIgnoreCollision(other);
    }

    public void TryIgnoreCollision(Collider other)
    {
        if (Physics.ComputePenetration(
            _collisionCheckTrigger, _collisionCheckTrigger.bounds.center, transform.rotation,
            other, other.bounds.center, other.transform.rotation,
            out Vector3 collisionDirection, out float penetrationDepth))
        {
            float dot = Vector3.Dot(PassthroughDirection, collisionDirection);

            if (dot < 0)
            {
                if (penetrationDepth < _penetrationDepthThreshold)
                {
                    Physics.IgnoreCollision(_collider, other, false);
                }
            }
            else
            {
                Physics.IgnoreCollision(_collider, other, true);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.TransformPoint(_collider.center), PassthroughDirection * 2);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.TransformPoint(_collider.center), -PassthroughDirection * 2);
    }
}

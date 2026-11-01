using UnityEngine;

/// <summary>
/// Puts a grabbable prop back at its start position when it falls out of the world,
/// or when ResetToStart() is called (e.g. from a "Reset Props" button).
/// Add this to every loose prop.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PropResetter : MonoBehaviour
{
    [SerializeField] private float fallLimitY = -5f;

    private Rigidbody propRigidbody;
    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Awake()
    {
        propRigidbody = GetComponent<Rigidbody>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if (transform.position.y < fallLimitY)
        {
            ResetToStart();
        }
    }

    public void ResetToStart()
    {
        propRigidbody.linearVelocity = Vector3.zero;
        propRigidbody.angularVelocity = Vector3.zero;
        transform.SetPositionAndRotation(startPosition, startRotation);
    }
}

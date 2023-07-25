using Herdsman.Scripts.Components.Collision;
using UnityEngine;

public class YardTrigger : MonoBehaviour, ITriggerDetector
{
    [field: SerializeField] public int YardTriggerId { get; private set; }

    public Transform Transform { get; private set; }

    private void Awake()
    {
        Transform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<TriggerReceiver>(out var triggerReceiver))
        {
            triggerReceiver.OnCollision(this);
        }
    }
}
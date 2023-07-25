using Herdsman.Scripts.Components.Collision;
using UnityEngine;

public interface ITriggerDetector
{
    public Transform Transform { get; }
}

public class PlayerTrigger : MonoBehaviour, ITriggerDetector
{
    public Color TriggeredColor { get; private set; }
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
    
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<TriggerReceiver>(out var triggerReceiver))
        {
            triggerReceiver.OnExitCollision();
        }
    }

    public void SetColor(Color color)
    {
        TriggeredColor = color;
    }
}
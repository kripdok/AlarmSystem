using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeReference]private AlarmSystemEvent _detectorEvent;

    private void OnTriggerEnter(Collider collider)
    {
        if (CheckColliderComponent(collider))
        {
            _detectorEvent.DetectPlayer();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (CheckColliderComponent(collider))
        {
            _detectorEvent.LosePlayer();
        }
    }

    private bool CheckColliderComponent(Collider collider)
    {
        return (collider.TryGetComponent<Player>(out Player player));
    }
}
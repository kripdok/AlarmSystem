using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public bool IsInside { get { return _isWork; } }
    private bool _isWork;

    private void OnTriggerEnter(Collider collider)
    {
        if (CheckColliderComponent(collider))
        {
            _isWork = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (CheckColliderComponent(collider))
        {
            _isWork = false;
        }
    }

    private bool CheckColliderComponent(Collider collider)
    {
        return (collider.TryGetComponent<Player>(out Player player));
    }
}

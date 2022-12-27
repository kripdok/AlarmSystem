using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public event Action OnPlayerDetect;
    public event Action OnPlayerLose;

    private void OnTriggerEnter(Collider collider)
    {
        if (CheckColliderComponent(collider))
        {
            RunAction(OnPlayerDetect);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (CheckColliderComponent(collider))
        {
            RunAction(OnPlayerLose);
        }
    }

    private void RunAction(Action action)
    {
        if (action != null)
        {
            action();
        }
    }

    private bool CheckColliderComponent(Collider collider)
    {
        return (collider.TryGetComponent<Player>(out Player player));
    }
}
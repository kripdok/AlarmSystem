using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public event Action FoundPlayer;
    public event Action LostPlayer;

    private void OnTriggerEnter(Collider collider)
    {
        if (CheckColliderComponent(collider))
        {
            RunAction(FoundPlayer);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (CheckColliderComponent(collider))
        {
            RunAction(LostPlayer);
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
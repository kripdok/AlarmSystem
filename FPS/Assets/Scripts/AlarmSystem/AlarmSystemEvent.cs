using System;
using UnityEngine;

public class AlarmSystemEvent : MonoBehaviour
{
    public event Action OnPlayerDetect;
    public event Action OnPlayerLose;

    public void DetectPlayer()
    {
        if (OnPlayerDetect != null)
        {
            OnPlayerDetect();
        }
    }

    public void LosePlayer()
    {
        if(OnPlayerLose!= null)
        {
            OnPlayerLose();
        }
    }
}

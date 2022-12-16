using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeReference] private AudioSource _alarmSound;
    private float _volumeBooster = 0.1f;
    private float _volume = 0.0f;

    private void Update()
    {
        _alarmSound.volume += _volume * Time.deltaTime;

        if (_alarmSound.volume == 0)
        {
            _alarmSound.Stop();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            if(_alarmSound.isPlaying == false)
            {
                _alarmSound.Play();
            }

            _alarmSound.volume = 0.01f;
            _volume = _volumeBooster;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        _volume = -_volumeBooster;
    }
}

using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SirenPlayback : MonoBehaviour
{
    [SerializeReference] private AudioSource _alarmSound;
    private float _volumeBooster = 0.1f;
    private float _minVolume = 0.0f;
    private float _maxVolume = 1.0f;

    private void Start()
    {
        _alarmSound.volume = _minVolume;
    }

    private void Update()
    {
        if (_alarmSound.isPlaying == false)
        {
            StopCoroutine(TurnDownVolume());
        }
    }

    IEnumerator TurnUpVolume()
    {
        while (_alarmSound.volume < _maxVolume)
        {
            if (_alarmSound.isPlaying == false)
            {
                _alarmSound.Play();
            }

            _alarmSound.volume += _volumeBooster * Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator TurnDownVolume()
    {
        while (_alarmSound.volume > _minVolume)
        {
            _alarmSound.volume -= _volumeBooster * Time.deltaTime;

            if (_alarmSound.volume == 0.0f)
            {
                _alarmSound.Stop();
            }

            yield return null;
        }
    }
}

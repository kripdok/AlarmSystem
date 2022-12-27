using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SirenPlayback : MonoBehaviour
{
    [SerializeReference] private AudioSource _alarmSound;
    [SerializeReference] private AlarmSystemEvent _detectorEvent;
    private float _volumeBooster;
    private float _minVolume = 0.0f;

    private void Start()
    {
        _alarmSound.volume = _minVolume;
    }

    private void OnEnable()
    {
        _detectorEvent.OnPlayerDetect += TurnUpVolume;
        _detectorEvent.OnPlayerLose += TurnDownVolume;
    }

    private void OnDisable()
    {
        _detectorEvent.OnPlayerDetect -= TurnUpVolume;
        _detectorEvent.OnPlayerLose -= TurnDownVolume;
    }

    private void TurnUpVolume()
    {
        _volumeBooster = 0.05f;
        StartCoroutine(AdjustVolume());
    }

    private void TurnDownVolume()
    {
        _volumeBooster = -0.05f;

        if (_alarmSound.volume == _minVolume)
        {
            _alarmSound.Stop();
            StopCoroutine(AdjustVolume());
            OnDisable();
        }
    }

    private IEnumerator AdjustVolume()
    {
        bool isWork = true;

        while (isWork)
        {
            if (_alarmSound.isPlaying == false)
            {
                _alarmSound.Play();
            }

            _alarmSound.volume += _volumeBooster * Time.deltaTime;
            yield return null;
        }
    }
}
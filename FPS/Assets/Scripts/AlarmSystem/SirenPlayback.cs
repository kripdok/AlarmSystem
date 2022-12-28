using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class SirenPlayback : MonoBehaviour
{    
    [SerializeReference] private Detector _detector;

    private Coroutine _volumeController;
    private AudioSource _alarmSound;
    private float _volumeBooster = 0.1f;
    private float _maxVolume = 1.0f;
    private float _minVolume = 0.0f;

    private void Start()
    {
        _alarmSound= GetComponent<AudioSource>();
        _alarmSound.volume = _minVolume;
    }

    private void OnEnable()
    {
        _detector.FoundPlayer += TurnUpVolume;
        _detector.LostPlayer += TurnDownVolume;
    }

    private void OnDisable()
    {
        _detector.FoundPlayer -= TurnUpVolume;
        _detector.LostPlayer -= TurnDownVolume;
    }

    private void TurnUpVolume()
    {
        TurnVolume(_maxVolume);
    }

    private void TurnDownVolume()
    {
        TurnVolume(_minVolume);
    }

    private void TurnVolume(float volume)
    {
        if (_volumeController != null)
        {
            StopCoroutine(_volumeController);
        }

        _volumeController = StartCoroutine(AdjustVolume(volume));
    }

    private IEnumerator AdjustVolume(float target)
    {
        if (_alarmSound.isPlaying == false)
        {
            _alarmSound.Play();
        }

        while (_alarmSound.volume != target)
        {
            _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, target, _volumeBooster * Time.deltaTime);
            yield return null;
        }

        if (_alarmSound.volume == _minVolume)
        {
            _alarmSound.Stop();
        }
    }
}
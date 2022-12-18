using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SirenPlayback : MonoBehaviour
{
    [SerializeReference] private AudioSource _alarmSound;
    [SerializeReference] private GameObject _triggerZone;
    private PlayerDetection _detector;
    private float _volumeBooster = 0.1f;
    private float _minVolume = 0.0f;

    private void Start()
    {
        _alarmSound.volume = _minVolume;
        _detector = _triggerZone.GetComponent<PlayerDetection>();
    }

    private void Update()
    {
        StartCoroutine(AdjustVolume());

        if (_alarmSound.volume == _minVolume)
        {
            StopCoroutine(AdjustVolume());
            _alarmSound.Stop();
        }
    }

    private IEnumerator AdjustVolume()
    {
        if (_detector.IsInside)
        {
            if (_alarmSound.isPlaying == false)
            {
                _alarmSound.Play();
            }

            _alarmSound.volume += _volumeBooster * Time.deltaTime;
        }
        else
        {
            _alarmSound.volume -= _volumeBooster * Time.deltaTime;
        }

        yield return null;
    }
}

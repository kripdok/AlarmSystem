using UnityEngine;
using UnityEngine.Events;

public class PlayerDetection : MonoBehaviour
{
    [SerializeReference] private GameObject _siren;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            if (_siren.TryGetComponent<SirenPlayback>(out SirenPlayback sirenPlayback))
            {
                _siren.GetComponent<SirenPlayback>().StopCoroutine("TurnDownVolume");
                _siren.GetComponent<SirenPlayback>().StartCoroutine("TurnUpVolume");
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out Player player))
        {
            if (_siren.TryGetComponent<SirenPlayback>(out SirenPlayback sirenPlayback))
            {
                _siren.GetComponent<SirenPlayback>().StopCoroutine("TurnUpVolume");
                _siren.GetComponent<SirenPlayback>().StartCoroutine("TurnDownVolume");
            }
        }    
    }
}

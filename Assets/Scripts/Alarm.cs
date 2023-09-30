using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Alarm : MonoBehaviour
{
    public readonly int IsCrook = Animator.StringToHash(nameof(IsCrook));

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Penetration _house;

    private Animator _animator;
    private Coroutine _volumeChanger;
    private bool _isPlaying = false;

    private void Start()
    {
        _audioSource.volume = 0;
        StartVolumeChanger();
        _audioSource.Play();
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void StartVolumeChanger()
    {
        if (_house != null)
        {
            _volumeChanger = StartCoroutine(ChangeVolume());          
        }
        else
        {
            StopCoroutine(_volumeChanger);
            _isPlaying = false;
        }
    }

    private IEnumerator ChangeVolume(float maxVolume = 1f)
    {

        _isPlaying = true;
        float oneSecond = 1f;
        float targetVolume;
        float valumeValueChange = 0.05f;        
        WaitForSeconds wait = new WaitForSeconds(oneSecond);

        while (_isPlaying == true) 
        {
            if (_house.IsPenetration == true)
            {
                _animator.SetBool(IsCrook, _house.IsPenetration);
                targetVolume = maxVolume;
            }
            else
            {
                _animator.SetBool(IsCrook, _house.IsPenetration);
                targetVolume = 0;
            }

            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, valumeValueChange);
            yield return wait;
        }
    }
}

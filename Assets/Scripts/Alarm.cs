using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Alarm : MonoBehaviour
{
    private const string _animatorParameter = "IsCrook";

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
        if (_volumeChanger == null)
        {
            StopCoroutine(ChangeVolume());
            _isPlaying= false;
        }

        _volumeChanger = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume(float maxVolume = 1f)
    {
        _isPlaying = true;
        float oneSecond = 1f;
        var wait = new WaitForSeconds(oneSecond);
        float targetVolume;
        float valumeValueChange = 0.05f;        

        while (_isPlaying == true) 
        {
            if (_house.IsPenetration == true)
            {
                _animator.SetBool(_animatorParameter, _house.IsPenetration);
                targetVolume = maxVolume;
            }
            else
            {
                _animator.SetBool(_animatorParameter, _house.IsPenetration);
                targetVolume = 0;
            }

            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, valumeValueChange);
            yield return wait;
        }
    }
}

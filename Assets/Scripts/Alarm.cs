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
        var wait = new WaitForSeconds(1f);
        float upVolumeValue = 0.04f;
        float dawnVolumeValue = 0.05f;

        while (_isPlaying == true) 
        {
            if (_house.IsPenetration == true)
            {
                _animator.SetBool(_animatorParameter, _house.IsPenetration);
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, maxVolume, upVolumeValue);
                yield return wait;
            }
            else
            {
                _animator.SetBool(_animatorParameter, _house.IsPenetration);
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, dawnVolumeValue);
                yield return wait;
            }
        }
    }
}

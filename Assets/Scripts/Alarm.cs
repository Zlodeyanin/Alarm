using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Penetration _house;

    private Animator _animator;
    private bool _isPlaying = false;

    private void Start()
    {
        _audioSource.volume = 0;
        _audioSource.Play();
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        const string AnimatorParameter = "IsCrook";

        if (_house.IsPenetration == true && _isPlaying == false)
        {
            _animator.SetBool(AnimatorParameter, _house.IsPenetration);
            StartCoroutine(ChangeVolume());
        }
        else
        {
            _animator.SetBool(AnimatorParameter, _house.IsPenetration);
            StopCoroutine(ChangeVolume());
        }
    }

    private IEnumerator ChangeVolume(int maxVolume = 100)
    {
        _isPlaying = true;
        var wait = new WaitForSeconds(1f);
        float upVolumeValue = 0.04f;
        float dawnVolumeValue = 0.05f;

        for (int i = 0; i < maxVolume; i++)
        {
            if (_house.IsPenetration == true)
            {
                _audioSource.volume += upVolumeValue;
                yield return wait;
            }
            else
            {
                _audioSource.volume-= dawnVolumeValue;
                yield return wait;
            }
        }
    }
}

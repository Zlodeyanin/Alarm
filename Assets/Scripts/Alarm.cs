using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Alarm : MonoBehaviour
{
    public readonly int IsCrook = Animator.StringToHash(nameof(IsCrook));

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private HomeInvasion _house;

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

    private IEnumerator ChangeVolume(float maxVolume = 1f, float valumeValueChange = 0.05f)
    {
        _isPlaying = true;
        float volumeChangeTime = 1f;
        float targetVolume;      
        WaitForSeconds wait = new WaitForSeconds(volumeChangeTime);

        while (_isPlaying == true) 
        {
            if (_house.IsPenetration == true)           
                targetVolume = maxVolume;           
            else           
                targetVolume = 0;          

            _animator.SetBool(IsCrook, _house.IsPenetration);
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, valumeValueChange);
            yield return wait;
        }
    }
}

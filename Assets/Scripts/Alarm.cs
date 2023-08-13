using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private UnityEvent _alarm;
    [SerializeField] private AudioSource _audioSource;
    public bool IsAlarmOn { get; private set; } = false;
    private Animator _animator;
    private Coroutine _coroutine;

    public event UnityAction Reached
    {
        add => _alarm.AddListener(value);
        remove => _alarm.RemoveListener(value);
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource.volume = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsAlarmOn)
        {
            return;
        }

        if (collision.TryGetComponent<Player>(out Player player))
        {
            StopAllCoroutines();
            _coroutine = StartCoroutine(UpVolume());
            IsAlarmOn = true;
            _alarm.Invoke();
            _animator.SetBool("IsCrook", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            StopAllCoroutines();
            IsAlarmOn = false;
            _alarm.Invoke();
            _coroutine= StartCoroutine(DownVolume());
        }
    }

    private IEnumerator UpVolume(int maxVolume = 100)
    {
        var wait = new WaitForSeconds(1f);

        for (int i = 0; i < maxVolume; i++)
        {
            _audioSource.volume += 0.04f;
            yield return wait;
        }
    }

    private IEnumerator DownVolume(int maxVolume = 100)
    {
        var wait = new WaitForSeconds(1f);

        for (int i = maxVolume; i > 0; i--)
        {
            _audioSource.volume -= 0.09f;
            yield return wait;
        }
    }
}

using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    public readonly int Speed = Animator.StringToHash(nameof(Speed));

    [SerializeField] private float _playerSpeed;

    private Animator _animator;
    private SpriteRenderer _flip;
    private float _zeroMove = 0;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _flip = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float playerGo = 2f;
        float playerStay = 0;

        if (Input.GetKey(KeyCode.A))
        {
            _flip.flipX = false;
            transform.Translate(_playerSpeed * Time.deltaTime* -1, _zeroMove, _zeroMove);
            _animator.SetFloat(Speed, playerGo);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _flip.flipX = true;
            transform.Translate(_playerSpeed * Time.deltaTime, _zeroMove, _zeroMove);
            _animator.SetFloat(Speed, playerGo);
        }
        else
        {
            _animator.SetFloat(Speed, playerStay);
        }
    }
}

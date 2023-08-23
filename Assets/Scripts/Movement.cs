using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    private const string _animatorParameter = "Speed";

    private Animator _animator;
    private SpriteRenderer _flip;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _flip = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float playerGo = 2f;
        float playerStay = 0;
        float playerGoLeft = -0.005f;
        float playerGoRight = 0.005f;
        float playerTransformY = 0;
        float playerTransformZ = 0;

        if (Input.GetKey(KeyCode.A))
        {
            _flip.flipX = false;
            transform.Translate(playerGoLeft, playerTransformY, playerTransformZ);
            _animator.SetFloat(_animatorParameter, playerGo);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _flip.flipX = true;
            transform.Translate(playerGoRight, playerTransformY, playerTransformZ);
            _animator.SetFloat(_animatorParameter, playerGo);
        }
        else
        {
            _animator.SetFloat(_animatorParameter, playerStay);
        }
    }
}

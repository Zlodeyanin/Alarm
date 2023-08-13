using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        var flip = gameObject.GetComponent<SpriteRenderer>();

        if (Input.GetKey(KeyCode.A))
        {
            flip.flipX = false;
            transform.Translate(-0.005f, 0, 0);
            _animator.SetFloat("Speed", 2);
        }
        else if (Input.GetKey(KeyCode.D))
        {            
            flip.flipX = true;
            transform.Translate( 0.005f, 0, 0);
            _animator.SetFloat("Speed", 2);
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }
    }
}

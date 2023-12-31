using UnityEngine;

public class HomeInvasion : MonoBehaviour
{
    public bool IsPenetration { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            IsPenetration = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            IsPenetration = false;
        }
    }
}

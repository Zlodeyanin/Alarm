using UnityEngine;

public class Penetration : MonoBehaviour
{
    public bool IsPenetration { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsPenetration = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsPenetration = false;
        }
    }
}

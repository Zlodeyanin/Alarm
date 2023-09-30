using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]private Vector2 _point;

    private void OnTriggerStay2D(Collider2D collision)
    {      
        if (collision.TryGetComponent(out Player player))
        {
            player.transform.position = _point;
        }
    }
}

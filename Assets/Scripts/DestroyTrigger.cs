using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Obstacle obstacle))
        {
            Destroy(obstacle.gameObject);
        }
    }
}

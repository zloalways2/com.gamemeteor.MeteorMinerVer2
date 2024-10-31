using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float startSpeed;

    private void Start()
    {
        rb.velocity = Vector3.down * startSpeed;
    }
}

using UnityEngine;

public class PlayerTriggerChecker : MonoBehaviour
{
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private PlayerHealth playerHealth;

    [SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioClip collectClip;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            playerHealth.DecreaseHealth();
            audioSource.PlayOneShot(hitClip);
        }
        else if (collision.CompareTag("Collectible"))
        {
            scoreCounter.AddScore();
            audioSource.PlayOneShot(collectClip);
        }

        Destroy(collision.gameObject);
    }
}

using System.Collections;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject collectiblePrefab;

    [SerializeField] private Transform spawnpointTransform;

    [SerializeField] private float maxX;
    [SerializeField] private float obstacleChance;

    public float Interval { private get; set; }
    public bool IsEnabled { private get; set; } = true;

    private void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitUntil(() => IsEnabled == true);

            float xPos = Random.Range(-maxX, maxX);
            Vector2 spawnPosition = new Vector2(xPos, spawnpointTransform.position.y);

            GameObject prefab = collectiblePrefab;
            if (Random.Range(0, 1f) <= obstacleChance) prefab = obstaclePrefab;

            Instantiate(prefab, spawnPosition, Quaternion.identity);

            yield return new WaitUntil(() => IsEnabled == true);

            yield return new WaitForSeconds(Interval);
        }
    }
}

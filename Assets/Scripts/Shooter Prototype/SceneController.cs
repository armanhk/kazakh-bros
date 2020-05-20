using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public float playerSpeed;
    public Vector2 screenBounds;
    public EnemyController enemyPrefab;

    private void Awake()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Start is called before the first frame update
    private void Start()
    {
        playerSpeed = 10;
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        Vector3 randomSpawnPoint = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y, 0);
        Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity);

        yield return new WaitForSeconds(2);

        yield return StartCoroutine(SpawnEnemy());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ProjectileController projectilePrefab;
    private SceneController sceneController;
    private float objectWidth;

    private void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnProjectile());
        }
    }

    private IEnumerator SpawnProjectile()
    {
        ProjectileController instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        yield return null;
    }

    private void MovePlayer()
    {
        // Define the movement
        float playerDirection = Input.GetAxis("Horizontal");
        Vector3 playerPosition = transform.position;
        float horizontalMovement = playerDirection * Time.deltaTime * sceneController.playerSpeed;
        Vector2 playerMovement = new Vector2(horizontalMovement, 0);

        if (playerPosition.x + playerMovement.x > -sceneController.screenBounds.x + objectWidth/2
            && playerPosition.x + playerMovement.x < sceneController.screenBounds.x - objectWidth/2)
        {
            transform.Translate(playerMovement);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private SceneController sceneController;
    private SpriteRenderer spriteRenderer;
    private float objectHeight;

    private void Awake()
    {
        sceneController = FindObjectOfType<SceneController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        objectHeight = spriteRenderer.bounds.size.y;
    }

    // Update is called once per frame
    private void Update()
    {
        MoveEnemy();
        if (transform.position.y - objectHeight/2 <= -sceneController.screenBounds.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void MoveEnemy()
    {
        transform.Translate(Vector2.down * Time.deltaTime * 2);
    }
}

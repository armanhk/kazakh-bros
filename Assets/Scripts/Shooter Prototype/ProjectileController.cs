using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
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

    // Start is called before the first frame update
    private void Update()
    {
        MoveProjectile();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void MoveProjectile()
    {
        if (transform.position.y + objectHeight/2 >= sceneController.screenBounds.y)
        {
            Destroy(gameObject);
        }
        else
        {
            // Scale passed vector to manipulate projectile speed
            transform.Translate(Vector2.up * Time.deltaTime * 5);
        }
    }
}

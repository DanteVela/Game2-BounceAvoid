using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveV2 : MonoBehaviour
{
    private const float SPEED = 4.0f;

    private float SPRITE_RADIUS;

    private Vector2 SCREEN_MIN;

    private Vector2 SCREEN_MAX;

    // Start is called before the first frame update
    void Start()
    {
        // Get screen size from camera
        SCREEN_MIN = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        SCREEN_MAX = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Get self size from the sprite
        SPRITE_RADIUS = GameObject.Find("circle2").GetComponent<SpriteRenderer>().sprite.bounds.extents.x;
    }

    void PauseGame()
    {
        Time.timeScale = 0.0f;
        // AudioListener.pause = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1.0f;
        // AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.P))
        {
            // Pauses the Game
            PauseGame();
        }
        else if(Input.GetKey(KeyCode.U))
        {
            // Unpauses the Game
            ResumeGame();
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();

        transform.position = transform.position + (Vector3)(input * SPEED * Time.deltaTime);

        // Detect collision with the Ceiling
        if(transform.position.y + SPRITE_RADIUS > SCREEN_MAX.y)
        {
            // Debug.Log("Hitting Ceiling");

            // If colliding, move out of the overlap
            float dist = transform.position.y + SPRITE_RADIUS - SCREEN_MAX.y;
            transform.Translate(0.0f, -dist, 0.0f);
        }

        // Detect collision with the (Right) Wall
        if(transform.position.x + SPRITE_RADIUS > SCREEN_MAX.x)
        {
            // Debug.Log("Hitting Right Wall");

            // If colliding, move out of the overlap
            float dist = transform.position.x + SPRITE_RADIUS - SCREEN_MAX.x;
            transform.Translate(-dist, 0.0f, 0.0f);
        }
        
        // Detect collision with the Floor
        if(transform.position.y - SPRITE_RADIUS < SCREEN_MIN.y)
        {
            // Debug.Log("Hitting Floor");

            // If colliding, move out of the overlap
            float dist = -transform.position.y + SPRITE_RADIUS + SCREEN_MIN.y;
            transform.Translate(0.0f, dist, 0.0f);
        }

        // Detect collision with the (Left) Wall
        if(transform.position.x - SPRITE_RADIUS < SCREEN_MIN.x)
        {
            // Debug.Log("Hitting Left Wall");

            // If colliding, move out of the overlap
            float dist = -transform.position.x + SPRITE_RADIUS + SCREEN_MIN.x;
            transform.Translate(dist, 0.0f, 0.0f);
        }
    }
}
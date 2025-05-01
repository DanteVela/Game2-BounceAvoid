using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class BounceV2 : MonoBehaviour
{
    Vector2 _velocity = new Vector2(1.8f, 1.8f);

    private float SPEED = 4.0f;

    // private float CEILING_HEIGHT = 5.0f;

    private float SPRITE_RADIUS;

    private Vector2 SCREEN_MIN;

    private Vector2 SCREEN_MAX;

    void Start()
    {
        // Get screen size from camera
        SCREEN_MIN = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        SCREEN_MAX = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        
        // Debug.Log(SCREEN_MAX);
        // Debug.Log(SCREEN_MIN);


        // Get self size from the sprite
        SPRITE_RADIUS = GameObject.Find("circle").GetComponent<SpriteRenderer>().sprite.bounds.extents.x;

        // Function Call for Start Method (set initial velocity)
        SetRandomVelocity();
    }

    public void SetRandomVelocity()
    {
        // Set random direction, the scale by speed to set velocity
        Vector2 dir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        _velocity = dir.normalized * SPEED;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Integrate velocity to update position
        transform.Translate(_velocity * Time.deltaTime);

        // Detect collision with the Ceiling
        if(transform.position.y + SPRITE_RADIUS > SCREEN_MAX.y)
        {
            // Debug.Log("Hitting Ceiling");

            // If colliding, move out of the overlap
            float dist = transform.position.y + SPRITE_RADIUS - SCREEN_MAX.y;
            transform.Translate(0.0f, -dist, 0.0f);

            // Invert the vertical velocity component
            _velocity = new Vector2(_velocity.x, -1 * _velocity.y);
        }

        // Detect collision with the (Right) Wall
        if(transform.position.x + SPRITE_RADIUS > SCREEN_MAX.x)
        {
            // Debug.Log("Hitting Right Wall");

            // If colliding, move out of the overlap
            float dist = transform.position.x + SPRITE_RADIUS - SCREEN_MAX.x;
            transform.Translate(-dist, 0.0f, 0.0f);

            // Invert the horizontal velocity component
            _velocity = new Vector2(-1 * _velocity.x, _velocity.y);
        }
        
        // Detect collision with the Floor
        if(transform.position.y - SPRITE_RADIUS < SCREEN_MIN.y)
        {
            // Debug.Log("Hitting Floor");

            // If colliding, move out of the overlap
            float dist = -transform.position.y + SPRITE_RADIUS + SCREEN_MIN.y;
            transform.Translate(0.0f, dist, 0.0f);

            // Invert the vertical velocity component
            _velocity = new Vector2(_velocity.x, -1 * _velocity.y);
        }

        // Detect collision with the (Left) Wall
        if(transform.position.x - SPRITE_RADIUS < SCREEN_MIN.x)
        {
            // Debug.Log("Hitting Left Wall");

            // If colliding, move out of the overlap
            float dist = -transform.position.x + SPRITE_RADIUS + SCREEN_MIN.x;
            transform.Translate(dist, 0.0f, 0.0f);

            // Invert the horizontal velocity component
            _velocity = new Vector2(-1 * _velocity.x, _velocity.y);
        }

        // (repeat 4 walls)
        // check if inside wall
        // if so, move out of wall
        // and calculate the outgoing velocity (Invert perpendicular axis)
    }
}

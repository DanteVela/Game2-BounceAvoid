using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Bounce : MonoBehaviour
{
    // class variables for speed, screen size, self size, velocity
    private const float speed = 4.0f;

    private float radius, width, height;

    private Vector2 screen_sizeBottomLeft, screen_sizeTopRight;

    // private Vector2 screen_size;

    private SpriteRenderer self_size; // Declare a SpriteRenderer variable to hold our SpriteRenderer component

    private Vector2 velocity = Vector2.zero;

    void Start()
    {
        // get screen size from camera
        screen_sizeBottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);
        screen_sizeTopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        // screen_size = Camera.main.ViewportToWorldPoint(new Vector2(0,0 to 1,1));


        // get self size from the sprite
        width = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        // height = GetComponent<SpriteRenderer>().sprite.bounds.size.y;
        radius = width / 2;

        // Function Call for Start Method (set initial velocity)
        SetRandomVelocity();
    }

    public void SetRandomVelocity()
    {
        // set random direction, the scale by speed to set velocity
        velocity = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // integrate velocity to update position
        transform.position = (Vector2)transform.position + (velocity * speed * Time.deltaTime);

        // detect wall collisions and respond
        if(transform.position.y < screen_sizeBottomLeft.y + radius && velocity.y < 0)
        {
            velocity.y = -velocity.y;
        }
        if(transform.position.y > screen_sizeTopRight.y - radius && velocity.y > 0)
        {
            velocity.y = -velocity.y;
        }
        if(transform.position.x < screen_sizeBottomLeft.x + radius && velocity.x < 0)
        {
            velocity.x = -velocity.x;
        }
        if(transform.position.x > screen_sizeTopRight.x - radius && velocity.x > 0)
        {
            velocity.x = -velocity.x;
        }

        // (repeat 4 walls)
        // check if inside wall
        // if so, move out of wall
        // and calculate the outgoing velocity (Invert perpendicular axis)
    }
}
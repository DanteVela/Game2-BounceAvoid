using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private const float SPEED = 4.0f;

    void Update()
    {
        // Vector2 dir = Vector2.zero;

        // float xdir = Input.GetAxis("Horizontal");
        // float ydir = Input.GetAxis("Vertical");

        float xdir = Input.GetAxisRaw("Horizontal");
        float ydir = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(xdir, ydir).normalized;

        /*if(Input.GetKey(KeyCode.W)) {
            dir += Vector2.up;
        } 
        if(Input.GetKey(KeyCode.S) {
            dir += Vector2.down;
        }
        if(Input.GetKey(KeyCode.A) {
            dir += Vector2.left;
        }
        if(Input.GetKey(KeyCode.D) {
            dir += Vector2.right;
        }
        dir.Normalize();*/

        transform.position = (Vector2)transform.position + (dir * SPEED * Time.deltaTime);
    }
}
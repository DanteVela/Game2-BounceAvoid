using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // class variables for screen size and spawn timer
    
    // Vector2 screen_size = Vector2.zero;

    private float spawn_timer = 3.0f;

    private Transform child;

    // public Text timeTracker;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // tick the timer down
        if(spawn_timer > 0 && transform.childCount > 0)
        {
            spawn_timer -= Time.deltaTime;
        }
        else
        {
            if(transform.childCount > 0)
            {
                child = transform.GetChild(transform.childCount - 1);
                child.gameObject.transform.parent = null;
                child.gameObject.transform.position = new Vector2(Random.Range(0, 5), Random.Range(0, 5));
                child.gameObject.GetComponent<Bounce>().enabled = true;

                spawn_timer = 3.0f;
            }
            else
            {
                spawn_timer = 0.0f;
            }
        }
        // timeTracker.text = Mathf.Round(spawn_timer).ToString();


        // when it expires, time to spawn if we still have children
        // unparent the next from this entity
        // move it into the world at random position, velocity
        // and enable its movement script to start it moving
        // reset the timer (could deactivate self if children all gone)
    }
}
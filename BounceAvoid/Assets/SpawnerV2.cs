using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerV2 : MonoBehaviour
{
    private float _spawnTimer;

    public const float SPAWN_INTERVAL = 1.0f;

    private Vector2 SCREEN_MAX;

    private Vector2 SCREEN_MIN;

    // Start is called before the first frame update
    void Start()
    {
        // Screen coordinates 0,0 -> 1,1 converted into world coordinates
        SCREEN_MAX = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        SCREEN_MIN = Camera.main.ViewportToWorldPoint(Vector2.zero);

        // Start spawn timer and count down
        _spawnTimer = SPAWN_INTERVAL;
    }

    // Update is called once per frame
    void Update()
    {
        // Tick the timer down
        _spawnTimer = _spawnTimer - Time.deltaTime;

        if(_spawnTimer <= 0.0f) {
            // Timer expired, time to spawn if we still have children
            if(transform.childCount >= 1) {
                // Unparent from this object
                Transform child_transform = transform.GetChild(0);
                child_transform.parent = null;

                // Get the control script for that child
                GameObject child = child_transform.gameObject;
                BounceV2 child_script = child.GetComponent<BounceV2>();
                // Bounce child_script = child.GetComponent<Bounce>();

                // Set position (wall collision will handle if its too close to an edge)
                child_transform.position = (Vector3)new Vector2(
                    Random.Range(SCREEN_MIN.x, SCREEN_MAX.x),
                    Random.Range(SCREEN_MIN.y, SCREEN_MAX.y)
                );

                // Set velocity
                child_script.SetRandomVelocity();

                // Mark script enabled, which will invoke Start/Update next time around
                child_script.enabled = true;
            }

            // Reset timer (could deactivate self if children all gone)
            if(transform.childCount > 0)
                _spawnTimer = SPAWN_INTERVAL;
            else
            {
                // gameObject.SetActive(false);
                enabled = false;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagV2 : MonoBehaviour
{
    private Transform _enemy;

    private Text _scoreBoard;

    private const float SPEED = 4.0f;

    private int _score;

    private float _tagCD = 0.0f;
    
    private const float TAGDIST = 1.0f;

    Vector3 originalPos;

    void Start()
    {
        _enemy = GameObject.Find("circle2").transform;
        _scoreBoard = GameObject.Find("score").GetComponent<Text>();
        _score = 0;

        originalPos = gameObject.transform.position;
    }

    void Update()
    {
        Vector2 path = _enemy.position - transform.position;
        float dist = path.magnitude;
        Vector2 dir = path.normalized;
        float step = SPEED * Time.deltaTime;

        /*if(step > dist) {
            transform.position = _enemy.position;
        } else {
            transform.position = (Vector2)transform.position + (dir * step);
        }*/

        /*if(_tagCD > 0.0f){
            _tagCD -= Time.deltaTime;
        }*/

        if(_tagCD <= 0 && dist < TAGDIST) {
            _score += 1;
            transform.position = originalPos;
            _scoreBoard.text = _score.ToString();
            // _tagCD = 1.0f;
        }
    }
}
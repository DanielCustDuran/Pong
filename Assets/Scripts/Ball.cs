using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform paddle;
    bool gameStarted = false;
    Rigidbody2D rgBall;
    // Start is called before the first frame update
    void Start()
    {
        rgBall = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            float posDiff = paddle.position.x - transform.position.x;
            transform.position = new Vector3(paddle.position.x - posDiff, paddle.position.y, paddle.position.z);
            if (Input.GetMouseButtonDown(0))
            {
                gameStarted = true;
                rgBall.velocity = new Vector2(5, 5);
            }
        }
    }
}

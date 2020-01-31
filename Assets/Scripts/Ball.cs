using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Transform paddle;
    public bool gameStarted = false;
    Rigidbody2D rgBall;
    float posDiff = 0;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rgBall = GetComponent<Rigidbody2D>();
        posDiff = paddle.position.x - transform.position.x;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            
            transform.position = new Vector3(paddle.position.x - posDiff, paddle.position.y, paddle.position.z);
            if (Input.GetMouseButtonDown(0))
            {
                gameStarted = true;
                rgBall.velocity = new Vector2(5, 5);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
    }
}

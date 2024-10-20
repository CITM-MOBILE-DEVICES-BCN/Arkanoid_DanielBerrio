using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D ballbody2D;

    public float speed = 300;

    private Vector2 velocity;

    Vector2 startPosition;


    void Start()
    {
        startPosition = transform.position;


        ResetBall();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {

            FindObjectOfType<GameManager>().LoseHealth();

        }
    }

    public void ResetBall()
    {
        transform.position = startPosition;

        ballbody2D.velocity = Vector2.zero;

        Invoke("StartBall", 2f);       

    }

    public void StartBall()
    {

        velocity.x = Random.Range(-1f, 1f);

        velocity.y = 1;

        ballbody2D.AddForce(velocity * speed);

    }

}

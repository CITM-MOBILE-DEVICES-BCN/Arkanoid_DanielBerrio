using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D ballbody2D;

    public Collider2D ballCollider;

    public float speed = 300;

    private float multiplayer = 1.01f;

    private Vector2 velocity;

    Vector2 startPosition;

    public AudioSource audioSource;

    public AudioClip playerSound, brickSound, wallSound, deadSound;

    void Start()
    {
        startPosition = transform.position;

        ResetBall();

        Debug.Log(ballbody2D.velocity);

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {

            audioSource.clip = deadSound;
            audioSource.Play();

            FindObjectOfType<GameManager>().LoseHealth();

           

        }

        if (collision.gameObject.CompareTag("Brick"))
        {
                      
            ballbody2D.velocity = new Vector2(ballbody2D.velocity.x * multiplayer, ballbody2D.velocity.y * multiplayer);

            
            VelocityFixed();

            audioSource.clip = brickSound;
            audioSource.Play();

        }

        if (collision.gameObject.CompareTag("Player"))
        {
            
            // Determina la posici�n de la bola con respecto al jugador
            Vector2 ballPosition = transform.position;
            Vector2 playerPosition = FindObjectOfType<Player>().transform.position;

            // Calcula la diferencia de posiciones
            float offset = ballPosition.x - playerPosition.x;

            // Ajusta la direcci�n del rebote seg�n donde colisiona
            if (offset < -FindObjectOfType<Player>().transform.localScale.x / 4) // Colisi�n en la parte izquierda
            {
                ballbody2D.velocity = new Vector2(-Mathf.Abs(ballbody2D.velocity.x), ballbody2D.velocity.y);
            }
            else if (offset > FindObjectOfType<Player>().transform.localScale.x / 4) // Colisi�n en la parte derecha
            {
                ballbody2D.velocity = new Vector2(Mathf.Abs(ballbody2D.velocity.x), ballbody2D.velocity.y);
            }
            else // Colisi�n en el centro
            {
                ballbody2D.velocity = new Vector2(ballbody2D.velocity.x, Mathf.Abs(ballbody2D.velocity.y));
            }

          

            VelocityFixed();

            audioSource.clip = playerSound;
            audioSource.Play();
        }

        if (collision.gameObject.CompareTag("Wall"))
        {

            VelocityFixed();
            audioSource.clip = wallSound;
            audioSource.Play();

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

    private void VelocityFixed()
    {
        float velocityDelta = 0.5f;
        float minvelocity = 0.2f;
        
        if(Mathf.Abs(ballbody2D.velocity.x) < minvelocity)
        {
            velocityDelta = Random.value < 0.5f ? velocityDelta : -velocityDelta;
            ballbody2D.velocity += new Vector2(velocityDelta, 0f);
        }

        if (Mathf.Abs(ballbody2D.velocity.y) < minvelocity)
        {
            velocityDelta = Random.value < 0.5f ? velocityDelta : -velocityDelta;
            ballbody2D.velocity += new Vector2(0f, velocityDelta);
        }
    }

}

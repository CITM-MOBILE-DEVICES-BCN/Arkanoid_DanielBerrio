using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public bool tocho;

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Ball"))
        {
            if (!tocho)
            {
                FindObjectOfType<GameManager>().CheckLevelCompleted();
                FindObjectOfType<GameManager>().MorePuntuation();
                Destroy(gameObject);

            }
            if (tocho)
            {

                tocho = !tocho;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);

            }
            
            
        }


    }





}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Rigidbody2D playerBody2D;

    private float inputValue;
    public float moveSpeed = 25;

    public Slider movementSlider;

    public float minX = -10f;
    public float maxX = 10f;

   

    private Vector2 direction;

    Vector2 startPosition;

    public bool autoMode = false;

    private void Start()
    {
        startPosition = transform.position;
        movementSlider.value = 0.5f;
    }

    void Update()
    {

        if(autoMode == false)
        {
        float targetX = Mathf.Lerp(minX, maxX, movementSlider.value);
       
        Vector2 newPosition = new Vector2(targetX, transform.position.y);
        playerBody2D.MovePosition(newPosition);


        }else if(autoMode == true)
        {
            float targetBall = FindObjectOfType<Ball>().transform.position.x;

            Vector2 newPosition = new Vector2(targetBall, transform.position.y);

            playerBody2D.MovePosition(newPosition);

        }
        


        //PARA MOVER AL PLAYER CON LAS FLECHITAS

        //inputValue = Input.GetAxisRaw("Horizontal");

        //if(inputValue == 1)
        //{

        //    direction = Vector2.right;

        //}else if(inputValue == -1)
        //{

        //    direction = Vector2.left;
        //}
        //else
        //{
        //    direction = Vector2.zero;
        //}

        //playerBody2D.AddForce(direction * moveSpeed * Time.deltaTime * 100);

    }

    public void ResetPlayer()
    {
        transform.position = startPosition;
        playerBody2D.velocity = Vector2.zero;
    }

    public void AutoMode()
    {

        autoMode = !autoMode;

    }
}

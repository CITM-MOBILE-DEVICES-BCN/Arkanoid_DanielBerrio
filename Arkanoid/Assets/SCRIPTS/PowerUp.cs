using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    Vector3 resize ;
    Vector3 oldsize;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {

            Destroy(gameObject);     

        }

        if (collision.gameObject.CompareTag("Player"))
        {

            MakeItBig();

            Destroy(gameObject);

        }

    }

    public void MakeItBig()
    {
        oldsize = FindObjectOfType<Player>().transform.localScale;

        resize.x = 5.0f;
        resize.y = 0.25f;
        resize.z = 0.5f;

        FindObjectOfType<Player>().transform.localScale = resize; 

    }
}

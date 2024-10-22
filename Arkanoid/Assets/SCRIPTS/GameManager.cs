using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

   [SerializeField] public int lives = 3;
    [SerializeField] public int points = 0;
    [SerializeField] public int record = 0;

    public Text livestext;
    public Text pointstext;
    public Text hightext;

    public void LoseHealth()
    {

        lives--;
        ActualizarTexto();



        if (lives <= 0)
        {

            SceneManager.LoadScene("GameOver");

        }
        else
        {

            ResetLevel();

        }

    }

    public void MorePuntuation()
    {
        //SUMAR PUNTOS
        points += 100;

        

        //CAMBIAR LA MAXIMA
       if(record <= points)
        {

            record = points;
            ActualizarHigh();
            Debug.Log("HIGHSCORE " +record);

        }
        
            
            
        

        //REESCRIBIR UI
        ActualizarPuntos();       
    }


    public void ResetLevel()
    {

        FindObjectOfType<Ball>().ResetBall();
        FindObjectOfType<Player>().ResetPlayer();

    }

    public void CheckLevelCompleted()
    {

        Debug.Log("Tamo en Levcel compelted");

        if (transform.childCount <= 1)                      
        {
            Debug.Log("Los has matao");

            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Level1");
            }

        }

    }

    public void ActualizarTexto()
    {
        // Asigna el valor de la variable "Lives" al texto de la UI
        livestext.text = "x" + lives.ToString();
    }

    public void ActualizarPuntos()
    {
        // Asigna el valor de la variable "Lives" al texto de la UI
        pointstext.text = "Current "+ points.ToString();
    }
    public void ActualizarHigh()
    {
        // Asigna el valor de la variable "Lives" al texto de la UI
        hightext.text = "HighScore " + record.ToString();
    }

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int lives = 3;
    public int points = 0;
    public int newHigh;

    public Text livestext;
    public Text pointstext;

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
        if(newHigh < points)
        {
            newHigh = points;
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

        if (transform.childCount <= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        pointstext.text = "HighScore " + newHigh.ToString();
    }

  
}

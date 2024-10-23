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

    public bool winlvl = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoseHealth()
    {

        lives--;
        
        FindObjectOfType<TextManager>().ActualizarTexto();


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
            FindObjectOfType<TextManager>().ActualizarHigh();
            Debug.Log("HIGHSCORE " +record);

        }





        //REESCRIBIR UI
        FindObjectOfType<TextManager>().ActualizarPuntos(); 
        
           

        
        
               
    }


    public void ResetLevel()
    {

        FindObjectOfType<Ball>().ResetBall();
        FindObjectOfType<Player>().ResetPlayer();

    }

    public void CheckLevelCompleted()
    {

        Debug.Log("comprobamo en Levcel compelted");

        if (winlvl == true)
        {
            Debug.Log("Cambiemos de nivel");

            if (SceneManager.GetActiveScene().name == "Level1")
            {
                //FindObjectOfType<JsonSerializer>().SerializePlayerData();
                winlvl = false;
                SceneManager.LoadScene("Level2");

            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                winlvl = false;
                SceneManager.LoadScene("Level1");
            }
            
        }      

    }

  
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int lives = 3;
    public int points = 0;
    public int record = 0;

    public bool winlvl = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Intentar cargar los datos del archivo JSON
        JsonSerializer jsonSerializer = FindObjectOfType<JsonSerializer>();

        if (jsonSerializer != null)
        {
            jsonSerializer.DeSerializePlayerData();  // Carga los datos guardados

            // Si hay datos cargados, asignar el highscore
            if (jsonSerializer.facts != null)
            {
                record = jsonSerializer.facts.highScore;
                Debug.Log("Highscore cargado: " + record);
            }
            else
            {
                Debug.Log("No se ha encontrado un archivo JSON con highscore.");
            }
        }
        else
        {
            Debug.LogError("No se encontró JsonSerializer en la escena.");
        }
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
            
            Debug.Log("HIGHSCORE " +record);

        }





        //REESCRIBIR UI
        FindObjectOfType<TextManager>().ActualizarPuntos();
        FindObjectOfType<TextManager>().ActualizarHigh();




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
                Debug.Log("Volvemo al primero");
            }
            
        }      

    }

  
}

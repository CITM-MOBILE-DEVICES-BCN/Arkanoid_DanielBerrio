using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool isPaused = false; // Para verificar si el juego está pausado

    void Update()
    {
        // Detecta cuando se presiona la tecla Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }


    }

     void PauseGame()
    {
        // Pausar el juego
        Time.timeScale = 0f; // Detiene el tiempo
        isPaused = true;

        // Cambia a la escena del menú de pausa
        // Asegúrate de tener la escena en el "Build Settings"
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive); // Cargar de manera aditiva
    }

    public void ResumeGame()
    {
        // Reanudar el juego
        Time.timeScale = 1f; // Vuelve el tiempo a la normalidad
        isPaused = false;

        // Cierra la escena del menú de pausa
        SceneManager.UnloadSceneAsync("PauseMenu");
    }

    public void BacktoMenu()
    {
        
       
        SceneManager.UnloadSceneAsync("PauseMenu");
        SceneManager.LoadScene("MainMenu");

    }
    public void Exit()
    {
        // Si estamos en el editor de Unity, para detener el juego
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Para salir del juego en una build
        Application.Quit();
#endif
    }
}
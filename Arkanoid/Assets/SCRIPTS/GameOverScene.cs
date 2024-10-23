using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{

    string filePath;
    private void Awake()
    {
        filePath = Application.persistentDataPath + "/setting.json";
    }
    public void ResetGame()
    {

        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f; // Vuelve el tiempo a la normalidadw

    }

    public void StartGame()
    {

        SceneManager.LoadScene("Level1");
        FindObjectOfType<GameManager>().points = 0;
        
        Time.timeScale = 1f; // Vuelve el tiempo a la normalidadw

    }

}

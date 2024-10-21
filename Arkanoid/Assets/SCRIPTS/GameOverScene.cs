using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
   
    public void ResetGame()
    {

        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f; // Vuelve el tiempo a la normalidadw

    }

}

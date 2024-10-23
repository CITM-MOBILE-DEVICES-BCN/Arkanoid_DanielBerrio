using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class JsonSerializer : MonoBehaviour
{
   

    [System.Serializable]

    public class PlayerData
    {
        public int  currentScore;
        public int highScore;
        public int lives;
        public string scena;
    }

    string filePath;
    private void Awake()
    {
        filePath = Application.persistentDataPath + "/setting.json";
    }

    public PlayerData facts = new PlayerData();
        public void SerializePlayerData()
        {           

            facts.highScore = FindObjectOfType<GameManager>().record;
            facts.currentScore = FindObjectOfType<GameManager>().points;
            facts.lives = FindObjectOfType<GameManager>().lives;
            facts.scena = SceneManager.GetActiveScene().name;

        string json = JsonUtility.ToJson(facts);
        

            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);

        Debug.Log(loadedData);

    }
       
        public void DeSerializePlayerData()
        {
            // Asegúrate de que el archivo JSON realmente existe y contiene datos válidos
            string json = PlayerPrefs.GetString("PlayerData", "");  // O carga desde un archivo

            if (!string.IsNullOrEmpty(json))
            {
                PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);

                SceneManager.LoadScene(loadedData.scena);

                GameManager gameManager = FindObjectOfType<GameManager>();
                if (gameManager != null)
                {
                    gameManager.record = loadedData.highScore;
                    gameManager.points = loadedData.currentScore;
                    gameManager.lives = loadedData.lives;
                }
                else
                {
                    Debug.LogError("GameManager not found in the scene!");
                }
            }
            else
            {
                Debug.LogError("No saved data found!");
            }
        }

    

    
}



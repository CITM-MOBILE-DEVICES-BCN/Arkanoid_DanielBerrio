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

    string comprobar;
    string filePath;
    private void Awake()
    {
        filePath = Application.dataPath + "/SavedFiles/setting.json";

        // Crea la carpeta "SavedFiles" si no existe
        if (!System.IO.Directory.Exists(Application.dataPath + "/SavedFiles"))
        {
            System.IO.Directory.CreateDirectory(Application.dataPath + "/SavedFiles");
        }
    }

    public PlayerData facts;
        public void SerializePlayerData()
        {           

            facts.highScore = FindObjectOfType<GameManager>().record;
            facts.currentScore = FindObjectOfType<GameManager>().points;
            facts.lives = FindObjectOfType<GameManager>().lives;
            facts.scena = SceneManager.GetActiveScene().name;
       

        JsonUtility.ToJson(facts);
        string json = JsonUtility.ToJson(facts);   

            

        System.IO.File.WriteAllText(filePath, json);

       
        Debug.Log(json);
        Debug.Log("JSON saved at: " + filePath);

    }

    public void DeSerializePlayerData()
    {
        if (System.IO.File.Exists(filePath))
        {


            string json = System.IO.File.ReadAllText(filePath);
           
            Debug.Log("Loaded JSON: " + json);  // Verifica que los datos sean correctos

            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);

            // Verificar si el archivo existe
            
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
            Time.timeScale = 1.0f;  
        }
        else
        {
            Debug.LogError("No saved data found!");
        }
    }




}



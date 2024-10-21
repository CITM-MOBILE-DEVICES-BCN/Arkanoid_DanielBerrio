using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonSerializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {

    }

    [System.Serializable]

    public class PlayerData
    {
        public int highScore;
        public int currentScore;
    }

    public class TestSerialization
    {
        public void SerializePlayerData()
        {
            PlayerData facts = new PlayerData();

            facts.highScore = 0;
            facts.currentScore = 0;

            string json = JsonUtility.ToJson(facts);
            Debug.Log(json);

            PlayerData loadedData = JsonUtility.FromJson<PlayerData>(json);

            //highScore = loadedData.highScore;
            //currentScore = loadedData.currentScore;

            Debug.Log("HIGH" + loadedData.highScore + "CURRENT" + loadedData.currentScore);

        }

    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrickManager : MonoBehaviour
{
    
      
    public void Update()
    {  
        if (transform.childCount <= 0)                      
        {
            Debug.Log("Los has matao");

            FindObjectOfType<GameManager>().winlvl = true;
            FindObjectOfType<GameManager>().CheckLevelCompleted();
            
       
    
        }else
        {
            FindObjectOfType<GameManager>().winlvl = false;
        }
    }

        
    
}

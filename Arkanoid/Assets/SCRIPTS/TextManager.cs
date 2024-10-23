using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    public Text livestext;
    public Text pointstext;
    public Text hightext;

    // Start is called before the first frame update
    public void ActualizarTexto()
    {
        // Asigna el valor de la variable "Lives" al texto de la UI
        livestext.text = "x" + FindObjectOfType<GameManager>().lives.ToString();
    }

    public void ActualizarPuntos()
    {
        // Asigna el valor de la variable "Lives" al texto de la UI
        pointstext.text = "Current "+ FindObjectOfType<GameManager>().points.ToString();
    }
    public void ActualizarHigh()
    {
        // Asigna el valor de la variable "Lives" al texto de la UI
        hightext.text = "HighScore " + FindObjectOfType<GameManager>().record.ToString();
    }

}

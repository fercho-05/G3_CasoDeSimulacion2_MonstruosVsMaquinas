using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI mensajeText;

    string mensaje = "";


    void Update()
    {
        if (mensajeText != null)
        {
            mensaje = "Derrotaste " + StateManager.Instance.getCantidadEnemigosDerrotados().ToString() + " enemigos";
            mensajeText.text = mensaje;
        }
    }
    public void Inicio()
    {
        LevelManager.Instance.FirstScene();
    }
}

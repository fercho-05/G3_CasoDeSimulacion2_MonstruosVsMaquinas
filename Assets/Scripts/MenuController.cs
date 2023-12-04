using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void Creditos()
    {
        LevelManager.Instance.LastScene();
    }


    public void IniciarJuego()
    {
        LevelManager.Instance.NextScene();
    }
}

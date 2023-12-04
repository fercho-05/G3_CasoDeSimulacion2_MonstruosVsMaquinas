using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public void Inicio()
    {
        LevelManager.Instance.FirstScene();
    }
}

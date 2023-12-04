using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryController : MonoBehaviour
{
    public void Inicio()
    {
        LevelManager.Instance.FirstScene();
    }



}
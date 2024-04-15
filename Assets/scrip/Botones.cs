using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public void opciones(){
        SceneManager.LoadScene(2);
    }
    public void simulador(){
        SceneManager.LoadScene(1);
    }
    public void menu(){
        SceneManager.LoadScene(0);
    }
    public void salirSimulador(){
        Application.Quit();
    }
}

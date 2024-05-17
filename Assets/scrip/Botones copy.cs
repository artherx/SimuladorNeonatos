using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones2 : MonoBehaviour
{
    public GameObject op;
    public GameObject men;
    public void opciones1(){
        op.SetActive(true);
        men.SetActive(false);
    }
    public void menu1(){
        op.SetActive(false);
        men.SetActive(true);
    }
}

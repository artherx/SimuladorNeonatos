using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class wordButtom : MonoBehaviour
{
    
    public GameObject getUI;

    public void ToggleObjeto()
    {
        // Comprobar si el objeto está activo y desactivarlo, o viceversa
        getUI.SetActive(!getUI.activeSelf);
    }
    
}

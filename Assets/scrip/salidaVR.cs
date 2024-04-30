using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salidaVR : MonoBehaviour
{
    private bool verdad = false;
    public GameObject canva;
    public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        canva.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
            Debug.Log("Ha ebtrado pero raro");
        if (other.gameObject == jugador)
        {
            Debug.Log("Ha ebtrado");
            canva.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == jugador)
        {
            canva.SetActive(false);
        }
    }
}

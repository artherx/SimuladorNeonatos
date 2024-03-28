using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salida : MonoBehaviour
{
    private bool verdad = false;
    private Canvas canva;
    public GameObject jugador;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        canva = GetComponentInChildren<Canvas>();
        canva.enabled=false;
        pos = jugador.transform.position;
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject==jugador)
            verdad = true;
    }
    // Update is called once per frame
    public void cancelar(){
        verdad = false;
        canva.enabled = false;
        Cursor.visible=false;
        Cursor.lockState = CursorLockMode.Locked;
        jugador.transform.position = pos;

        Component[] scriptsJugador = jugador.GetComponentsInChildren<Component>();
    
                // Iterar a través de los scripts obtenidos
                foreach (Component script in scriptsJugador)
                {
                    // Desactivar el script si no es un componente transform
                    if (!(script is Transform))
                    {
                        MonoBehaviour behaviour = script as MonoBehaviour;
                        if (behaviour != null)
                        {
                            behaviour.enabled = true;
                        }
                    }
                }
    }
    void Update()
    {
        if(canva==null)
            Debug.LogError("No se encontró el componente TextMesh como hijo del cubo.");
        if(verdad){
            Cursor.visible=true;
            Cursor.lockState = CursorLockMode.None;
            if(!canva.enabled){
                canva.enabled = true;    
            }
            if (jugador != null)
            {
                // Obtener todos los scripts adjuntos al objeto jugador y sus hijos
                Component[] scriptsJugador = jugador.GetComponentsInChildren<Component>();
    
                // Iterar a través de los scripts obtenidos
                foreach (Component script in scriptsJugador)
                {
                    // Desactivar el script si no es un componente transform
                    if (!(script is Transform))
                    {
                        MonoBehaviour behaviour = script as MonoBehaviour;
                        if (behaviour != null)
                        {
                            behaviour.enabled = false;
                        }
                    }
                }
            }
        }
    }
}

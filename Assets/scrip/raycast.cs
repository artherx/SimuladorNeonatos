using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    public GameObject objetoASeguir;
    public Camera cam;
    private bool oprimir;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            oprimir = true;
        if(Input.GetMouseButtonUp(0))
            oprimir = false;

        // Si el raycast golpea un objeto y se está oprimiendo el botón
        if (oprimir)
        {
            // Obtener la dirección de la mirada de la cámara
            Vector3 direccionMirada = cam.transform.forward;

            RaycastHit[] hits;
            hits = Physics.RaycastAll(cam.transform.position, direccionMirada, Mathf.Infinity);

            // Realizar el raycast desde la posición de la cámara hacia adelante
            for(int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                if(hit.collider.gameObject.CompareTag("baby"))
                {
                    // Obtener la normal de la superficie golpeada
                    Vector3 normalSuperficie = hit.normal;

                    // Calcular la rotación para alinear la parte más larga del objeto con la normal de la superficie
                    Vector3 ejeYObjeto = objetoASeguir.transform.up;
                    Quaternion rotacionObjeto = Quaternion.LookRotation(normalSuperficie, ejeYObjeto);
                    objetoASeguir.transform.rotation = rotacionObjeto;
                    
                    // Mover el objeto que sigue a la posición impactada por el raycast
                    objetoASeguir.transform.position = hit.point;
                    break; // Salir del bucle una vez que se haya encontrado un objeto "baby"
                }
            }
        }
    }
}

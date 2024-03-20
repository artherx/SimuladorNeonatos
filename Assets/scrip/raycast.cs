using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public GameObject objetoASeguir;
    public Camera cam;
    private bool oprimir;

    private Rigidbody rb;

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

            RaycastHit hit;
            int capaGolf = LayerMask.GetMask("golf");
            int capaColoso = LayerMask.GetMask("coloso");
            int capasAExcluir = capaGolf | capaColoso;

            // Realizar el raycast desde la posición de la cámara hacia adelante
            if (Physics.Raycast(cam.transform.position, direccionMirada, out hit, Mathf.Infinity, ~capasAExcluir) && hit.collider.gameObject.CompareTag("baby"))
            {
                // Obtener la normal de la superficie golpeada
                Vector3 normalSuperficie = hit.normal;
    
                // Actualizar el estado de la variable oprimir
                // Calcular la rotación para alinear la parte más larga del objeto con la normal de la superficie
                Vector3 ejeYObjeto = objetoASeguir.transform.up;
                Vector3 superficie = Vector3.Cross(normalSuperficie, ejeYObjeto);
                Quaternion rotacionObjeto = Quaternion.LookRotation(normalSuperficie, ejeYObjeto);
                objetoASeguir.transform.rotation = rotacionObjeto;
                
                // Mover el objeto que sigue a la posición impactada por el raycast
                objetoASeguir.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
        }
    }

}

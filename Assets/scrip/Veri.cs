using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veri : MonoBehaviour
{
    private int cubo;
    public GameObject[] cubos;
    private void Start() {
        cubo = 0;
    }

    public int getCubo(){
        return cubo;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("coli"))
        {
            Debug.Log("El objeto 'coli' ha entrado en el trigger.");
            for(int i=0; i<cubos.Length;i++){
                if(cubos[i].name==other.gameObject.name)
                    cubo=i+1;
            }
            Debug.Log("es "+ other.name+" numero: "+cubo);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("coli"))
        {
            Debug.Log("Ha salido");
            cubo = 0;
            Debug.Log("es "+ other.name+" numero: "+cubo);
        }
    }
}

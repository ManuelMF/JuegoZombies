using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambioSpawner : MonoBehaviour
{
    public GameObject spawnerAntiguo;
    private Spawner spawnerAntScript;
    public GameObject spawnerNuevo;
    private Spawner spawnerNewScript;
    private bool primeraRepeticion;

    // Start is called before the first frame update
    void Start()
    {
        spawnerAntScript = spawnerAntiguo.GetComponent<Spawner>();
        spawnerNewScript = spawnerNuevo.GetComponent<Spawner>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        //al salir de una zona se desactiva ese spawn y se activa el de la zona donde entramos
        if (primeraRepeticion)
        {
            primeraRepeticion = false;
            if (spawnerAntScript.activar)
            {
                spawnerAntScript.activar = false;
                spawnerAntScript.cancelarSpwaner();
                spawnerNewScript.activar = true;
                spawnerNewScript.activado = false;
            }

            else if (spawnerNewScript.activado)
            {
                spawnerNewScript.activar = false;
                spawnerNewScript.cancelarSpwaner();
                spawnerAntScript.activar = true;
                spawnerAntScript.activado = false;

            }
        }
        else primeraRepeticion = true;
        
       
    }
    
    private void OnCollisionExit(Collision collision)
    {
        
    }
}

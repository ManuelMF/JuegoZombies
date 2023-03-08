using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class recargarInterac : MonoBehaviour
{
    public TMP_Text TextAbrirPuerta;
    public GameObject textAbrirPuertaa;

    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //entramos en el campo de interacion de la municion
        if (other.gameObject.tag == "ammunition")
        {
            TextAbrirPuerta.SetText("Pulsa E para comprar municion coste: 500 €");
            textAbrirPuertaa.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //salimos del campo de interaccion
        if (other.gameObject.tag == "ammunition")
        {
            textAbrirPuertaa.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //nos mantenemos y si pulsamos e compramos
        if (other.gameObject.tag == "ammunition")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                municion scriptMunicion = other.gameObject.GetComponent<municion>();
                scriptMunicion.Recargar();
            }
        }
    }
}

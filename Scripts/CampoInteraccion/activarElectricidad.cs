using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class activarElectricidad : MonoBehaviour
{
    private bool ele1 = false;
    private bool ele2 = false;
    private bool ele3 = false;
    private bool eleActiva = false;

    private bool ventajaTitan = false;
    private bool ventajax2Danyo = false;
    private bool ventajaRecargaRapida = false;
    private bool ventajaRapidez = false;

    public TMP_Text TextAbrirPuerta;
    public GameObject textAbrirPuertaa;
    private GameObject Player;
    private Player ScriptPlayer;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        ScriptPlayer = Player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //entramos a un punto de electricidad o ventaja
        
        if (other.gameObject.tag == "Electricidad1" && ele1 == false)
        {
            TextAbrirPuerta.SetText("Pulsa E para activar el puerto de electricidad Este ");
            textAbrirPuertaa.SetActive(true);
        }
        if (other.gameObject.tag == "Electricidad2" && ele2 == false)
        {
            TextAbrirPuerta.SetText("Pulsa E para activar el puerto de electricidad Cental ");
            textAbrirPuertaa.SetActive(true);
        }
        if (other.gameObject.tag == "Electricidad3" && ele3 == false)
        {
            TextAbrirPuerta.SetText("Pulsa E para activar el puerto de electricidad Oeste ");
            textAbrirPuertaa.SetActive(true);
        }
        //eletricidad general una vez activada podemos tomar ventajas
        if (other.gameObject.tag == "ElectricidadActivar")
        {
            if (ele1 == true && ele2 == true && ele3 == true)
            {
                TextAbrirPuerta.SetText("Pulsa E para activar la electricidad ");
                textAbrirPuertaa.SetActive(true);
            }
            else
            {
                TextAbrirPuerta.SetText("Tienes que activar los diferentes puertos para activar la electricidad");
                textAbrirPuertaa.SetActive(true);
            }
           
        }
        //cuando entra una ventaja
        if (other.gameObject.tag == "ventajaTitan" && eleActiva == true && ventajaTitan == false)
        {
            TextAbrirPuerta.SetText("Ventaja Titan coste 2400€");
            textAbrirPuertaa.SetActive(true);
        } else if (other.gameObject.tag == "ventajaTitan" && eleActiva == false && ventajaTitan == false)
        {
            TextAbrirPuerta.SetText("Activa la electricidad para comprar ventajas");
            textAbrirPuertaa.SetActive(true);
        }
        if (other.gameObject.tag == "ventajaRapidez" && eleActiva == true && ventajaRapidez == false)
        {
            TextAbrirPuerta.SetText("Ventaja Recarga Rapida coste 2000€");
            textAbrirPuertaa.SetActive(true);
        } else if (other.gameObject.tag == "ventajaRapidez" && eleActiva == false && ventajaRapidez == false)
        {
            TextAbrirPuerta.SetText("Ventaja correr mas coste 2200€");
            textAbrirPuertaa.SetActive(true);
        }
        if (other.gameObject.tag == "ventajax2danyo" && eleActiva == true && ventajax2Danyo == false)
        {
            TextAbrirPuerta.SetText("Ventaja Daño x2 coste 2200€");
            textAbrirPuertaa.SetActive(true);
        } else if (other.gameObject.tag == "ventajax2danyo" && eleActiva == false && ventajax2Danyo == false)
        {
            TextAbrirPuerta.SetText("Activa la electricidad para comprar ventajas");
            textAbrirPuertaa.SetActive(true);
        }
        if (other.gameObject.tag == "ventajaRecarga" && eleActiva == true)
        {
            TextAbrirPuerta.SetText("Ventaja Recarga Rapida coste 3000€");
            textAbrirPuertaa.SetActive(true);
        } else if (other.gameObject.tag == "ventajaRecarga" && eleActiva == false)
        {
            TextAbrirPuerta.SetText("Activa la electricidad para comprar ventajas");
            textAbrirPuertaa.SetActive(true);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        //al mantenernos dentro de una ventaja o un campo electrico
        if (other.gameObject.tag == "Electricidad1" && ele1 == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ele1 = true;
                textAbrirPuertaa.SetActive(false);
            }
        }
        if (other.gameObject.tag == "Electricidad2" && ele2 == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ele2 = true;
                textAbrirPuertaa.SetActive(false);
            }
        }
        if (other.gameObject.tag == "Electricidad3" && ele3 == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ele3 = true;
                textAbrirPuertaa.SetActive(false);
            }
        }
        if (other.gameObject.tag == "ElectricidadActivar" && ele1 == true && ele2 == true && ele3 == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            { 
                textAbrirPuertaa.SetActive(false);
                eleActiva = true;
            }
        }
        //aumenta vida
        if (other.gameObject.tag == "ventajaTitan" && ventajaTitan == false)
        {
            GameObject Ventaja = other.gameObject;
            Ventaja scriptVentaja = Ventaja.GetComponent<Ventaja>();
            if (ventajaTitan == false && ScriptPlayer.score >= scriptVentaja.Precio && Input.GetKeyDown(KeyCode.E))
            {
                textAbrirPuertaa.SetActive(false);
                ventajaTitan = true;
                scriptVentaja.EjecutarVentaja();
            }
        }
        //corremos mas
        if (other.gameObject.tag == "ventajaRapidez" && ventajaRapidez == false)
        {
            GameObject Ventaja = other.gameObject;
            Ventaja scriptVentaja = Ventaja.GetComponent<Ventaja>();
            if (ventajaRapidez == false && ScriptPlayer.score >= scriptVentaja.Precio && Input.GetKeyDown(KeyCode.E))
            {
                textAbrirPuertaa.SetActive(false);
                ventajaRapidez = true;
                scriptVentaja.EjecutarVentaja();
            }
        }
        //hacemos mas daño
        if (other.gameObject.tag == "ventajax2danyo" && ventajax2Danyo == false)
        {
            GameObject Ventaja = other.gameObject;
            Ventaja scriptVentaja = Ventaja.GetComponent<Ventaja>();

            if (ventajax2Danyo == false && ScriptPlayer.score >= scriptVentaja.Precio && Input.GetKeyDown(KeyCode.E))
            {
                textAbrirPuertaa.SetActive(false);
                ventajax2Danyo = true;
                scriptVentaja.EjecutarVentaja();
            }
        }
        //recargamos mas rapido
        if (other.gameObject.tag == "ventajaRecarga" && ventajaRecargaRapida == false)
        {
            GameObject Ventaja = other.gameObject;
            Ventaja scriptVentaja = Ventaja.GetComponent<Ventaja>();

            if (ventajaRecargaRapida == false && ScriptPlayer.score >= scriptVentaja.Precio && Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.E))
            {
                textAbrirPuertaa.SetActive(false);
                ventajaRecargaRapida = true;
                scriptVentaja.EjecutarVentaja();
           }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //eliminamos el text
        if (other.gameObject.tag == "Electricidad1")
        {
            textAbrirPuertaa.SetActive(false);
        }
        if (other.gameObject.tag == "Electricidad2")
        {
            textAbrirPuertaa.SetActive(false);
        }
        if (other.gameObject.tag == "Electricidad3")
        {
            textAbrirPuertaa.SetActive(false);
        }
        if (other.gameObject.tag == "ElectricidadActivar")
        {
            textAbrirPuertaa.SetActive(false);
        }
        if (other.gameObject.tag == "ventajaTitan")
        {
            
            textAbrirPuertaa.SetActive(false);
        }
        if (other.gameObject.tag == "ventajaRapidez")
        {
            textAbrirPuertaa.SetActive(false);
        }
        if (other.gameObject.tag == "ventajax2danyo")
        {
            textAbrirPuertaa.SetActive(false);
        }
        if (other.gameObject.tag == "ventajaRecarga")
        {
            textAbrirPuertaa.SetActive(false);
        }
        //textAbrirPuertaa.SetActive(false);
    }
}

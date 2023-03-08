using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EliminarPuerta : MonoBehaviour
{
    private GameObject Player;
    private Player ScriptPlayer;
    public TMP_Text TextAbrirPuerta;
    public GameObject textAbrirPuertaa;

    private GameObject GameManager;
    private GameManager ScriptGameManager;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        ScriptPlayer = Player.GetComponent<Player>();

        GameManager = GameObject.FindGameObjectWithTag("GameController");
        ScriptGameManager = GameManager.GetComponent<GameManager>();
        
    }

    private void OnTriggerStay(Collider other)
    {
        //cargamos texto
        if (other.gameObject.tag == "Puerta")
        {
            GameObject Puerta = other.gameObject;
            Puerta scriptPuerta = Puerta.GetComponent<Puerta>();
            if (Input.GetKeyDown(KeyCode.E) && ScriptPlayer.score >= scriptPuerta.scoreNecesario)
            {
                ScriptPlayer.score -= scriptPuerta.scoreNecesario;
                Destroy(other.gameObject);
                textAbrirPuertaa.SetActive(false);
                ScriptGameManager.SetScore(ScriptPlayer.score);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //txto de la puerta 
        if (other.gameObject.tag == "Puerta")
        {
            GameObject Puerta = other.gameObject;
            Puerta scriptPuerta = Puerta.GetComponent<Puerta>();

            TextAbrirPuerta.SetText("Pulsa E para abrir  Coste " + scriptPuerta.scoreNecesario + " € ");
            textAbrirPuertaa.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //eliminamos texto
        if (other.gameObject.tag == "Puerta")
        {
            textAbrirPuertaa.SetActive(false);
        }
    }

    private void Update()
    {
       
    }
}
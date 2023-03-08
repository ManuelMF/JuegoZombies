using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventaja : MonoBehaviour
{
    public string Nombre;
    public int Precio;

    private GameObject Player;
    private Player ScriptPlayer;
    private GameObject GameManager;
    private GameManager ScriptGameManager;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        ScriptPlayer = Player.GetComponent<Player>();

        GameManager = GameObject.FindGameObjectWithTag("GameController");
        ScriptGameManager = GameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EjecutarVentaja()
    {
        // lo que sucede cuando compramos una ventaja
        if (Nombre == "Titan")
        {
            ScriptPlayer.maxheald *= 2;
            ScriptGameManager.SetScore(ScriptPlayer.score-Precio);
        }
        if (Nombre == "Speed Cola")
        {
            ScriptPlayer.tiempoRecarga /= 2;
            ScriptGameManager.SetScore(ScriptPlayer.score - Precio);
        }
        if (Nombre == "Double Tap")
        {
            ScriptPlayer.danyoStandard *= 2;
            ScriptGameManager.SetScore(ScriptPlayer.score - Precio);
        }
        if (Nombre == "Stamin Up")
        {
            ScriptPlayer.velocidad *= 2;
            ScriptGameManager.SetScore(ScriptPlayer.score - Precio);
        }

    }
}

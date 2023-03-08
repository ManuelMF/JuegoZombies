using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text municion;
    public TMP_Text municionActual;
    private GameObject Player;
    private Player ScriptPlayer;
    private bool pausar = false;
    public bool heridaActive = false;
    public GameObject herida;
    public GameObject muyHerido;

    private float secondsCounter = 0;
    private float secondsToCount = 1;
    private int number = 0;

    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");
        ScriptPlayer = Player.GetComponent<Player>();

        score.text = ScriptPlayer.score + "";
    }

    // Update is called once per frame
    void Update()
    {
        //carga el menu de pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenuPause();
        }
        //mira si la vida es inferior al 30%
        if (ScriptPlayer.heald < ScriptPlayer.maxheald * 0.3)
        {
            muyHerido.SetActive(true);
        }else muyHerido.SetActive(false);

        if (ScriptPlayer.heald <= 0) muerte();
        //contamos x segundos para quitar herida
        if (heridaActive)
        {
            herida.SetActive(true);
            secondsCounter += Time.deltaTime;

            

            // si llega a un segundo entra y se pone en 0 
            if (secondsCounter >= secondsToCount)
            {
                secondsCounter = 0;
                number++;
                // si llega a 4 segundos quitas la herida
                if (number == 4)
                {
                    herida.SetActive(false);
                    number = 0;
                    heridaActive = false;
                }
            }
        }
    }

    public void SetScore(int valor)
    {
        score.text = valor + "";
        ScriptPlayer.score = valor;
    }

    public void SetMunicion(int municionActu, int municiontotal)
    {
        municionActual.text = municionActu + "";
        municion.text = municiontotal + "";
    }

    public void muerte()
    {
        Time.timeScale = 0f;
        OpenDieMenu();
    }

    public void OpenMenuPause()
    {
        //pausa el juego
        if (pausar == false)
        {
            //panelPausa.SetActive(true);
            Time.timeScale = 0f;
            pausar = true;
        }
        else
        {
            //panelPausa.SetActive(false);
            Time.timeScale = 1f;
            pausar = false;
        }
    }

    public void CloseMenuPause()
    {

    }

    public void OpenDieMenu()
    {
        SceneManager.LoadScene("dieMenu");
    }
    
    public void OpenWinMenu()
    {
        SceneManager.LoadScene("winMenu");
    }
}

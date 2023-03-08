using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public Transform[] ArrayPosiciones;
    public bool activar;
    public bool activado;
    public GameObject enemy;
    private GameObject Ronda;
    private Ronda ScriptRonda;
    public int tiempoRespawn;
    public TMP_Text TextRonda;
    private GameObject GameManager;
    private GameManager ScriptGameManager;

    void Start()
    {
        Ronda = GameObject.FindGameObjectWithTag("Ronda");
        ScriptRonda = Ronda.GetComponent<Ronda>();
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        ScriptGameManager = GameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //activar es para que se active y activado mira si ya esta activado
        if (activar && activado == false)
        {
            activado = true;
            //respawena
            InvokeRepeating("CrearEnemy", 0, tiempoRespawn);

        }
        //si no quedan enemigos y activar es true cancelas el spawn
        if(ScriptRonda.NEnemigos == 0 && activar)
        {
           
            CancelInvoke("CrearEnemy");

            //si no hay enemigos pasa de ronda y aumenta el nimero de enemigos base 
            if (!GameObject.FindGameObjectWithTag("Enemy"))
            {
                activado = false;
                ScriptRonda.NEnemigosBase =  ScriptRonda.NEnemigosBase + (int)(ScriptRonda.NEnemigosBase * (20f / 100f));

                ScriptRonda.ronda++;
                //win
                if (ScriptRonda.ronda == 21) ScriptGameManager.OpenWinMenu();

                TextRonda.SetText(ScriptRonda.ronda+"");
                ScriptRonda.NEnemigos = ScriptRonda.NEnemigosBase;
            }
           
        }
    }
    // crea un enemigo en una posicion del spawner actual 
    public void CrearEnemy()
    {
        ScriptRonda.NEnemigos--;

        int num = Random.Range(0, 3);

        Instantiate(enemy, ArrayPosiciones[num].transform.localPosition, transform.rotation);
    }
    //cancela spawn
    public void cancelarSpwaner()
    {
        CancelInvoke("CrearEnemy");
    }
}

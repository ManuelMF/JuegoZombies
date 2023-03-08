using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaAk : MonoBehaviour
{
    public int municion;
    public int municionMaxima;
    public int municionDentro;
    public int municionDentroCapacidadMax;
    public int danyo;
    public float tiempoRecarga;
    public float cadencia;
    private GameObject GameManager;
    private GameManager ScriptGameManager;
    private Animator anim;
    public GameObject AnimGO;
    public bool recargaFin;

    void Start()
    {
        recargaFin = true;
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        ScriptGameManager = GameManager.GetComponent<GameManager>();

        anim = AnimGO.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            recargaFin = false;
            //recargamos
            if (municion > municionDentroCapacidadMax && municionDentro != municionDentroCapacidadMax)
            {
                municionDentro = municionDentroCapacidadMax;
                municion -= municionDentroCapacidadMax;
                // se comenta para ya que se ejecuta en un script de la municion donde se pone la municion al acabar la animacion
                //ScriptGameManager.SetMunicion(municionDentro, municion);
                
                anim.SetTrigger("recargar");
           // se hacen los siguientes else para que funcione correctamente en todos los casos por ej 0/15 
            } else if(municion < municionDentroCapacidadMax && municion > 0)
            {
                municionDentro = municion;
                municion -= municion;
               // ScriptGameManager.SetMunicion(municionDentro, municion);
                anim.SetTrigger("recargar");
            } else if (municion > 0 && municionDentro != municionDentroCapacidadMax)
            {
                municionDentro = municion;
                municion -= municion;
               // ScriptGameManager.SetMunicion(municionDentro, municion);
                anim.SetTrigger("recargar");
            }
        }
        
    }
}

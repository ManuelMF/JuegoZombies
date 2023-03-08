using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int heald;
    public int maxheald;
    public int tiempoRecarga;
    public int danyoStandard;
    public int velocidad;
    public int shield;
    public int score;
    public float delayRegeneracion;
    private Animator anim;
    public GameObject AnimGO;

    void Start()
    {
        //regeneracion
        InvokeRepeating("Regeneracion", 0, delayRegeneracion);

        ///cargamos animator
        anim = AnimGO.GetComponent<Animator>();
    }

    void Update()
    {

        //cosas que hace al correr
        if ((Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S)) && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            //para que vuelta a la velocidad standar de las animaciones
            anim.speed = 1.0f;
            //activamos la animacion de correr
            anim.SetTrigger("correr");
            //sino andamos
        } else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
        {
            anim.speed = 1.0f;
            //activamos la animacion de andar
            anim.SetTrigger("caminar");
        }
        //parar de correr
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            anim.SetTrigger("dejar de correr"); 
        }
        if (anim.GetBool("correr") &&(!Input.GetKey(KeyCode.LeftShift))) anim.SetTrigger("dejar de correr");
    }
    //para que nos vayamos curando con el tiempo
    public void Regeneracion()
    {
        if (heald < maxheald)
        {
            heald += 10;
            if (heald > maxheald)
            {
                heald = maxheald;
            }
        }
    }
}

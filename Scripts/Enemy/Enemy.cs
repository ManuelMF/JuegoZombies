//using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject Player;
    private Player ScriptPlayer;
    private Transform TransformPlayer;
    public float velocidad;
    private Animator anim;
    public GameObject AnimGO;
    public int vida;
    public int danyo;
    public float delayGolpeo;
    private bool golpeando = false;
    public GameObject herida;
    private GameObject GameManager;
    private GameManager ScriptGameManager;
    public int scoreAlMorir;
    public int scoreAlDanyar;
    public bool muriendo = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        ScriptPlayer = Player.GetComponent<Player>();
        TransformPlayer = Player.transform;

        anim = AnimGO.GetComponent<Animator>();

        GameManager = GameObject.FindGameObjectWithTag("GameController");
        ScriptGameManager = GameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, TransformPlayer.position);
        if(distancia > 1.4)
        {
            //se mueva hacia a ti
            transform.LookAt(new Vector3(TransformPlayer.position.x, transform.position.y, TransformPlayer.position.z));
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(TransformPlayer.position.x, transform.position.y, TransformPlayer.position.z), velocidad * Time.deltaTime);
            //paramos el golpeo si estubiera activo
            anim.SetInteger("golpear", 0);
            CancelInvoke("Golpear");

            if (golpeando) golpeando = false;
        }  // para que si estas mueriendote y estas al lado no te golpee
        else if (muriendo == false)
        {
            //sino golpeamos 
            anim.SetInteger("golpear", 1);

            if (golpeando == false)
            {
                golpeando = true;
                InvokeRepeating("Golpear", 0, delayGolpeo);
            }
            
        }

    }
    //golpeo
    public void Golpear()
    {
        ScriptPlayer.heald -= danyo;
        ScriptGameManager.heridaActive = true;
    }
    /*
    public static implicit operator Enemy(GameObject v)
    {
        throw new NotImplementedException();
    }*/
    
    public void morir()
    {
        //muriendo true ya que cuando acabe la animacion se volvera false y se eliminará
        muriendo = true;
        // se ejecuta una animacion o otra
        int num = Random.Range(0, 2);
        anim.speed = 3.0f;
        if (num == 1) anim.SetTrigger("morir1");
         else anim.SetTrigger("morir2");
        //if (num == 1) anim.CrossFade("morir1", 0.2f);
        //else anim.CrossFade("morir2", 0.2f);
    }
}

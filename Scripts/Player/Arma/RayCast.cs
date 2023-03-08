using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RayCast : MonoBehaviour
{
    //public GameObject armaActual;
    public GameObject ArmaAk;
    private ArmaAk ScriptAk;
    private GameObject Player;
    private Player ScriptPlayer;
    private GameObject GameManager;
    private GameManager ScriptGameManager;
    private Animator anim;
    public GameObject AnimGO;
    public GameObject blood;
    GameObject audioBalaGo;
    audioAkDisparo audioControlScript;
    public GameObject explosion;

    //para ocultar la mask del raycast
    private int mask = 9;
    void Start()
    {
        ScriptAk = ArmaAk.GetComponent<ArmaAk>();
        Player = GameObject.FindGameObjectWithTag("Player");
        ScriptPlayer = Player.GetComponent<Player>();

        GameManager = GameObject.FindGameObjectWithTag("GameController");
        ScriptGameManager = GameManager.GetComponent<GameManager>();

        anim = AnimGO.GetComponent<Animator>();

        audioBalaGo = GameObject.FindGameObjectWithTag("AudioAk");
        audioControlScript = audioBalaGo.GetComponent<audioAkDisparo>();
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 50,mask))
        {
            Debug.Log(hit.point);
            Debug.DrawLine(transform.position, hit.point);
        }// disparo
        if (Input.GetMouseButtonDown(0) && ScriptAk.municionDentro > 0 && Time.timeScale != 0f && ScriptAk.recargaFin)
        {
            ScriptAk.municionDentro--;
            audioControlScript.AudioDisparar();
            GameObject ex = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(ex, 0.5f);

            //ajustamos la municion
            ScriptGameManager.SetMunicion(ScriptAk.municionDentro,ScriptAk.municion);
            anim.SetTrigger("disparar");

            //si golpeamos a un zombie
            if (hit.collider.tag == "Enemy")
            {
                GameObject zombieGO =  hit.collider.gameObject;
                Enemy zombie = zombieGO.GetComponent<Enemy>();

                //sangre ya que no se posicionaba bien donde se apunta se ajusto a mano
                Vector3 posicion = hit.point;
                posicion.y += 0.5f;
                GameObject objeto = Instantiate(blood, posicion, zombie.transform.rotation);
                Destroy(objeto, 0.5f);

                //quitamos vida
                zombie.vida -= ScriptAk.danyo * ScriptPlayer.danyoStandard;
                //aumentams score base de golpe
                ScriptGameManager.SetScore(ScriptPlayer.score + zombie.scoreAlDanyar);
                if (zombie.vida <= 0)
                {   
                    //muere
                    zombie.morir();
                    zombie.muriendo = true;
                    //aumentamos score muerte
                    ScriptGameManager.SetScore(ScriptPlayer.score + zombie.scoreAlMorir);
                }
            }
        }
    }
}

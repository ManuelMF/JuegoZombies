using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class municion : MonoBehaviour
{
    public int coste;
    private GameObject ArmaAk;
    private ArmaAk ScriptAk;
    private GameObject Player;
    private Player ScriptPlayer;
    public TMP_Text textAmmo;
    public TMP_Text textScore;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    

    public void Recargar()
    {
        ArmaAk = GameObject.FindGameObjectWithTag("AK");
        ScriptAk = ArmaAk.GetComponent<ArmaAk>();
        Player = GameObject.FindGameObjectWithTag("Player");
        ScriptPlayer = Player.GetComponent<Player>();
        // reyenamos municion y quitamos dinero
        ScriptPlayer.score -= coste;
        ScriptAk.municion = ScriptAk.municionMaxima;
        textScore.SetText(ScriptPlayer.score+"");
        textAmmo.SetText(ScriptAk.municion+"");
    }
}

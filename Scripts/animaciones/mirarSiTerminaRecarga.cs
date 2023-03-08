using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirarSiTerminaRecarga : StateMachineBehaviour
{
    private GameObject ArmaAk;
    private ArmaAk ScriptAk;
    private GameObject GameManager;
    private GameManager ScriptGameManager;

    GameObject audioBalaGo;
    audioAkDisparo audioControlScript;

    //al ejecutarse na anumacion 
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //metemos audio
        audioBalaGo = GameObject.FindGameObjectWithTag("AudioAk");
        audioControlScript = audioBalaGo.GetComponent<audioAkDisparo>();
        audioControlScript.AudioRecargar();
    }
    //al terminar la animacion
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //le decimos que acabo la recarga 
        ArmaAk = GameObject.FindGameObjectWithTag("AK");
        ScriptAk = ArmaAk.GetComponent<ArmaAk>();
        ScriptAk.recargaFin = true;

        // ponemos la municion
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        ScriptGameManager = GameManager.GetComponent<GameManager>();
        ScriptGameManager.SetMunicion(ScriptAk.municionDentro, ScriptAk.municion);
    }

}

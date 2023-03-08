using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraDisparo : MonoBehaviour
{
    public float shakeDuration = 0.1f;
    public float shakeMagnitude = 0.05f;
    public float dampingSpeed = 2.0f;

    private Vector3 initialPosition;
    private float shakeTimer = 0.0f;

    private GameObject ArmaAk;
    private ArmaAk ScriptAk;

    public float zoomAmount = 1f;
    public Camera camara;

    //codigo importado que hace un movimiento en la camara simulando un disparo 
    // se modificaron cosas 
    void Start()
    {
        initialPosition = transform.localPosition;

        ArmaAk = GameObject.FindGameObjectWithTag("AK");
        ScriptAk = ArmaAk.GetComponent<ArmaAk>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ScriptAk.municionDentro > 0 && Time.timeScale != 0f && ScriptAk.recargaFin)
        {
            ShakeCamera();
        }

        if (shakeTimer > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeTimer -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeTimer = 0f;
            transform.localPosition = initialPosition;
        }

        if (Input.GetMouseButtonDown(1)) //check if right mouse button is pressed
        {
            ZoomCamera(); //call zoom camera function
        }
    }

    void ShakeCamera()
    {
        shakeTimer = shakeDuration;
    }

    public void ZoomCamera()
    {
        zoomAmount -= 0.1f; //reduce zoom
        zoomAmount = Mathf.Clamp(zoomAmount, 0.5f, 1.5f); //limit zoom between 0.5 and 1.5
        Debug.Log(camara);
        camara.fieldOfView = 60f * zoomAmount; //adjust camera field of view based on zoom amount
    }
}

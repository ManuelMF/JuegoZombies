using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioAkDisparo : MonoBehaviour
{
    public AudioSource audioSourceDisparo;
    public AudioSource audioSourceRecarga;

    void Start()
    {


    }

    void Update()
    {

    }
    public void AudioDisparar()
    {
        audioSourceDisparo.Play();
    }
    public void AudioRecargar()
    {
        audioSourceRecarga.Play();
    }
}

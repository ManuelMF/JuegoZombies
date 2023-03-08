using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZombie : MonoBehaviour
{
    public AudioSource audioZombie1;
    public AudioSource audioZombie2;
    public AudioSource audioZombie3;
    public AudioSource audioZombie4;
    public AudioSource audioZombie5;
    public AudioSource audioZombie6;
    public AudioSource audioZombie7;

    void Start()
    {
        
    }

    void Update()
    {
        //hay una posibilidad entre 300 de que chille si chilla se hace un rando entre los diferentes tipos de chillido
        int Rand = Random.Range(1, 300);

        if (Rand == 50)
        {
            int num = Random.Range(1, 8);
            if (num == 1)
            {
                audioZombie1.Play();
            }
            else if (num == 2)
            {
                audioZombie2.Play();
            }
            else if (num == 3)
            {
                audioZombie3.Play();
            }
            else if (num == 4)
            {
                audioZombie4.Play();
            }
            else if (num == 5)
            {
                audioZombie5.Play();
            }
            else if (num == 6)
            {
                audioZombie6.Play();
            }
            else if (num == 7)
            {
                audioZombie7.Play();
            }
        }
    }
}

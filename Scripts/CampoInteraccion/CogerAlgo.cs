using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerAlgo : MonoBehaviour
{
    private Transform childTransform;
    private Transform parentTransform;
    private Rigidbody rb;
    private bool crearHijo = false;

    //coger objetos al final no se ha usado en el juego
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hijo")
        {
            childTransform = other.transform;
            rb = other.GetComponent<Rigidbody>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hijo")
        {
            childTransform = null;
            rb = null;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && childTransform != null)
        {
            crearHijo = !crearHijo; 

            if (crearHijo)
            {
                parentTransform = transform;
                childTransform.parent = parentTransform;
                childTransform.position = parentTransform.position;
                childTransform.transform.eulerAngles = new Vector3(0, 0, 0);
                rb.constraints = RigidbodyConstraints.FreezeAll;
                /* rb.useGravity = true;*/
                childTransform.GetComponent<Collider>().isTrigger = true;
            }
            else
            {
                childTransform.parent = null;
                rb.constraints = RigidbodyConstraints.None;
                rb.useGravity = true;
                childTransform.GetComponent<Collider>().isTrigger = false;
            }
        }
    }
}
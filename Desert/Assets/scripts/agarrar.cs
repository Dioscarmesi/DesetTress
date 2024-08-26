using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrar : MonoBehaviour
{
    public GameObject objeto;
    public bool objetoAgarrado;

    void Update()
    {
        if(objetoAgarrado == false && 
            Input.GetKey(KeyCode.E) && 
            objeto != null)
        {
            objeto.GetComponent<Rigidbody>().isKinematic = true;
            objetoAgarrado = true;
        }
        if(objetoAgarrado == true)
        {
            objeto.transform.position = transform.position;
        }
        if(Input.GetKeyUp(KeyCode.E) && objetoAgarrado == true)
        {
            objetoAgarrado = false;
            objeto.GetComponent <Rigidbody>().isKinematic = false; 
            objeto = null;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "item")
        {
            objeto = other.gameObject; 
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "item")
        {
            objeto = null;
        }
    }
}

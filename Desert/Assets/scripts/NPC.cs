using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NPC : MonoBehaviour
{
    public GameObject cajaTexto;
    public string dialogo;
    public TMP_Text texto;
    public Color color1;
    public Color color2;
    void Start()
    {
        cajaTexto.SetActive(false);
        color1 = GetComponent<MeshRenderer>().material.color;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") { 
            cajaTexto.SetActive (true);
            texto.text = dialogo;
        }
        if (other.gameObject.tag == "item")
        {
            GetComponent<MeshRenderer>().material.color = color2;   
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cajaTexto.SetActive(false);
            texto.text = "";
        }
        if (other.gameObject.tag == "item")
        {
            GetComponent<MeshRenderer>().material.color = color1;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Accion ");
            }
        }
    }
}

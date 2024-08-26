using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class mover : MonoBehaviour
{
    private CharacterController controller;
    public float velocidad;
    public float velocidad1;
    public float velocidad2;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocidad = velocidad2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            velocidad = velocidad1;
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * velocidad);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}
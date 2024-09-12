using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float walkSpeed = 5f;
    public float runSpeed = 10f;

    private float currentSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }
       
        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(transform.position + moveDirection * currentSpeed * Time.deltaTime);
    }
}

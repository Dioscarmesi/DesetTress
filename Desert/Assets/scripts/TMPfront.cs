using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMPfront : MonoBehaviour
{
    public Camera playerCamera; // Asigna la c�mara del jugador en el Inspector
    private TextMeshProUGUI textMeshPro; // Referencia al TextMeshPro

    void Start()
    {
        // Obtiene el componente TextMeshProUGUI del GameObject
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Aseg�rate de que playerCamera est� asignada
        if (playerCamera != null)
        {
            // Orienta el TextMeshPro hacia la c�mara
            transform.rotation = Quaternion.LookRotation(transform.position - playerCamera.transform.position);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TMPfront : MonoBehaviour
{
    public Camera playerCamera; // Asigna la cámara del jugador en el Inspector
    private TextMeshProUGUI textMeshPro; // Referencia al TextMeshPro

    void Start()
    {
        // Obtiene el componente TextMeshProUGUI del GameObject
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Asegúrate de que playerCamera esté asignada
        if (playerCamera != null)
        {
            // Orienta el TextMeshPro hacia la cámara
            transform.rotation = Quaternion.LookRotation(transform.position - playerCamera.transform.position);
        }
    }
}

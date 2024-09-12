using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sistema : MonoBehaviour
{
    public TextMeshProUGUI GradosTMP;
    public TextMeshProUGUI DineroTMP;
    public float grados; // Ahora 'grados' es de tipo float para manejar decimales
    public float dinero;

    public GameObject[] arbustos; // Array de prefabs de arbustos
    public float precioArbusto;  // Valor a restar del dinero cuando se activa un arbusto
    public float gradosArbusto;    // Valor a restar de los grados cuando se activa un arbusto

    public GameObject[] arboles; // Array de prefabs de árboles
    public float precioArbol;    // Valor a restar del dinero cuando se activa un árbol
    public float gradosArbol;    // Valor a restar de los grados cuando se activa un árbol

    public GameObject[] tierras; // Array de prefabs de tierras
    public float precioTierra;   // Valor a restar del dinero cuando se activa una tierra
    public float gradosTierra;   // Valor a restar de los grados cuando se activa una tierra

    public GameObject[] NPC; // Array de NPCs

    void Start()
    {
        ActualizarGrados();
        ActualizarDinero();

        // Inicializar todos los arbustos, árboles y tierras como inactivos
        InicializarObjetos(arbustos);
        InicializarObjetos(arboles);
        InicializarObjetos(tierras);

        // Comenzar el ciclo de actualización para los NPCs
        StartCoroutine(ActualizarDineroPorNPC());
    }

    private void InicializarObjetos(GameObject[] objetos)
    {
        foreach (GameObject obj in objetos)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }

    public void ActivarArbusto(int index)
    {
        if (index >= 0 && index < arbustos.Length)
        {
            GameObject arbusto = arbustos[index];
            if (arbusto != null)
            {
                arbusto.SetActive(true);
                dinero -= precioArbusto;
                grados -= gradosArbusto;
                ActualizarGrados();
                ActualizarDinero();
            }
        }
        else
        {
            Debug.LogWarning("Índice de arbusto fuera de rango.");
        }
    }

    public void ActivarArbol(int index)
    {
        if (index >= 0 && index < arboles.Length)
        {
            GameObject arbol = arboles[index];
            if (arbol != null)
            {
                arbol.SetActive(true);
                dinero -= precioArbol;
                grados -= gradosArbol;
                ActualizarGrados();
                ActualizarDinero();
            }
        }
        else
        {
            Debug.LogWarning("Índice de árbol fuera de rango.");
        }
    }

    public void ActivarTierra(int index)
    {
        if (index >= 0 && index < tierras.Length)
        {
            GameObject tierra = tierras[index];
            if (tierra != null)
            {
                tierra.SetActive(true);
                dinero -= precioTierra;
                grados -= gradosTierra;
                ActualizarGrados();
                ActualizarDinero();
            }
        }
        else
        {
            Debug.LogWarning("Índice de tierra fuera de rango.");
        }
    }

    private IEnumerator ActualizarDineroPorNPC()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);

            foreach (GameObject npc in NPC)
            {
                if (npc.activeSelf)
                {
                    dinero += 15f;
                }
            }

            ActualizarDinero();
        }
    }

    public void ActualizarGrados()
    {
        GradosTMP.text = grados.ToString("F2") + "°"; // Formatear los grados para mostrar 2 decimales
    }

    public void ActualizarDinero()
    {
        DineroTMP.text = dinero.ToString() + "$";
    }
}

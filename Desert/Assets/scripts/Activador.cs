using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Activador : MonoBehaviour
{
    public GameObject Player;        // Referencia al objeto del jugador
    public GameObject AreaC;         // Referencia al �rea de compra
    public TextMeshPro PrecioTMP;    // Referencia al TMP que muestra el precio

    public GameObject PlantaVenta;   // Referencia al objeto PlantaVenta
    public GameObject PlantaCompra;  // Referencia al objeto PlantaCompra

    public Sistema sistema;          // Referencia al script Sistema

    public enum TipoDeObjeto
    {
        Arbusto,
        Arbol,
        Tierra
    }

    public TipoDeObjeto tipoDeObjeto; // Tipo de objeto a activar
    public int index;                // �ndice del objeto espec�fico en el array del sistema

    public bool iniciarConPlantaVentaActivada = false; // Elegir si PlantaVenta comienza activada
    public bool desactivarPlantaVentaAlSalir = true;   // Elegir si PlantaVenta se desactiva al salir del �rea

    private bool isPlayerInArea = false;  // Flag para saber si el jugador est� en el �rea
    private bool objetoComprado = false; // Flag para saber si el objeto ya ha sido comprado

    void Start()
    {
        // Inicializaci�n de objetos
        PrecioTMP.gameObject.SetActive(false);
        PlantaCompra.SetActive(false);

        // Activar o desactivar PlantaVenta seg�n la opci�n seleccionada en el Inspector
        PlantaVenta.SetActive(iniciarConPlantaVentaActivada);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el jugador entra en el �rea y si el objeto no ha sido comprado
        if (other.gameObject == Player && !objetoComprado)
        {
            PrecioTMP.gameObject.SetActive(true);  // Activar siempre el TMP del precio
            PlantaVenta.SetActive(true);           // Activar PlantaVenta cuando el jugador entra en el �rea
            isPlayerInArea = true;                 // Marcar que el jugador est� en el �rea
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verificar si el jugador sale del �rea y si el objeto no ha sido comprado
        if (other.gameObject == Player && !objetoComprado)
        {
            PrecioTMP.gameObject.SetActive(false); // Siempre desactivar el TMP del precio al salir del �rea

            // Desactivar PlantaVenta solo si se ha elegido en el Inspector
            if (desactivarPlantaVentaAlSalir)
            {
                PlantaVenta.SetActive(false);  // Desactivar PlantaVenta solo si la opci�n est� activada
            }

            isPlayerInArea = false;            // Marcar que el jugador ha salido del �rea
        }
    }

    void Update()
    {
        // Verificar si el jugador est� en el �rea y presiona la tecla E
        if (isPlayerInArea && Input.GetKeyDown(KeyCode.E) && !objetoComprado)
        {
            // Verificar si el jugador tiene suficiente dinero y grados para activar el objeto
            if (PuedeComprar())
            {
                // Realizar el cobro y la activaci�n del objeto espec�fico
                ActivarObjeto();

                // Invertir los estados de PlantaVenta y PlantaCompra para este objeto
                PlantaVenta.SetActive(false);
                PlantaCompra.SetActive(true);

                // Desactivar el TMP del precio
                PrecioTMP.gameObject.SetActive(false);

                // Marcar que el objeto ha sido comprado
                objetoComprado = true;

                // Actualizar los TMP de dinero y grados en el sistema
                sistema.ActualizarGrados();
                sistema.ActualizarDinero();
            }
            else
            {
                Debug.LogWarning("No tienes suficientes recursos para realizar esta compra.");
            }
        }
    }

    private bool PuedeComprar()
    {
        switch (tipoDeObjeto)
        {
            case TipoDeObjeto.Arbusto:
                return sistema.dinero >= sistema.precioArbusto && sistema.grados >= sistema.gradosArbusto;
            case TipoDeObjeto.Arbol:
                return sistema.dinero >= sistema.precioArbol && sistema.grados >= sistema.gradosArbol;
            case TipoDeObjeto.Tierra:
                return sistema.dinero >= sistema.precioTierra && sistema.grados >= sistema.gradosTierra;
            default:
                return false;
        }
    }

    private void ActivarObjeto()
    {
        switch (tipoDeObjeto)
        {
            case TipoDeObjeto.Arbusto:
                sistema.ActivarArbusto(index);
                break;
            case TipoDeObjeto.Arbol:
                sistema.ActivarArbol(index);
                break;
            case TipoDeObjeto.Tierra:
                sistema.ActivarTierra(index);
                break;
        }
    }
}

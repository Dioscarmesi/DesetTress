using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaladoObj : MonoBehaviour
{
    public float startSize = 0.1f; // Tamaño inicial (10%)
    public float endSize = 1.0f; // Tamaño final (100%)
    public float duration = 20f; // Duración de la animación en segundos
    private Vector3 originalScale;
    private Vector3 targetScale;
    private float elapsedTime = 0f;
    private bool isScaling = false;

    void Start()
    {
        originalScale = transform.localScale;
        targetScale = originalScale * endSize;
        transform.localScale = originalScale * startSize;
    }

    void Update()
    {
        if (isScaling)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            transform.localScale = Vector3.Lerp(originalScale * startSize, targetScale, t);

            if (t >= 1f)
            {
                isScaling = false; // Detiene la escala al alcanzar el tamaño final
            }
        }
    }

    void OnEnable()
    {
        elapsedTime = 0f;
        isScaling = true;
    }
}

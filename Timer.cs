using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float tiempoInicial;
    public TextMeshProUGUI textoTiempo;

    void Start()
    {
        // Se puede usar Start() para inicializar el tiempo
        tiempoInicial = Time.time;
    }

    void Update()
    {
        float tiempoActual = Time.time - tiempoInicial;
        textoTiempo.text = tiempoActual.ToString("F2");
    }
}




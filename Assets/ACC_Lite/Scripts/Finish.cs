using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Agregar esta línea para usar UI elements

public class Finish : MonoBehaviour
{
    public GameObject finishButton; // Referencia al botón que quieres mostrar al pasar por la meta

    private bool raceFinished = false;
    private float finishTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") && !raceFinished)
        {
            raceFinished = true;

            Timer timerScript = FindObjectOfType<Timer>();
            if (timerScript != null)
            {
                timerScript.StopTimer();
                finishTime = timerScript.GetElapsedTime();
            }

            Debug.Log("¡Línea de meta a tiempo! Tiempo final: " + finishTime);

            // Activa el botón al cruzar la línea de meta
            if (finishButton != null)
            {
                finishButton.SetActive(true);
            }
        }
    }
}
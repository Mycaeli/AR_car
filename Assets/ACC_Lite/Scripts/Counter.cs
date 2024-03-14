using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;
    public GameObject FinishLine;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void Start() => UpdateCount();
    void OnEnable() => Collectable.OnCollected += OnCollectibleCollected;
    void OnDisable() => Collectable.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();
    }

    void UpdateCount()
    {
        text.text = $"{count} / {9}";

        // Verificar si count y Collectable.total son iguales
        if (count == 9)
        {
            FinishLine.SetActive(true);
        }
    }
}
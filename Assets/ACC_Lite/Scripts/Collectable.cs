using UnityEngine;
using System;

public class Collectable : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;

    void Awake() => total++;

    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            OnCollected?.Invoke();
            Destroy(gameObject);

        }
    }
}

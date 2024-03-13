using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
        // Obtiene el índice de la escena actual y la recarga
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

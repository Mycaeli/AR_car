using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonMenu;

    [SerializeField] private GameObject menuPausa;
   public void Pausa()
    {
        Time.timeScale = 0f;
        botonMenu.SetActive(false);
        menuPausa.SetActive(true);
        
    }

    public void Reanudar()
    {
        
        botonMenu.SetActive(true);
        menuPausa.SetActive(false);
    }
}

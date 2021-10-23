using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrearEscena : MonoBehaviour
{
    public void CambiarEscenaClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}

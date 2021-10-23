using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortadaHelper : MonoBehaviour
{
    public string EscenaJuego;
    public string EscenaPuntaje;
    public float timer = 5;

    //Funciona para que cambie a la portada automaticamente con el tiempo establecido
    private void Start()
    {
        StartCoroutine(EsperarCambioEscena());
    }

    private IEnumerator EsperarCambioEscena()
    {
        yield return new WaitForSeconds(5f);

        VerMejoresPuntajes();
    }

    public void IniciarJuego()
    {
        try
        {
            GameManager.instacia.CambiarEscena(EscenaJuego);
        }
        catch(System.Exception ex)
        {
            Debug.Log("Se le olvido poner el GameManager en la escena!");
        }
        
    }

    public void VerMejoresPuntajes()
    {
        try
        {
            GameManager.instacia.CambiarEscena(EscenaPuntaje);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se le olvido poner el GameManager en la escena!");
        }
    }

    public void Salir()
    {
        try
        {
            GameManager.instacia.Salir();
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se le olvido poner el GameManager en la escena!");
        }
    }
}

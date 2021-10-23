using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaneHelper : MonoBehaviour
{

    public string EscenaPortada;
    public string PuntajeFinal = "1000";
    public Text txtPuntajeFinal;

    private void Start()
    {
        //Al iniciar el juego, vamos a  desplegar en pantalla el puntaje final del jugador
        PuntajeFinal = GameManager.instacia.ObtenerPuntaje().ToString();
        txtPuntajeFinal.text = PuntajeFinal;
    }
    public void RegresarPortada()
    {
        try
        {
            GameManager.instacia.CambiarEscena(EscenaPortada);
        }
        catch (System.Exception ex)
        {
            Debug.Log("Se le olvido poner el GameManager en la escena!");
        }
    }
}

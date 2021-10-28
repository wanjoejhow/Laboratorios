using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerdidaHelper : MonoBehaviour
{

    public string EscenaPortada;
    public Text PuntajeTotal;
    public InputField inicialesJugador;

    public int[] puntajes;
    public string[] puntajesNombres;

    private int temp;
    private int pivote;
    private string pivoteNombre;
    private string tempNombre;

    public void GuardarDatosDiscoDuro()
    {
        puntajes = new int[3];
        puntajesNombres = new string[3];

        RecuperarDatos();

        pivote = GameManager.instacia.ObtenerPuntaje();

        if (pivote > puntajes[0])
        {
            tempNombre = puntajesNombres[1]; //Nombre
            temp = puntajes[1];//Puntaje

            puntajesNombres[1] = puntajesNombres[0];
            puntajes[1] = puntajes[0];

            puntajesNombres[0] = pivoteNombre;
            puntajes[0] = pivote;

            pivoteNombre = tempNombre;
            pivote = temp;
        }

        if (pivote > puntajes[1])
        {
            tempNombre = puntajesNombres[2];
            temp = puntajes[2];

            puntajesNombres[2] = puntajesNombres[1];
            puntajes[2] = puntajes[1];


            puntajesNombres[1] = pivoteNombre;
            puntajes[1] = pivote;

            pivoteNombre = tempNombre;
            pivote = temp;
        }

        if (pivote > puntajes[2])
        {
            puntajesNombres[2] = pivoteNombre;
            puntajes[2] = pivote;
            
        }

        GuardarDatos();
    }
    private void Start()
    {    

        PuntajeTotal.text = GameManager.instacia.ObtenerPuntaje().ToString();
        
    }

    private void RecuperarDatos()
    {
        puntajes[0] = PlayerPrefs.GetInt("Pos01", 0);
        puntajes[1] = PlayerPrefs.GetInt("Pos02", 0);
        puntajes[2] = PlayerPrefs.GetInt("Pos03", 0);

        puntajesNombres[0] = PlayerPrefs.GetString("Pos01Nombres", "UCR");
        puntajesNombres[1] = PlayerPrefs.GetString("Pos02Nombres", "UCR");
        puntajesNombres[2] = PlayerPrefs.GetString("Pos03Nombres", "UCR");
    }

    private void GuardarDatos()
    {

        PlayerPrefs.SetInt("Pos01", puntajes[0]);
        PlayerPrefs.SetInt("Pos02", puntajes[1]);
        PlayerPrefs.SetInt("Pos03", puntajes[2]);

        PlayerPrefs.SetString("Pos01Nombres", puntajesNombres[0]);
        PlayerPrefs.SetString("Pos02Nombres", puntajesNombres[1]);
        PlayerPrefs.SetString("Pos03Nombres", puntajesNombres[2]);

    }

    public void VolverPortada()
    {
        pivoteNombre = inicialesJugador.text;

        GuardarDatosDiscoDuro();

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

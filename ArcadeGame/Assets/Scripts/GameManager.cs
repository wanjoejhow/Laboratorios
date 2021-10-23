using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Pueda hacer cambio de scena

public class GameManager : MonoBehaviour
{
    // Singelton 
    private static GameManager instancia;
    public static GameManager instacia
    {
        get
        {
            return instancia;
        }
    }

    // Miembros de Clase privados
    private int _puntaje;

    public int ObtenerPuntaje()
    {
        return _puntaje;
    }

    public void RestaurarPuntaje()
    {
        _puntaje = 0;
    }

    public void SumarPuntaje(int valor)
    {
        _puntaje += valor;
    }



    //Destruye  si la instancia es diferente a null
    private void Awake()
    {
        if(instancia == null)
        {
            instancia = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    //Permite cambiar una escena anadiendo un parametro string
    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
    //Permite cerrar la aplicacion
    public void Salir()
    {
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        //Operaciones ante el evento de cerrar la aplicación
        //Cerrar la conexion a la bd
        //Cerrar la lectura de archivos
        //Pausar el contador de tiempo de Juego
    }
    public bool GuardarPuntaje(int posicion, int valor)
    {
        try
        {
            PlayerPrefs.SetInt("Pos" + posicion.ToString(), valor);

        }
        catch(System.Exception)
        {
            return false;
        }
        return true;
    }

    public int ObtenerPuntaje(int posicion)
    {
        return PlayerPrefs.GetInt("Pos" + posicion.ToString(), 0);
    }

 

}


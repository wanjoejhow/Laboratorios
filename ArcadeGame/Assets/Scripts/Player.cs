
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector3 _postInicial;
    private Rigidbody rigidBody;
    private float velX, velY;
    private float jump;
    private bool enPiso;
    private float tiempoDeJuego;
    private int puntaje;


    public float fuerzaVertical = 1.5f;
    public float velocidad = 2f;
    //Tiempo transcurrido del juego
    public float tiempoTranscurrido = 0f;
    public float tiempoLimite = 30;
    public Text txt_TiempoTranscurrido;
    public Text txt_PuntajeActual;
    public Text txt_TiempoLimiteActual;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instacia.RestaurarPuntaje();
        //Carga la primera vez que usa el objeto y se reutiliza
        rigidBody = this.GetComponent<Rigidbody>();
    


        puntaje = 0;

        _postInicial = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z
            );
    }

    //Aumenta Puntaje
    public void IncrementarPuntaje(int valor)
    {
        puntaje += valor;
        Debug.Log("Puntaje Actual:" + puntaje.ToString());
    }

    public void ModificarTiempo(float valor)
    {
        Debug.Log("Tiempo Actual:" + tiempoDeJuego.ToString());
        tiempoDeJuego -= valor;
        Debug.Log("Tiempo con reducción:" + tiempoDeJuego.ToString()); 
    }

    // Update is called once per frame
    void Update()
    {
        //Actualizar interfaces gráficas
        txt_TiempoTranscurrido.text = this.tiempoTranscurrido.ToString();
        txt_PuntajeActual.text = this.puntaje.ToString();
        txt_TiempoLimiteActual.text = (tiempoLimite - tiempoDeJuego).ToString();


        //Contador de tiempo, va a sumar
        tiempoTranscurrido += Time.deltaTime;
        tiempoDeJuego += Time.deltaTime;

        if(tiempoDeJuego>= tiempoLimite)
        {
            FinDeJuego();
        }

        //------------------------------------------


        //velX = Input.GetAxis("Horizontal"); // -1 ..-0.5.. 0 ..0.5.. 1
        //velY = Input.GetAxis("Vertical");

        velX = Input.GetAxis("Horizontal");
        velY = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");
        enPiso = Physics.Raycast(this.transform.position, Vector3.down, 1.02f);
        
        //movimiento
        if (velX != 0 || velY != 0)
        {
            rigidBody.velocity = (new Vector3(velX, rigidBody.velocity.y, velY)) * velocidad;
        }

        //Salto
        if(enPiso && jump >= 0.3f)
        {
            rigidBody.AddForce(Vector3.up * fuerzaVertical);
        }
        


        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter ha sido presionado");

            transform.position = new Vector3(_postInicial.x, _postInicial.y, _postInicial.z);

            rigidBody.velocity = Vector3.zero;
        }
    }

    public void Alerta() 
    {
        Debug.Log("Conexion con un trigger establecida");
    }

    public void FinDeJuego()
    {
        Debug.Log("Juego Finalizado");
        GameManager.instacia.SumarPuntaje(Convert.ToInt32(puntaje * tiempoTranscurrido * 100));
        GameManager.instacia.CambiarEscena("Perder");

    }

    public void JuegoGanado()
    {
        if(puntaje == 100)
        {
            Debug.Log("Juego Ganado");
            GameManager.instacia.CambiarEscena("Puntajes");
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoTiempo : Objetivo
{
    public bool reposicionar = true;
    public float tiempo;
    public Material positivo;
    public Material negativo;

    private void Start()
    {
        if (tiempo > 0)
        {
            this.GetComponent<Renderer>().material = positivo;
        }
        else
        {
            this.GetComponent<Renderer>().material = negativo;

        }
    }


    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //Le mandamos la operacion de tiempo
            var player = other.GetComponent<Player>();
            player.ModificarTiempo(tiempo);
        }
        if(reposicionar)
        {
            base.OnTriggerEnter(other);
        }
    }

    public void ReposicionarNuevo()
    {

        base.Reposicionar();

    }

    //Suma de Tiempo 
    //Que aparesca cada 5 puntos sobre el escenario
    //Sino no ap
}

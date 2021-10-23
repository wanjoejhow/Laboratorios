using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoPuntaje : Objetivo
{
    public int puntos = 1;

    public GameObject prefabTiemponegativo;

    protected override void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            //player.Alerta();
            player.IncrementarPuntaje(puntos);

            //Me aumenta objetivos negativos
            GameObject.Instantiate(prefabTiemponegativo);

            var objetivoTiempo = prefabTiemponegativo.GetComponent<ObjetivoTiempo>();
            
            objetivoTiempo.ReposicionarNuevo();
        }
        base.OnTriggerEnter(other);
    }
}

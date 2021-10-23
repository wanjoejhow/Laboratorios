using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntajeHelper : MonoBehaviour
{
    public string EscenaPortada;
    public float timer = 5;

    private void Start()
    {
        StartCoroutine(EsperarCambioEscena());
    }
    
    private IEnumerator EsperarCambioEscena()
    {
        yield return new WaitForSeconds(5f);

        VolverPortada();
    }
    public void VolverPortada()
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

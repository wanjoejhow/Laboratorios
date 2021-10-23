using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerdidaHelper : MonoBehaviour
{

    public string EscenaPortada;

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

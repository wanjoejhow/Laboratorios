using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColision : MonoBehaviour
{
    public Material materialResaltado;
    public Material materialOriginal;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //Este codigo se activa al entrar una colision
        Debug.Log("Un objeto ha entrado al trigger");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Es un objeto con el tag player");

            try
            {
                var player = other.GetComponent<Player>();
                player.Alerta();

                var rigidbd = other.GetComponent<Rigidbody>();
                //rigidbd.AddTorque(new Vector3(Random.Range(0f, 100f),Random.Range(0f, 100f),Random.Range(0f, 100f)));
                rigidbd.AddForce(new Vector3(Random.Range(-1000f, 1000f), Random.Range(1f, 1000f), Random.Range(-1000f, 1000f)));
                

            }
            catch (System.Exception ex)
            {
                Debug.LogError("Se te olvido poner un componente player en el objeto que tiene la etiqueta layer:" +ex.Message);
            }
           
        }
    }
    

    public void OnTriggerStay(Collider other)
    {
        //Este codigo se ejecuta por frame (como un update) mientras exista una colision
        Debug.Log("Un objeto esta dentro del trigger");
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material = materialResaltado;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //Este codigo se ejecuta cuando sale del volumen de un trigger
        Debug.Log("Un objeto ha salido del trigger");
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material = materialOriginal;
        }
    }

}

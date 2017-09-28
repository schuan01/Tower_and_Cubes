using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerParts : MonoBehaviour
{
    public GameObject gameStateObject;

    public bool isIgnore = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetIgnorePart(bool val)
    {
        isIgnore = val;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("enemy"))
        {
            Destroy(other.gameObject);
            transform.parent.GetComponent<TowerBase>().DecreaseLife();
            gameStateObject.GetComponent<WaveGenerator>().ChangeEnemiesLeft();

        }

        /*Debug.Log("choco");

        if (other.gameObject.tag.Contains("enemy"))
        {
            
            GameObject parteSiguiente = null;
            Vector3 siguienteUbicacion;
            //ELIMINO LA INSTANCIA Y DE LA LISTA TAMBIEN
            int i = -1;
            foreach (GameObject g in gameObject.transform.parent.GetComponent<TowerBase>().towerParts)
            {
                i++;
                if (g.name == gameObject.name)
                {
                    gameObject.transform.parent.GetComponent<TowerBase>().towerParts.RemoveAt(i);
                    if(gameObject.transform.parent.GetComponent<TowerBase>().towerParts.Count - 1 >= i+1)
                    {
                        parteSiguiente = gameObject.transform.parent.GetComponent<TowerBase>().towerParts[i+1];
                    }
                    break;
                }
            }


            if(parteSiguiente != null && parteSiguiente.tag != "towerPoint")
            {
                i = 0;
                foreach (GameObject g in gameObject.transform.parent.GetComponent<TowerBase>().towerParts)
                {
                    if(parteSiguiente.name.Contains(g.name))
                    {
                        //siguienteUbicacion = g.transform.position;
                        
                    }
                }
            }
            //ANTES DE DESTRUIR ME GUARDO LA UBICACION
            Vector3 ubiAnterior = gameObject.transform.position;
            Vector3 ubiActual;

            i = 0;
            Destroy(other.gameObject);
            Destroy(gameObject);

            //Recoloco todas las piezas
            foreach (GameObject g in gameObject.transform.parent.GetComponent<TowerBase>().towerParts)
            {
                if (i == 0)//Si es solo el siguiente, activo el trigger
                {
                    g.GetComponent<Collider>().isTrigger = true;
                }
                ubiActual = g.transform.position;
                g.transform.position = ubiAnterior;
                ubiAnterior = ubiActual;
                i++;

            }

            transform.parent.GetComponent<TowerBase>().DecreaseLife();

        }*/
    }
}

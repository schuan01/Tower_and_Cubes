using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerParts : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.Contains("enemy"))
        {
            //ELIMINO LA INSTANCIA Y DE LA LISTA TAMBIEN
            int i = -1;
            foreach (GameObject g in gameObject.transform.parent.GetComponent<TowerBase>().towerParts)
            {
                i++;
                if (g.name == gameObject.name)
                {
                    gameObject.transform.parent.GetComponent<TowerBase>().towerParts.RemoveAt(i);
                    break;
                }
            }

            //ANTES DE DESTRUIR ME GUARDO LA UBICACION
            Vector3 ubiAnterior = gameObject.transform.position;
            Vector3 ubiActual;

            i = 0;
            Destroy(other.gameObject);
            Destroy(gameObject);
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

        }
    }
}

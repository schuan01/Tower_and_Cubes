﻿using System;
using UnityEngine;

public class TerrainBase : MonoBehaviour
{

    // Use this for initialization
    private GameObject[,] listOfTiles = new GameObject[11, 11];

    void Start()
    {
        SetTiles();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(listOfTiles.Length);
    }

    public void SetTiles()
    {
        string completeName;
        int nameI;
        int nameJ;
        string[] tokens;
        foreach (Transform child in transform)
        {
            completeName = child.gameObject.name;
            tokens = completeName.Split('_');
            nameI = Convert.ToInt32(tokens[1]);
            nameJ = Convert.ToInt32(tokens[2]);
            listOfTiles[nameI, nameJ] = child.gameObject;

        }
    }

    public GameObject[,] GetArrayTerrain()
    {
        return listOfTiles;
    }

    public void DestroyTile(GameObject tile)
    {
        int[] pos = GetTileIndexByName(tile);
        listOfTiles[pos[0], pos[1]] = null;//Eliminamos del array
        Destroy(tile);//Eliminamos de la escena
    }

    private int[] GetTileIndexByName(GameObject tile)
    {
        string completeName = tile.name;
        string[] tokens = completeName.Split('_');
        int nameI = Convert.ToInt32(tokens[1]);
        int nameJ = Convert.ToInt32(tokens[2]);
        int[] ret = new int[2];
        ret[0] = nameI;
        ret[1] = nameJ;
        return ret;
    }

    public Material matBorder;
    public void CheckBorders(GameObject sourceTile)
    {
        int[] positions = GetTileIndexByName(sourceTile);
        int posI = positions[0];
        int posJ = positions[1];
        int largoI;
        int largoJ;

        largoI = listOfTiles.GetLength(0) - 1;//Bajamos uno por el tema del indice
        largoJ = listOfTiles.GetLength(1) - 1;//Bajamos uno por el tema del indice
        int posINueva;
        int posJNueva;


        //PARA LA IZQUIERDA
        posINueva = posI;
        posJNueva = posJ - 1;
        if ((posINueva >= 0 && posJNueva >= 0) && (posINueva <= largoI && posJNueva <= largoJ))
        {

            GameObject val = listOfTiles[posINueva, posJNueva];
            if (val != null)
            {
                Material[] mats = val.GetComponent<Renderer>().materials;
                mats[0] = matBorder;
                val.GetComponent<Renderer>().materials = mats;
				val.tag = "terrainQuad_Border";
            }

        }

        //PARA ARRIBA
        posINueva = posI - 1;
        posJNueva = posJ;
        if ((posINueva >= 0 && posJNueva >= 0) && (posINueva <= largoI && posJNueva <= largoJ))
        {

            GameObject val = listOfTiles[posINueva, posJNueva];
            if (val != null)
            {
                Material[] mats = val.GetComponent<Renderer>().materials;
                mats[0] = matBorder;
                val.GetComponent<Renderer>().materials = mats;
				val.tag = "terrainQuad_Border";
            }

        }

        //PARA DERECHA
        posINueva = posI;
        posJNueva = posJ + 1;
        if ((posINueva >= 0 && posJNueva >= 0) && (posINueva <= largoI && posJNueva <= largoJ))
        {

            GameObject val = listOfTiles[posINueva, posJNueva];
            if (val != null)
            {
                Material[] mats = val.GetComponent<Renderer>().materials;
                mats[0] = matBorder;
                val.GetComponent<Renderer>().materials = mats;
				val.tag = "terrainQuad_Border";
            }

        }

        //PARA ABAJO
        posINueva = posI + 1;
        posJNueva = posJ;
        if ((posINueva >= 0 && posJNueva >= 0) && (posINueva <= largoI && posJNueva <= largoJ))
        {

            GameObject val = listOfTiles[posINueva, posJNueva];
            if (val != null)
            {
                Material[] mats = val.GetComponent<Renderer>().materials;
                mats[0] = matBorder;
                val.GetComponent<Renderer>().materials = mats;
				val.tag = "terrainQuad_Border";
            }

        }


    }



}

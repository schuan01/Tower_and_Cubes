using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{

    public List<GameObject> lstTerrainTiles = new List<GameObject>();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddTileToList(GameObject obj)
    {
        lstTerrainTiles.Add(obj);
    }

    public void RemoveTileFromList(GameObject obj)
    {
        lstTerrainTiles.RemoveAll(g => g.GetInstanceID() == obj.GetInstanceID());
    }

    public void UpdateTileFromList(GameObject obj)
    {
        RemoveTileFromList(obj);
        AddTileToList(obj);
    }

    public List<GameObject> GetBorderTiles()
    {
        List<GameObject> onlyBorders = new List<GameObject>();
        foreach (GameObject g in lstTerrainTiles)
        {
            if (g != null)
            {
                if (g.GetComponent<TerrainTile>().isBorder)
                {
                    onlyBorders.Add(g);
                }
            }
        }

        return onlyBorders;
    }
}

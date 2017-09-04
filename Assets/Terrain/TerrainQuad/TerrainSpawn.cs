using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawn : MonoBehaviour
{
    public List<GameObject> listOfTiles = new List<GameObject>();
    private int numberOfTiles = 10;
    private int currentTileYouAreSpawning = 0;

	public GameObject piso;




    /*private void Start()
    {
        for (int x = 0; x < numberOfTiles; x++)
        {
            for (int z = 0; z < numberOfTiles; z++)
            {
                Instantiate(piso, new Vector3(x, 0, z), Quaternion.identity);

            }
        }
    }*/


    // Update is called once per frame
    void Update()
    {

    }


}

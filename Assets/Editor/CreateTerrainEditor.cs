using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyTools
{
    private static List<GameObject> listOfTiles = new List<GameObject>();
    private static int numberOfTiles = 11;//Como son de tamaño 2

    private static GameObject pisoPrefab;
    private static GameObject pisoCreado;
    private static int indexI = -1;
    private static int indexJ;

    [MenuItem("MyTools/CreateTerrainEditor")]
    static void Create()
    {
        if (EditorUtility.IsPersistent(Selection.activeObject))
        {
			GameObject parent = MonoBehaviour.Instantiate(new GameObject(), new Vector3(0, 0, 0), Quaternion.identity);
			parent.name = "TerrainAll";
            pisoPrefab = Selection.activeObject as GameObject;
            for (float x = -10.04f; x < numberOfTiles; x = x + 2)
            {
                indexI++;
                indexJ = -1;
                for (float z = -10.02f; z < numberOfTiles; z = z + 2)
                {
                    indexJ++;
                    pisoCreado = MonoBehaviour.Instantiate(pisoPrefab, new Vector3(x, 0, z), Quaternion.identity);
                    pisoCreado.name = "TerrainQuad_" + indexI + "_" + indexJ;
					pisoCreado.transform.parent = parent.transform;
					listOfTiles.Add(pisoCreado);

                }
            }
        }
    }

	public static List<GameObject> getTerrainList()
	{
		return listOfTiles;
	}
}

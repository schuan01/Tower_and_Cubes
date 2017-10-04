
using UnityEngine;


public class TerrainTile : MonoBehaviour
{

    public bool isActiveTile = true;
    public bool isBorder = false;

    public Material matEnable;
    public Material matDisable;

	public GameObject gameStateObject;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetEnable(bool val)
    {
        isActiveTile = val;
		ChangeColor();
		gameStateObject.GetComponent<TerrainManager>().UpdateTileFromList(gameObject);
    }

    public void SetIsBorder(bool isborder)
    {
        isBorder = isborder;
		gameStateObject.GetComponent<TerrainManager>().UpdateTileFromList(gameObject);
    }

    public void SetIsBorderEditorMode(bool isborder)
    {
        isBorder = isborder;
    }

    private void ChangeColor()
    {

        Material[] mats = gameObject.GetComponent<Renderer>().materials;
        if (isActiveTile)
        {
            mats[0] = matEnable;
        }
		else
		{
			mats[0] = matDisable;
		}

        gameObject.GetComponent<Renderer>().materials = mats;

    }
}

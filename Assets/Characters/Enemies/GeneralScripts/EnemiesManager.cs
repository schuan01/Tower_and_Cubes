
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{

    public List<GameObject> lstEnemies = new List<GameObject>();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddEnemyToList(GameObject obj)
    {
        lstEnemies.Add(obj);
    }

    public void RemoveEnemyFromList(GameObject obj)
    {
        lstEnemies.RemoveAll(g => g.GetInstanceID() == obj.GetInstanceID());
    }

    public void UpdateEnemyFromList(GameObject obj)
    {
        RemoveEnemyFromList(obj);
        AddEnemyToList(obj);
    }

    public void DestroyEnemy(GameObject obj)
    {
        gameObject.GetComponent<ScoreCounter>().ChangeScore();
        gameObject.GetComponent<WaveGenerator>().ChangeEnemiesLeft();
        gameObject.GetComponent<CoinsManager>().IncreseCoins();
        RemoveEnemyFromList(gameObject);
    }

	public void DestroyEnemyWithoutScore(GameObject obj)
    {
        gameObject.GetComponent<WaveGenerator>().ChangeEnemiesLeft();
        RemoveEnemyFromList(gameObject);
    }
}

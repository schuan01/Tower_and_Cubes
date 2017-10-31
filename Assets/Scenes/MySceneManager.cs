using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MySceneManager : MonoBehaviour
{

    public Scene currentScene;
    public Button freeze;
    public Button explode;
    public Button buy;
    public Button left;
    public Button right;

    public Text txtCoins;

    public Text txtWave;

    public GameObject terrainAll;

    public GameObject player;

    public bool isMainScene = false;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name.Contains("main"))
        {
            isMainScene = true;

        }
        else
        {
            isMainScene = false;
            ChangeUI();
            RevertTerrainTiles();
            ChangeEnemiesProbability();
            ChangeWaveBehavior();
            ChangePlayerShootSpeed();
            ChangePlayerCameraRotation();
            ChangeEnemyCoinCost();
        }
    }

    void Update()
    {
        
    }

    public void ChangeUI()
    {

        freeze.gameObject.SetActive(false);
        explode.gameObject.SetActive(false);
        buy.gameObject.SetActive(false);
        left.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
        txtWave.gameObject.SetActive(false);
        //txtCoins.gameObject.SetActive(false);

    }

    public void RevertTerrainTiles()
    {
        terrainAll.GetComponent<TerrainBase>().ResetAllTilesToActie();
    }

    public void ChangeEnemiesProbability()
    {
        GetComponent<SpawnEnemy>().lstEnemies = new List<KeyValuePair<GameObject, float>>();
        foreach (GameObject g in GetComponent<SpawnEnemy>().respawnPrefab)
        {
            if (g.tag.Contains("enemy_normal"))
            {
                GetComponent<SpawnEnemy>().lstEnemies.Add(new KeyValuePair<GameObject, float>(g, 100));
            }
        }
    }

    public void ChangeWaveBehavior()
    {
        GetComponent<WaveGenerator>().timeBeforeNextWave = 0.1f;
        GetComponent<WaveGenerator>().enemiesAddedAfterWave = 10;
        GetComponent<WaveGenerator>().timeBetweenSpawns = 0.4f;
        GetComponent<WaveGenerator>().spawnDecreser = 0.0f;
    }

    public void ChangePlayerShootSpeed()
    {
        player.GetComponent<CannonScript>().secondsToWaitShoot = 0.25f;
        player.GetComponent<CannonScript>().waitToShootDecreser = 0.0f;

    }
    public void ChangePlayerCameraRotation()
    {
        player.GetComponent<CannonScript>().allowToRotateCamera = false;

    }

    public void ChangeEnemyCoinCost()
    {
        GetComponent<CoinsManager>().difRewardCost = true;

    }


}

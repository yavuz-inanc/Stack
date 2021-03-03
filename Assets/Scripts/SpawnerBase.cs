using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnerBase : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject newCubePrefab;
    
    void Start()
    {
        gameManager = GameManager.instance;
    }

    public void SpawnACube()
    {
        RaisePosition();
        newCubePrefab.transform.localScale = gameManager.currentCube.transform.localScale;
        newCubePrefab.transform.position = transform.position;
        Instantiate(newCubePrefab);
    }

    public abstract void RaisePosition();
}

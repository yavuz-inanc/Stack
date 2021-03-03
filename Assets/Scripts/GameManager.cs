
using System;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public MovingCubeBase currentCube;
    public GameObject previousCube, spawnerZ, spawnerX;
    public State currentState = State.Z;
    public bool isGameActive;
    public int score;
    public float colorSinValue;
    public Color currentColor;
    public Material skyMaterial;

    public enum State
    {
        X,
        Z
    }
    
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("Best"))
        {
            PlayerPrefs.SetInt("Best", 0);
        }
        colorSinValue = Random.value;
        currentColor = GetNewColor();
        PrepareCubes();
    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isGameActive)
        {
            currentCube.Stop();
            if (isGameActive)
            {
                currentColor = GetNewColor();
                SpawnACube();
                colorSinValue += 0.1f;
                transform.position = currentCube.transform.position;
                currentState = currentState == State.Z ? State.X : State.Z;
            }
        }
    }
    
    public void PrepareCubes()
    {
        previousCube.GetComponent<Renderer>().material.color = currentColor;
        currentCube.gameObject.SetActive(false);
        currentCube.GetComponent<Renderer>().material.color = currentColor;
    }

    public void OpenFirstCube()
    {
        currentCube.gameObject.SetActive(true);
        isGameActive = true;
    }

    public void SpawnACube()
    {
        if (State.Z == currentState)
        {
            spawnerX.GetComponent<SpawnerX>().SpawnACube();
        }
        else
        {
            spawnerZ.GetComponent<SpawnerZ>().SpawnACube();
        }
        IncreaseScore();
    }

    public Color GetNewColor()
    {
        float r = Mathf.Sin(0.5f * colorSinValue) * 127 + 128;
        float g = Mathf.Sin(0.5f * colorSinValue + 2) * 127 + 128;
        float b = Mathf.Sin(0.5f * colorSinValue + 4) * 127 + 128;
        Color32 lrp = new Color32((byte)r,(byte)g,(byte)b,255);
        ChangeSkyColor(lrp);
        return lrp;
    }
    
    public void ChangeSkyColor(Color color)
    {
        skyMaterial.SetColor("_Color1", color);
    }

    public void IncreaseScore()
    {
        score++;
        MenuManager.instance.scoreTMP.text = score.ToString();
    }
}
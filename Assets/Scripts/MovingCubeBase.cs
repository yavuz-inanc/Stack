using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class MovingCubeBase : MonoBehaviour
{
    public GameManager gameManager;
    public float velocity;
    
    public void Start()
    {
        gameManager = GameManager.instance;
        gameManager.currentCube = this;
        velocity = 2.5f;
        GetComponent<Renderer>().material.color = gameManager.currentColor;
    }

    public abstract void FixedUpdate();

    public void Stop()
    {
        CutTheCube();
        gameManager.previousCube = gameObject;
        Destroy(this);
    }

    public abstract void CutTheCube();
    public abstract void CreateCuttedCube(float positionDif);

    public abstract void CreateFallingCube(float positionDif);

    public void PlaceTheCube()
    {
        transform.position = new Vector3(
            gameManager.previousCube.transform.position.x, 
            transform.position.y,
            gameManager.previousCube.transform.position.z);
        RectangleManager.instance.CreateRectangle(gameObject);
        AudioManager.instance.PlaySound();
    }
    
    public void StopTheGame()
    {
        gameManager.isGameActive = false;
        gameObject.AddComponent<Rigidbody>();
        if (PlayerPrefs.GetInt("Best") < gameManager.score)
        {
            PlayerPrefs.SetInt("Best", gameManager.score);
        }
        MenuManager.instance.OpenTryAgainButton();
    }
}
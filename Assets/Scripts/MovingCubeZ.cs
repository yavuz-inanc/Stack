using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCubeZ : MovingCubeBase
{
    public override void FixedUpdate()
    {
        if (Mathf.Abs(0 - transform.position.z) > 2)
        {
            velocity = -velocity;
        }
        transform.position += transform.forward * velocity * Time.fixedDeltaTime;
    }
    
    public override void CutTheCube()
    {
        float positionDif = gameManager.previousCube.transform.position.z - transform.position.z;

        if (Mathf.Abs(positionDif) < 0.05f)
        {
            PlaceTheCube();
        }
        else if (Mathf.Abs(positionDif) > gameManager.previousCube.transform.localScale.z)
        {
            StopTheGame();
        }
        else
        {
            CreateCuttedCube(positionDif);
            CreateFallingCube(positionDif);
            AudioManager.instance.PlayBrickSound();
        }
    }
    
    public override void CreateCuttedCube(float positionDif)
    {
        float newZScale = transform.localScale.z - Mathf.Abs(positionDif);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZScale);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + positionDif / 2);
    }
    

    public override void CreateFallingCube(float positionDif)
    {
        float fallingCubeZPozition;
        if (positionDif > 0)
        {
            fallingCubeZPozition = gameManager.previousCube.transform.position.z - (gameManager.previousCube.transform.localScale.z / 2 + positionDif / 2);
        }
        else
        {
            fallingCubeZPozition = gameManager.previousCube.transform.position.z + (gameManager.previousCube.transform.localScale.z / 2 + (-positionDif) / 2);
        }
        
        GameObject fallingCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        fallingCube.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, Mathf.Abs(positionDif));
        fallingCube.transform.position = new Vector3(transform.position.x, transform.position.y, fallingCubeZPozition);
        fallingCube.AddComponent<Rigidbody>();
        fallingCube.AddComponent<BoxCollider>();
        fallingCube.GetComponent<Renderer>().material.color = gameManager.currentColor;
    }
    
}
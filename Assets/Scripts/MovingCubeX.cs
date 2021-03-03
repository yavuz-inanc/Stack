using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCubeX : MovingCubeBase
{
    public override void FixedUpdate()
    {
        if (Mathf.Abs(0 - transform.position.x) > 2)
        {
            velocity = -velocity;
        }
        transform.position += transform.right * velocity * Time.fixedDeltaTime;
    }

    public override void CutTheCube()
    {
        float positionDif = gameManager.previousCube.transform.position.x - transform.position.x;

        if (Mathf.Abs(positionDif) < 0.05f)
        {
            PlaceTheCube();
        }
        else if (Mathf.Abs(positionDif) > gameManager.previousCube.transform.localScale.x)
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
        float newXScale = transform.localScale.x - Mathf.Abs(positionDif);
        transform.localScale = new Vector3(newXScale, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(transform.position.x + positionDif / 2, transform.position.y, transform.position.z);
    }

    public override void CreateFallingCube(float positionDif)
    {
        float fallingCubeXPozition;
        if (positionDif > 0)
        {
            fallingCubeXPozition = gameManager.previousCube.transform.position.x - (gameManager.previousCube.transform.localScale.x / 2 + positionDif / 2);
        }
        else
        {
            fallingCubeXPozition = gameManager.previousCube.transform.position.x + (gameManager.previousCube.transform.localScale.x / 2 + (-positionDif) / 2);
        }
        
        GameObject fallingCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        fallingCube.transform.localScale = new Vector3(Mathf.Abs(positionDif), transform.localScale.y, transform.localScale.z);
        fallingCube.transform.position = new Vector3(fallingCubeXPozition, transform.position.y, transform.position.z);
        fallingCube.AddComponent<Rigidbody>();
        fallingCube.AddComponent<BoxCollider>();
        fallingCube.GetComponent<Renderer>().material.color = gameManager.currentColor;
    }
}

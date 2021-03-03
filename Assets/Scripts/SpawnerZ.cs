using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerZ : SpawnerBase
{
    public override void RaisePosition()
    {
        transform.position = new Vector3(
            gameManager.previousCube.transform.position.x,
            gameManager.previousCube.transform.position.y + gameManager.previousCube.transform.localScale.y, 
            transform.position.z);
    }
}

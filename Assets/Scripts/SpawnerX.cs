using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerX : SpawnerBase
{
    public override void RaisePosition()
    {
        transform.position = new Vector3(
            transform.position.x,
            gameManager.previousCube.transform.position.y + gameManager.previousCube.transform.localScale.y,
            gameManager.previousCube.transform.position.z);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RectangleManager : MonoBehaviour
{
    public static RectangleManager instance;

    private void Awake()
    {
        instance = this;
    }
    
    public void CreateRectangle(GameObject cube)
    {
        transform.position = new Vector3(
            cube.gameObject.transform.position.x,
            cube.gameObject.transform.position.y - cube.gameObject.transform.localScale.y / 2,
            cube.gameObject.transform.position.z);

        transform.localScale = new Vector3(
            cube.gameObject.transform.localScale.x,
            cube.gameObject.transform.localScale.z,
            transform.localScale.z);

        gameObject.SetActive(true);
        transform.DOScaleX(cube.transform.localScale.x + cube.transform.localScale.x / 2, 0.5f);
        transform.DOScaleY(cube.transform.localScale.z + cube.transform.localScale.z / 2, 0.5f).OnComplete(()=>
        {
            gameObject.SetActive(false);
        });
        GetComponent<SpriteRenderer>().DOFade(0f, 0.5f).SetEase(Ease.InCubic).OnComplete(() =>
            GetComponent<SpriteRenderer>().DOFade(1, 0f));
    }
}

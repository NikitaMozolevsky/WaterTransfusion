using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private Transform spriteTransform;
    private float speed = 0.5f;
    private float startX, startY;

    void Start()
    {
        spriteTransform = transform.GetChild(0).transform;
        startX = spriteTransform.localPosition.x;
        startY = spriteTransform.localPosition.y;
    }

    void Update()
    {
        float offsetX = Mathf.PerlinNoise(Time.time * speed, 0) - 0.5f;
        float offsetY = Mathf.PerlinNoise(0, Time.time * speed) - 0.5f;

        spriteTransform.localPosition = new Vector3(startX + offsetX, startY + offsetY, spriteTransform.localPosition.z);
    }
}

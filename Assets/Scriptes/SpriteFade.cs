using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFade : MonoBehaviour
{
    
    private SpriteRenderer spriteRenderer;
    private float currentAlpha = 1f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        currentAlpha -= Time.deltaTime;

        // Ограничьте значение альфа-канала от 0 до 1
        currentAlpha = Mathf.Clamp(currentAlpha, 0f, 1f);

        // Установите текущее значение альфа-канала для спрайта
        Color spriteColor = spriteRenderer.color;
        spriteColor.a = currentAlpha;
        spriteRenderer.color = spriteColor;

        // Если альфа-канал достиг 0, удалите спрайт или его объект из сцены
        if (currentAlpha <= 0f)
        {
            Destroy(gameObject);
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackgroundScroll : MonoBehaviour
{
    public float speedX = 0.5f, speedY = 0.5f;
    RawImage image;

    private void Awake()
    {
        image = GetComponent<RawImage>();   
    }

    void Update()
    {
        BackgroundMovement();
    }

    private void BackgroundMovement()
    {
        //Properly adjusts the size of the background to the size of the canvass
        Vector2 size = new Vector2(image.rectTransform.rect.width / 400, 1.5f);
        image.uvRect = new Rect(image.uvRect.position + new Vector2(speedX, speedY) * Time.deltaTime, size);
    }
}

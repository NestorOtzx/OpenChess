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
        image.uvRect = new Rect(image.uvRect.position + new Vector2(speedX, speedY) * Time.deltaTime, image.uvRect.size);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    private Image image;

    private float FadeSpeed = 0.01f;

    private float red;
    private float green;
    private float blue;
    private float alfa;

    private bool flag=false;
    public void Initialize()
    {
        alfa = 0;
        image = GetComponent<Image>();
        red = image.color.r;
        green = image.color.g;
        blue = image.color.b;
    }

    public void FadOut()
    {
        alfa += FadeSpeed;
        SetAlpha();
    }

    public void FadeIn()
    {
        alfa -= FadeSpeed;
        SetAlpha();
    }

    private void SetAlpha()
    {
        image.color = new Color(red, green, blue, alfa);
    }

    void Start()
    {
        Initialize();
    }

    void Update()
    {
       
    }
}

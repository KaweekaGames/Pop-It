using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Color defaultColor;
    public Color selectedColor;
    public Vector3 scale;
    public EaseType scaleEase;

    private Material mat;
    private Vector3 originalScale;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        originalScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    void OnTouchDown()
    {
        mat.color = selectedColor;
        gameObject.ScaleTo(scale, .3f, 0f, scaleEase);
    }

    void OnTouchUp()
    {
        mat.color = defaultColor;
        gameObject.ScaleTo(originalScale, .3f, 0f, scaleEase);
    }

    void OnTouchStay()
    {
        mat.color = selectedColor;
        gameObject.ScaleTo(scale, .3f, 0f, scaleEase);
    }

    void OnTouchCancel()
    {
        mat.color = defaultColor;
        gameObject.ScaleTo(originalScale, .3f, 0f, scaleEase);
    }

}

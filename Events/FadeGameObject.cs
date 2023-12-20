using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeGameObject : MonoBehaviour
{
    public float fadeSpeed; //0.5
    public float time_before_destroy; //2

    void Update()
    {
        Color objectColor = GetComponent<Renderer>().material.color;
        float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
        GetComponent<Renderer>().material.color = objectColor;
        Destroy(gameObject, time_before_destroy);
    }

    public IEnumerator FadeOutObject()
    {
        while (GetComponent<Renderer>().material.color.a > 1)
        {
            Color objectColor = GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            GetComponent<Renderer>().material.color = objectColor;

            yield return null;
        }
    }
}

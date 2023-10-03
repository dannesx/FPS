using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    private Image damageImage;
    public Color targetColor;
    public float fadeDuration = 0.1f;
    private float elapsedTime = 0f;

    void Start()
    {
        damageImage = GetComponent<Image>();
    }

    public void DamageEffect()
    {
        elapsedTime = 0f;
        damageImage.color = targetColor;
    }

    void Update()
    {
        damageImage.color = Color.Lerp(targetColor, Color.clear, elapsedTime / fadeDuration);
        elapsedTime += Time.deltaTime;
    }
}

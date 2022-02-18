using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// tuto : https://www.youtube.com/watch?v=v1UGTTeQzbo&ab_channel=DistortedPixelStudios

public class Heatlbar : MonoBehaviour
{
    public Slider slider;
    public Color lowLife;
    public Color highLife;
    public Vector3 offset;


    public void SetHealth(float health, float maxHealth){
        slider.gameObject.SetActive(health < maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(lowLife, highLife, slider.normalizedValue);

    }

    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}

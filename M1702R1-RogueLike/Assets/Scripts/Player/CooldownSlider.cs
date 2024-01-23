using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownSlider : MonoBehaviour
{
    [SerializeField] private Slider cdSlider;
    //public AudioSource soDisparo;


    public void UpdateSliderCooldown(float currentValue, float maxValue)
    {
        cdSlider.value = currentValue / maxValue;
        //soDisparo.Play();
    }
}

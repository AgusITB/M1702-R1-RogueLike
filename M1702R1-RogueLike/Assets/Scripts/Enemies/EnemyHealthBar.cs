using UnityEngine;
using UnityEngine.UI;


public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;

    // Update is called once per frame
    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        hpSlider.value = currentValue / maxValue;
    }
}

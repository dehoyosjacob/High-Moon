using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        SetMaxHealth(100);
    }

    void Update()
    {
        /*if(Input.GetKeyUp(KeyCode.V))
        {
            TakeDamage(20);
        }*/
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void TakeDamage(int damage)
    {
        slider.value -= damage;
    }

    public void HealDamage(int heal)
    {
        slider.value += heal;
    }
}

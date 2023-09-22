using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderUpdate : MonoBehaviour
{

    public Health health;
    public Slider slider;
    // Start is called before the first frame update
    
    private void OnEnable()
    {
        health.onHealthChanged += Health_onHealthChanged;
    }

    private void OnDisable()
    {
        health.onHealthChanged -= Health_onHealthChanged;
    }

    private void Health_onHealthChanged(float CurrentHealth)
    {
        slider.value = CurrentHealth;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}

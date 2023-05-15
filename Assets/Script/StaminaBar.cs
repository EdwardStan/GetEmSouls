using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace SE
{
    public class StaminaBar : MonoBehaviour
    {
        public Slider slider;
        private void Start()
        {
            slider = GetComponent<Slider>();
        }
        public void SetMaxValue(int maxStamina)
        {
            slider.maxValue = maxStamina;
            slider.value = maxStamina;

        }

        public void SetCurrentHealth(int currentStamina)
        {
            slider.value = currentStamina;
        }
    }
}



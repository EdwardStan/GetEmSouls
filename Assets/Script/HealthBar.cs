using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SE
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;
        private void Start()
        {
            slider= GetComponent<Slider>();
        }
        public void SetMaxValue(int maxHealth)
        {
            slider.maxValue = maxHealth;
            slider.value = maxHealth;

        }

        public void SetCurrentHealth(int currentHealth)
        {
            slider.value = currentHealth;
        }
    }

}

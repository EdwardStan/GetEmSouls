using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class PlayerStats : MonoBehaviour
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        public int staminaLevel = 10;
        public int maxStamina;
        public int currentStamina;

        public HealthBar healthBar;
        public StaminaBar staminaBar;

        AnimatorHandler animatorHandler;

        private void Awake()
        {
            animatorHandler= GetComponentInChildren<AnimatorHandler>();
        }
        private void Start()
        {
            maxStamina = SetMaxHealthFromHealthLevel();
            maxHealth = SetMaxHealthFromHealthLevel();
            currentStamina = maxStamina;
            currentHealth = maxHealth;
            healthBar.SetMaxValue(maxHealth);
            staminaBar.SetMaxValue(maxStamina);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        private int SetMaxStaminaFromStaminaLevel()
        {
            maxStamina = staminaLevel * 10;
            return maxStamina;
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;

            healthBar.SetCurrentHealth(currentHealth);

            animatorHandler.PlayTargetAnimation("TakeDamage", true);

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayTargetAnimation("Death", true);

                //Handle player death

            }
        }

        public void TakeStaminaDamage(int damage)
        {
            currentStamina = currentStamina - damage;
            staminaBar.SetCurrentHealth(currentStamina);
        }
    }
}
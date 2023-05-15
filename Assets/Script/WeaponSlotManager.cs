using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SE
{
    public class WeaponSlotManager : MonoBehaviour
    {
        WeaponHolderSlot leftHandSlot;
        WeaponHolderSlot rightHandSlot;

        DamageCollider leftHandDamagecollider;
        DamageCollider rightHandDamagecollider;

        Animator animator;

        public WeaponItem attackingWeapon;

        QuickSlotsUI quickSlotUI;

        PlayerStats playerStats;

        private void Awake()
        {
            playerStats = GetComponentInParent<PlayerStats>();
            animator = GetComponent<Animator>();
            quickSlotUI = FindObjectOfType<QuickSlotsUI>();

            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();

            foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if (weaponSlot.isLeftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }

                if (weaponSlot.isRightHandSlot)
                {
                    rightHandSlot = weaponSlot;
                }
            }
        }


        public void LoadWeaponOnSlot(WeaponItem weaponitem, bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.LoadWeaponModel(weaponitem);
                LoadLeftWeaponCollider();
                quickSlotUI.UpdateWeaponQuickSlots(true, weaponitem);

                if (weaponitem != null)
                {
                    animator.CrossFade(weaponitem.left_Hand_Idle, 0.2f);
                }
                else
                {
                    animator.CrossFade("Left Arm Empty", 0.2f);
                }
            }
            else
            {
                rightHandSlot.LoadWeaponModel(weaponitem);
                LoadRightWeaponCollider();
                quickSlotUI.UpdateWeaponQuickSlots(false, weaponitem);

                if (weaponitem != null)
                {
                    animator.CrossFade(weaponitem.right_Hand_Idle, 0.2f);
                }
                else
                {
                    animator.CrossFade("Right Arm Empty", 0.2f);
                }
            }

        }

        #region Handle Weapon's Damage Collider


        private void LoadLeftWeaponCollider()
        {
            leftHandDamagecollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }

        private void LoadRightWeaponCollider()
        {
            rightHandDamagecollider = rightHandSlot.currentWeaponModel?.GetComponentInChildren<DamageCollider>();
        }

        public void OpenRightDamageCollider()
        {
            rightHandDamagecollider.EnableDamageCoillider();
        }

        public void OpenLeftDamageCollider()
        {
            leftHandDamagecollider.EnableDamageCoillider();
        }

        public void CloseRightHandDamageCollider()
        {
            rightHandDamagecollider.DisableDamageCoillider();
        }

        public void CloseLeftHandDamageCollider()
        {
            leftHandDamagecollider.DisableDamageCoillider();
        }
        #endregion

        #region Handle Weapon's Stamina Damage
        public void DrainStaminaLightAttack()
        {
            playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.lightAttackMultiplier));
        }

        public void DrainStaminaHeavyAttack()
        {
            playerStats.TakeStaminaDamage(Mathf.RoundToInt(attackingWeapon.baseStamina * attackingWeapon.heavyAttackMultiplier));
        }
        #endregion

    }

}

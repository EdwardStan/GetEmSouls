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

        private void Awake()
        {
            animator = GetComponent<Animator>();

            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();

            foreach(WeaponHolderSlot weaponSlot in weaponHolderSlots)
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


        public void LoadWeaponOnSlot(WeaponItem weaponitem,bool isLeft)
        {
            if (isLeft)
            {
                leftHandSlot.LoadWeaponModel(weaponitem);
                LoadLeftWeaponCollider();

                if(weaponitem != null)
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


    }

}

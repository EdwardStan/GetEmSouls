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

        private void Awake()
        {
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
            }
            else
            {
                rightHandSlot.LoadWeaponModel(weaponitem);
                LoadRightWeaponCollider();
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

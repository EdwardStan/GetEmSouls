using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SE
{
    public class WeaponSlotManager : MonoBehaviour
    {
        WeaponHolderSlot leftHandSlot;
        WeaponHolderSlot rightHandSlot;
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
            }
            else
            {
                rightHandSlot.LoadWeaponModel(weaponitem);
            }

        }

    }

}

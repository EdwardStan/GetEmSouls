using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class EquipementWindowUI : MonoBehaviour
    {
        public bool rightHandSlot01Selectd;
        public bool rightHandSlot02Selectd;
        public bool leftHandSlot01Selected;
        public bool leftHandSlot02Selected;


        HandEquipementSlotUI[] handEquipementSlotsUI;

        private void Awake()
        {
            handEquipementSlotsUI = GetComponentsInChildren<HandEquipementSlotUI>();
        }

        public void LoadWeaponsOnEquipementScreen(PlayerInventory playerInventory)
        {
            for(int i = 0; i < handEquipementSlotsUI.Length; i++)
            {
                if (handEquipementSlotsUI[i].rightHandSlot01)
                {
                    handEquipementSlotsUI[i].AddItem(playerInventory.weaponsInRightHandSlots[0]);

                }
                else if (handEquipementSlotsUI[i].rightHandSlot02)
                {
                    handEquipementSlotsUI[i].AddItem(playerInventory.weaponsInRightHandSlots[1]);
                }
                else if (handEquipementSlotsUI[i].leftHandSlot01)
                {
                    handEquipementSlotsUI[i].AddItem(playerInventory.weaponsInLeftHandSlots[0]);

                }
                else /*if (handEquipementSlotsUI[i].leftHandSlot02)*/
                {
                    handEquipementSlotsUI[i].AddItem(playerInventory.weaponsInLeftHandSlots[1]);
                }
            }
        }

        public void SelectRightHandSlot01()
        {
            rightHandSlot01Selectd = true;
        }

        public void SelectLeftHandSlot01()
        {
            leftHandSlot01Selected = true;
        }

        public void SelectLeftHandSlot02()
        {
            leftHandSlot02Selected = true;
        }
        public void SelectRightHandSlot02()
        {
            rightHandSlot02Selectd = true;
        }
    }

}

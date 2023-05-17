using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SE
{
    public class UIManager : MonoBehaviour
    {
        public PlayerInventory playerInventory;
        EquipementWindowUI equipementWIndowUI;


        [Header("UI Windows")]
        public GameObject selectWindow;
        public GameObject hudWindow;
        public GameObject weaponInventoryWindow;


        [Header("WeaponInventory")]
        public GameObject weaponInventorySlotPrefab;

        public Transform weaponInventorySlotParent;

        WeaponInventorySlot[] weaponInventorySlots;

        private void Awake()
        {
            equipementWIndowUI = FindObjectOfType<EquipementWindowUI>();
        }

        private void Start()
        {
            weaponInventorySlots = weaponInventorySlotParent.GetComponentsInChildren<WeaponInventorySlot>();
            equipementWIndowUI.LoadWeaponsOnEquipementScreen(playerInventory);
        }
        public void UpdateUI()
        {
            #region Weapon Inventory Slots
            for (int i = 0; i < weaponInventorySlots.Length; i++)
            {
                if (i < playerInventory.weaponsInventory.Count)
                {
                    if( weaponInventorySlots.Length < playerInventory.weaponsInventory.Count )
                    {
                        Instantiate(weaponInventorySlotPrefab, weaponInventorySlotParent);
                        weaponInventorySlots = weaponInventorySlotParent.GetComponentsInChildren<WeaponInventorySlot>();
                    }

                    weaponInventorySlots[i].Additem(playerInventory.weaponsInventory[i]);
                }
                else
                {
                    weaponInventorySlots[i].ClearInventorySlot();
                }
            }
            #endregion
        }
        public void OpenSelectWindow()
        {
            selectWindow.SetActive(true);
        }

        public void CloseSelectWindow()
        {
            selectWindow.SetActive(false);
        }

        public void CloseAllInventoryWindows()
        {
            weaponInventoryWindow.SetActive(false);
        }
    }
}


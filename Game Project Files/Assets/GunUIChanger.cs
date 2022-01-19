using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUIChanger : MonoBehaviour {

    private WeaponSwitcher WeaponCheck = null;
    private int selectedWeapon;
    
    private void Awake()
    {
        WeaponCheck = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<WeaponSwitcher>();
    }

    void Update()
    {
        selectedWeapon = WeaponCheck.SelectedWeapon;
        SelectWeapon();
    }

        void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}

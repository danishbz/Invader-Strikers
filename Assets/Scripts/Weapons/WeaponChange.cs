using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChange : MonoBehaviour
{
    // Equip and Switch Multiple Weapons in Unity 2D | Weapon System Unity 2D
    // https://www.youtube.com/watch?v=-YISSX16NwE

    [SerializeField] private GameObject WeaponHolder, WeaponUI;

    private int TotalWeapons, CurrentWeaponIndex;
    private GameObject[] weaponsArr, weaponsUIArr;
    // Start is called before the first frame update
    void Start()
    {
        TotalWeapons = WeaponHolder.transform.childCount;
        weaponsArr = new GameObject[TotalWeapons];
        weaponsUIArr = new GameObject[TotalWeapons];
        for (int i = 0; i < TotalWeapons; i++ )
        {
            weaponsArr[i] = WeaponHolder.transform.GetChild(i).gameObject;
            weaponsArr[i].SetActive(false);
            weaponsUIArr[i] = WeaponUI.transform.GetChild(i).gameObject;
            weaponsUIArr[i].SetActive(false);
        }

        weaponsArr[0].SetActive(true);
        weaponsUIArr[0].SetActive(true);
        CurrentWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            //next weapon
            if(CurrentWeaponIndex < TotalWeapons - 1)
            {
                SFXManager.instance.playGunSwap();
                weaponsArr[CurrentWeaponIndex].SetActive(false);
                weaponsUIArr[CurrentWeaponIndex].SetActive(false);
                CurrentWeaponIndex += 1;
                weaponsArr[CurrentWeaponIndex].SetActive(true);
                weaponsUIArr[CurrentWeaponIndex].SetActive(true);
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            //previous weapon
            if(CurrentWeaponIndex > 0)
            {
                SFXManager.instance.playGunSwap();
                weaponsArr[CurrentWeaponIndex].SetActive(false);
                weaponsUIArr[CurrentWeaponIndex].SetActive(false);
                CurrentWeaponIndex -= 1;
                weaponsArr[CurrentWeaponIndex].SetActive(true);
                weaponsUIArr[CurrentWeaponIndex].SetActive(true);
            }
        }
    }
}

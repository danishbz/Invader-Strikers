using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    // Equip and Switch Multiple Weapons in Unity 2D | Weapon System Unity 2D
    // https://www.youtube.com/watch?v=-YISSX16NwE
    int TotalWeapons = 1;
    public int CurrentWeaponIndex;
    public GameObject[] weapons;
    public GameObject WeaponHolder;
    public GameObject CurrentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        TotalWeapons = WeaponHolder.transform.childCount;
        weapons = new GameObject[TotalWeapons];
        for (int i = 0; i < TotalWeapons; i++ )
        {
            weapons[i] = WeaponHolder.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);
        CurrentWeapon = weapons[0];
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
                weapons[CurrentWeaponIndex].SetActive(false);
                CurrentWeaponIndex += 1;
                weapons[CurrentWeaponIndex].SetActive(true);
                CurrentWeapon = weapons[CurrentWeaponIndex];
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            //previous weapon
            if(CurrentWeaponIndex > 0)
            {
                weapons[CurrentWeaponIndex].SetActive(false);
                CurrentWeaponIndex -= 1;
                weapons[CurrentWeaponIndex].SetActive(true);
                CurrentWeapon = weapons[CurrentWeaponIndex];
            }
        }
    }
}

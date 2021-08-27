using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    private Transform[] weaponHolder;
    [SerializeField]
    private Gun startingGun;
    private Gun[] equippedGun;

    private void Start() 
    {
        equippedGun = new Gun[weaponHolder.Length];
        if(startingGun != null)
        {
            EquipGun(startingGun);
        }    
    }

    public void EquipGun(Gun gunToEquip)
    {
        for (int i = 0; i < weaponHolder.Length; i++)
        {
            if(equippedGun[i] != null)
            {
                Destroy(equippedGun[i].gameObject);
            }   
            equippedGun[i] = Instantiate(gunToEquip, weaponHolder[i].transform);
            equippedGun[i].transform.parent = weaponHolder[i];
        }
    }

    public void Shoot()
    {
        foreach (Gun gun in equippedGun)
        {
            gun.Shoot();
        }
    }
}

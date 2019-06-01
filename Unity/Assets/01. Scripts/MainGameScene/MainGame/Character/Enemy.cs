using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    override protected void CreateWeapon()
    {
        _weaponList.Clear();

        for (int i = 0; i < 5; i++)
        {
            {
                WeaponData weaponData = new WeaponData();
                weaponData.shotSpeed = 0.1f;
                weaponData.shotCount = i + 1;
                weaponData.angleRate = (float)((i + 1) * 2);
                weaponData.bulletSpeedRate = 0.0f;
                weaponData.bulletAngleRate = 0.0f;
                weaponData.changeInterval = 4.0f;
                weaponData.bulletPrefab = _bulletPrefabs[i];

                SpiralWeapon spiralWeapon = new SpiralWeapon();
                spiralWeapon.Init(this, weaponData);
                _weaponList.Add(spiralWeapon);
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    override protected void CreateWeapon()
    {
        _weaponList.Clear();
        /*
        {
            SpiralWeapon spiralWeapon = new SpiralWeapon();
            spiralWeapon.SetOwner(this);
            spiralWeapon.SetAngleRate(10.0f);
            spiralWeapon.SetBulletSpeedRate(5.0f);
            spiralWeapon.SetBulletAngleRate(10.0f);
            _spiralWeaponList.Add(spiralWeapon);
        }
        */

        WeaponData weaponData = new WeaponData();
        weaponData.shotSpeed = 0.1f;
        weaponData.shotCount = 1;
        weaponData.angleRate = 0.0f;
        weaponData.bulletSpeedRate = 0.0f;
        weaponData.bulletAngleRate = 0.0f;
        weaponData.changeInterval = 0.0f;
        weaponData.bulletPrefab = _bulletPrefabs[0];

        SpiralWeapon spiralWeapon = new SpiralWeapon();
        spiralWeapon.Init(this, weaponData);
        _weaponList.Add(spiralWeapon);

        //Dictionary<name, Bomb>
    }
}

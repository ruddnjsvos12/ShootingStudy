﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralWeapon 
{

    float _shotSpeed = 0.1f;
    float _shotDuration = 0.0f;
    float _shotAngle = 0.0f;
    protected float _shotAngleRate = 10.0f;

    int _shotCount = 1;

    protected float _bulletSpeedRate = 0.0f;
    protected float _bulletAngleRate = 0.0f;

    Character _owner;

    public void SetOwner(Character owner)
    {
        _owner = owner;
    }

    virtual public void SetAngleRate(float angleRate)
    {
        _shotAngleRate = angleRate;
    }

    public void SetBulletSpeedRate(float speedRate)
    {
        _bulletSpeedRate = speedRate;
    }

    public void SetBulletAngleRate(float angleRate)
    {
        _bulletAngleRate = angleRate;
    }
    public void SetShotCount(int shotCount)
    {
        _shotCount = shotCount;
    }

    public void Fire(GameObject bulletPrefab)
    {
        if (_shotSpeed < _shotDuration)
        {
            _shotDuration = 0.0f;
            for (int i = 0; i < _shotCount; i++)
            {
                float shotAngle = _shotAngle + (360.0f * ((float)i / (float)_shotCount));
                CreateBullet(bulletPrefab, shotAngle);
            }
            _shotAngle += _shotAngleRate;

        }

        _shotDuration += Time.deltaTime;
    }


    void CreateBullet(GameObject bulletPrefab, float shotAngle)
    {
        // 총알을 생성
        GameObject bulletObject = GameObject.Instantiate<GameObject>(bulletPrefab);
        Vector3 bulletPos = _owner.transform.position + (_owner.transform.up * 1.0f);
        bulletObject.transform.position = bulletPos;
        bulletObject.transform.rotation = _owner.transform.rotation;

        bulletObject.transform.Rotate(Vector3.up, shotAngle);

        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.SetShotCharacterType(_owner.GetCharacterType());


        //bulletObject.transform.Rotate(Vector3.up, _curTestRot);
        //_curTestRot += 30;
    }

    virtual public void Update()
    {

    }
}
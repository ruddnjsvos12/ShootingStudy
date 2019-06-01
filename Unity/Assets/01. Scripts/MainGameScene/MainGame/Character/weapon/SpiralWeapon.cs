using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct WeaponData
{
    public float shotSpeed;
    public int shotCount;

    public float angleRate;
    public float bulletSpeedRate;
    public float bulletAngleRate;

    public float changeInterval;

    public GameObject bulletPrefab;
}

public class SpiralWeapon 
{
    GameObject target;
    Character _owner;

    //float _shotSpeed = 0.1f;
    float _shotDurataion = 0.0f;

    float _shotAngle = 0.0f;
    protected float _shotAngleRate = 20.0f;

    float _bulletSpeedRate = 0.0f;
    protected float _bulletAngleRate = 0.0f;

    //int _shotCount = 4;

    protected WeaponData _weaponData;

    virtual public void Init(Character owner, WeaponData weaponData)
    {
        _owner = owner;

        _weaponData = weaponData;
        _shotAngleRate = _weaponData.angleRate;
        _bulletSpeedRate = _weaponData.bulletSpeedRate;
        _bulletAngleRate = _weaponData.bulletAngleRate;
    }

    public void Fire(GameObject target)
    {
        if (_weaponData.shotSpeed < _shotDurataion)
        {
            _shotDurataion = 0.0f;
            for (int i = 0; i < _weaponData.shotCount; i++)
            {
                float shotAngle = _shotAngle +
                    (360.0f * ((float)i / (float)_weaponData.shotCount));
                //CreateBullet(bulletPrefab, shotAngle, target);
                CreateBullet(_weaponData.bulletPrefab, shotAngle, target);
            }
            _shotAngle += _shotAngleRate;
        }
        _shotDurataion += Time.deltaTime;
    }


    void CreateBullet(GameObject bulletPrefab, float shotAngle, GameObject target)
    {
        // 총알을 생성
        GameObject bulletObject = GameObject.Instantiate<GameObject>(bulletPrefab);
        Vector3 bulletPos = _owner.transform.position + (_owner.transform.up * 1.0f);
        bulletObject.transform.position = bulletPos;
        bulletObject.transform.rotation = _owner.transform.rotation;

        //타겟이 있으면, 타켓을 향해 방향을 세팅한다.
        //bulletObject.transform.Rotate = _owner.transform.rotation;

        if (null != target)
        {
            //타겟을 향해 방향을 세팅한다.
            Vector3 targetPos = target.transform.position;
            targetPos.y = bulletPos.y;

            bulletObject.transform.LookAt(targetPos);
        }
        else
        {
            bulletObject.transform.rotation = _owner.transform.rotation;
        }
        bulletObject.transform.Rotate(Vector3.up, shotAngle);

        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.SetShotCharacterType(_owner.GetCharacterType());
        bullet.SetTarget(target);

        //bulletObject.transform.Rotate(Vector3.up, _curTestRot);
        //_curTestRot += 30;
    }

    virtual public void Update()
    {

    }
}

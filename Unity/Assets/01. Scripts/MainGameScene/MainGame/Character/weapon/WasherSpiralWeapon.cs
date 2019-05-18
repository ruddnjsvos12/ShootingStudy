using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasherSpiralWeapon : SpiralWeapon
{
    float _changeIntervere = 1.0f;
    float _changeDuration = 0.0f;

    float _originalShotAngleRate;
    float _originalBulletAngleRate;
    float _updateShotAngleRate;
    float _updateBulletAngleRate;

    override public void SetAngleRate(float angleRate)
    {
        _shotAngleRate = angleRate;
        _originalShotAngleRate = angleRate;
        _originalBulletAngleRate = angleRate;
    }

    override public void Update()
    {
        /*
        if (_changeIntervere <= _changeDuration)
        {
            _changeDuration = 0.0f;

            // 방향을 바꿔준다.
            SetAngleRate(-_shotAngleRate);
            SetBulletSpeedRate(-_bulletSpeedRate);
        }*/

        

        if (_changeDuration < 1.0f)
        {
            _shotAngleRate = _originalShotAngleRate;
            _bulletAngleRate = _originalBulletAngleRate;
        }

        else if (_changeDuration < 2.0f)
        {
            //_updateShotAngleRate, _updateBulletAngleRate 값을 변화
            _updateShotAngleRate = _originalShotAngleRate * (1.5f - _changeDuration);
            _updateBulletAngleRate = _originalBulletAngleRate * (1.5f - _changeDuration);
            _shotAngleRate = _updateShotAngleRate;
            _bulletAngleRate = _updateBulletAngleRate;
        }

        else if (_changeDuration < 3.0f)
        {
            _shotAngleRate = -_originalShotAngleRate;
            _bulletAngleRate = -_originalBulletAngleRate;
        }

        else if (_changeDuration < 4.0f)
        {
            //_updateShotAngleRate, _updateBulletAngleRate 값을 변화 
            _updateShotAngleRate = -_originalShotAngleRate * (3.5f - _changeDuration);
            _updateBulletAngleRate = -_originalBulletAngleRate * (3.5f - _changeDuration);
            _shotAngleRate = _updateShotAngleRate;
            _bulletAngleRate = _updateBulletAngleRate;
        }
        else
        {
            _changeDuration = 0.0f;
        }

        _changeDuration += Time.deltaTime;
    }
}

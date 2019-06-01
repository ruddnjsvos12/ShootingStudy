using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//일정 시간을 체크에 쓰이는 일반적인 알고리즘

/*
{
    if(interval <=duration{
        duration = 0.0f;
        //todo
    }
    // duration 증가
    duration += Time.deltaTime;
}
*/

public class Bullet : MonoBehaviour
{
    
    float _speed = 1.5f;
    float _speedRate = 1.0f; //가속도

    float _angle = 0.0f;
    float _angleRate = 0.0f;

    GameObject _target = null;

    float _aimingInterval = 1.0f;
    float _aimingTime = 0.0f;

    void Start ()
    {
        Destroy(gameObject, 10.0f);
	}

    //float _curTestRot = 0;	 // 임시 변수
    void Update ()
    {
		Vector3 curPos = transform.position;
		Vector3 nextPos = curPos + (transform.forward * _speed * Time.deltaTime);
		transform.position = nextPos;

        _speed += (_speedRate * Time.deltaTime);

        // 타겟이 있으면 타겟을 바라본다.
        if(null != _target)
        {
            if(_aimingInterval <= _aimingTime)
            {
                _aimingTime = 0.0f;
                // 타겟을 바라본다.
                Vector3 targetPos = _target.transform.position;
                targetPos.y = transform.position.y;
                transform.LookAt(targetPos); // 여기선 회전하지 않는다.
                // 일정 주기가 되면 목표 각도를 세팅
            }
            else
            {
                _aimingTime += Time.deltaTime;
                // 목표 각도로 조금씩 회전
            }
        }
        else
        {
            transform.Rotate(Vector3.up, _angle);
            _angle += (_angleRate * Time.deltaTime);
        }

        transform.Rotate(Vector3.up, _angle);
        _angle += (_angleRate * Time.deltaTime);
		//transform.Rotate(Vector3.up, _curTestRot);
		//_curTestRot -= 0.01f;
	}

	[SerializeField] GameObject _effectPrefab;
    void OnTriggerEnter(Collider other)
    {
		// 총알
		// 태그가 캐릭터이면
		// other.gameObject 에서 캐릭터 스크립트 컴포넌트를 뽑아냄
		// 죽었으면, 패스
		// 태그가 건물이면
		// other.gameObject 에서 건물 스크립트 컴포넌트를 뽑아냄
		// 죽었으면(파괴되었으면), 패스
		// 우리게임에서 사용하는 게임 오브젝트인가?
		// 공통된 스크립트 컴포넌트를 뽑아냄.
		// 컴포넌트가 충돌 가능한가를 체크.
		// 충돌 또는 패스

		// 내 총알의 주인이 부딪쳤으면 패스
		if (true == other.gameObject.tag.Equals("Character"))
		{
			Character character = other.gameObject.GetComponent<Character>();
			if (_shotCharType == character.GetCharacterType())
				return;
		}


		// 폭발 효과 실행 (스프라이트)
		GameObject effObject = GameObject.Instantiate(_effectPrefab);
		effObject.transform.position = transform.position;
		effObject.transform.localScale = Vector3.one;
		Destroy(effObject, 1.5f);

		Destroy(gameObject);
	}

	Character.CharType _shotCharType;

	public Character.CharType ShotCharacterType()
	{
		return _shotCharType;
	}

	public void SetShotCharacterType(Character.CharType charType)
	{
		_shotCharType = charType;
	}

    public void SetSpeedRate(float rate)
    {
        _speedRate = rate;
    }

    public void SetAngleRate(float rate)
    {

        _angleRate = rate;
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }
}

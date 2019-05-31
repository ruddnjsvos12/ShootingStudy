using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{
    [SerializeField] GameObject _parentObject;
    [SerializeField] GameObject _characterPrefab;
    List<GameObject> _wayPointList;
    Character character;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    public void Generate()
    {
        
        if (DataCenter.GetInstance().GetCount() < 5)
        {
            //이 네줄은 그냥 외우기
            GameObject obj = GameObject.Instantiate<GameObject>(_characterPrefab);
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.identity;
            obj.transform.localScale = Vector3.one;
            obj.transform.SetParent(_parentObject.transform);

            character = obj.GetComponent<Character>();
            character.SetBossPoint(gameObject);
            DataCenter.GetInstance().AddCount();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(character.GetStateType() == Character.eState.DEATH)
        {
            Generate();
        }
        */
    }


}

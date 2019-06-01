using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameScene : MonoBehaviour
{
    int _stage = 0;
    
    void Start()
    {
        _stage = DataCenter.GetInstance().GetStage();

        CreateCharacters(); // 캐릭터를 생성해서
        BatchCharacters(); // 맵에 배치
    }

    void Update()
    {
        Character character = _enemy.GetComponent<Character>();
        
        if (true == character.IsDead())
        {
            DataCenter.GetInstance().NextStage();
            SceneManager.LoadScene("MainGameScene");
        }
    }

    //Characters

    [SerializeField] GameObject _playerPrefab;
    [SerializeField] List<GameObject> _enemyPrefabs;

    GameObject _player;
    GameObject _enemy;

    void CreateCharacters()
    {
        // Players
        _player = GameObject.Instantiate<GameObject>(_playerPrefab);
        //_enemy = GameObject.Instantiate<GameObject>(_enemyPrefab);

        /*
        _enemies.Clear();
        for(int i = 0; i < _enemyPrefabs.Count; i++)
        {
            GameObject enemy = GameObject.Instantiate<GameObject>(_enemyPrefabs[i]);
            _enemies.Add(enemy);
        }*/
    
        // Enemy (Boss)

        _enemy = GameObject.Instantiate<GameObject>(_enemyPrefabs[_stage]);
    }

    void BatchCharacters()
    {
        // _player 배치
        _player.transform.SetParent(transform); // 플레이어를 MainGame의 자식으로 만들어줌.
        _player.transform.localScale = Vector3.one;
        _player.transform.localPosition = new Vector3(0, 0, -5.84f);
        _player.transform.localRotation = new Quaternion(0, 0, 0, 0);

        // _enemy 베치

        /*
        if(_stage < _enemies.Count)
        {
            _enemies[_stage].transform.SetParent(transform); // 플레이어를 MainGame의 자식으로 만들어줌.
            _enemies[_stage].transform.localScale = Vector3.one;
            _enemies[_stage].transform.localPosition = new Vector3(0, 0, 5.59f);
            _enemies[_stage].transform.localRotation = new Quaternion(0, 180, 0, 0);
        }
        */
        _enemy.transform.SetParent(transform); // 플레이어를 MainGame의 자식으로 만들어줌.
        _enemy.transform.localScale = Vector3.one;
        _enemy.transform.localPosition = new Vector3(0, 0, 5.59f);
        _enemy.transform.localRotation = new Quaternion(0, 180, 0, 0);
        
    }
}

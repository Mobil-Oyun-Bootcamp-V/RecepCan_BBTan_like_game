using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    Vector3 _spawnPos;

    void Start()
    {
        for(int i = 0; i < 20; i++)
        {
            float x = Random.Range(-1f, 1f);
            float z = Random.Range(11f, 13f);
            _spawnPos = new Vector3(x, 0, z);
            Instantiate(_enemy, _spawnPos, Quaternion.identity);
        }
    }
}

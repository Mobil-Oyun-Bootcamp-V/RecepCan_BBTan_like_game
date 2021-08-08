using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChibiEnemy : MonoBehaviour
{
    Rigidbody _rb;
    Vector3 _originalPos;
    [SerializeField] float _speed;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _originalPos = new Vector3(0, 0, 12);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = (_originalPos - transform.position) * _speed;
    }
}

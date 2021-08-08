using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Camera _cam;
    Vector3 _camPos;
    Vector3 hitPoint;
    [SerializeField] LineRenderer _line1;
    [SerializeField] LineRenderer _line2;
    [SerializeField] GameObject _ball;
    [SerializeField] int _ammo;
    public Vector3 HitPoint { get => hitPoint; set => hitPoint = value; }
    private void Start() 
    {
        _cam = Camera.main;    
    }
    private void Update() 
    {
        PlayerRotate();
        if(Input.GetMouseButton(0))
        {
            AimProjection();
        }
        Shoot();
    }
    void PlayerRotate()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            _camPos = new Vector3(hit.point.x, 0, hit.point.z);
        }
        transform.LookAt(_camPos, Vector3.up);
    }
    void AimProjection()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position + Vector3.up, transform.forward * 15f, out hit))
        {
            HitPoint = hit.point;
            float distance = Vector3.Distance(_line1.transform.position, hit.point);
            _line1.SetPosition(1, new Vector3(0f, 0.5f, distance));
            _line2.enabled = true;
            float yRot = -transform.eulerAngles.y;
            Quaternion rot = Quaternion.Euler(0, yRot, 0);
            _line2.transform.localRotation = rot;
            _line2.transform.position = hit.point - Vector3.up;
            float line2Distance = 15f - distance;
            _line2.SetPosition(1, new Vector3(0, 0.5f, Mathf.Clamp(line2Distance, 2f, 10f)));
        }
        else
        {
            _line2.enabled = false;
        }
    }
    void Shoot()
    {
        if(Input.GetMouseButtonUp(0))
        {
            StartCoroutine(ShootRout());
        }
    }
    IEnumerator ShootRout()
    {
        for(int i = 0; i < _ammo; i++)
        {
            GameObject ball = Instantiate(_ball, transform.position + transform.forward + Vector3.up / 2f,
             transform.rotation);
             Rigidbody _rb = ball.GetComponent<Rigidbody>();
             _rb.velocity = transform.forward * Time.deltaTime * 500f;
            yield return new WaitForSeconds(0.3f);
        }
    }
    public void AddBall()
    {
        _ammo++;
    }
    public void ExplosionBall()
    {
        //TODO
    }
}

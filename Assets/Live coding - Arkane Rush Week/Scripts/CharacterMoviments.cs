using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoviments : MonoBehaviour
{

    public GameObject Bullet;
    public float TimeToShot = 0.5f;
    public Transform ShotPosition;

    public float Speed = 10;

    private Rigidbody _rigidbody;
    private float _timeToShot = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_timeToShot > 0)
        {
            _timeToShot -= Time.deltaTime;
        } else
        {
            if (Input.GetMouseButton(0))
            {
                Bullet bullet = Instantiate(Bullet, ShotPosition.position, Quaternion.identity).GetComponent<Bullet>();
                Vector3 dir = (ShotPosition.position - transform.position).normalized;
                bullet.Direction = new Vector3(dir.x, 0, dir.z);
                _timeToShot = TimeToShot;
            }
        }

    }

    void FixedUpdate()
    {
        moviment();
    }

    private void moviment()
    {
        float dx = 0;
        float dz = 0;

        if (Input.GetKey(KeyCode.W))
        {
            dz = 1;
        } else if (Input.GetKey(KeyCode.S))
        {
            dz = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dx = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dx = 1;
        }

        if (dz > 0)
            transform.eulerAngles = new Vector3(0,180,0);
        else if (dz < 0)
            transform.eulerAngles = new Vector3(0, 0, 0);

        if (dx > 0)
        {
            if(dz == 0)
                transform.eulerAngles = new Vector3(0, 270, 0);
            else
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 45 * dz, 0);
        }
        else if (dx < 0)
        {
            if (dz == 0)
                transform.eulerAngles = new Vector3(0, 90, 0);
            else
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 45 * -dz, 0);
        }

        _rigidbody.velocity = new Vector3(dx,0,dz) * Speed;
        _rigidbody.angularVelocity = Vector3.zero;

    }

}

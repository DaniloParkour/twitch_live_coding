using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector3 Direction = Vector3.right;
    public float Speed = 20;

    private float _timeToDestroy = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        _timeToDestroy -= Time.deltaTime;
        if (_timeToDestroy < 0)
            Destroy(gameObject);

        transform.Translate(Direction * Speed * Time.deltaTime);
    }
}

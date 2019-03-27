using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    public float moveSpeed = 2f;
    public float smoothTIme = 0.2f;
    private Vector3 _velocity = Vector3.zero;
    private int _test = 0;

    // Update is called once per frame
    void Update()
    {
        _test++;
        Vector3 targetPos = new Vector3((_target.position.x + moveSpeed*Time.deltaTime), _target.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, smoothTIme);
        if (_test % 1000 == 0)
        {

            Debug.Log("trying to transform cameara"+_test);
            transform.Rotate(0, 0, 20);
            //transform.Rotate= new Vector3.SmoothDamp(transform.rotation, new Vector3(0,0,100), ref _velocity, smoothTIme);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    public float smoothTIme = 0.2f;
    private Vector3 _velocity = Vector3.zero;


    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(_target.position.x + 2f, _target.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, smoothTIme);
    }
}

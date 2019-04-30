using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    public float baseSpeed = 6f;
    public float slowFactor = 0.9f;
    public float fastFactor = 4f;
    public float speedSmoothTIme = 0.2f;
    public float rotateSpeed = 0.1f;

    float tar_angle = 0;
    private Quaternion tar_rot;
    private float _moveSpeed = 2f;

    private Vector3 _velocity = Vector3.zero;
    private Vector3 _targetPos;
    private void Start()
    {
        int ifFirst = 0;
        StartCoroutine(ChangeCarmera(ifFirst));
        _moveSpeed = baseSpeed;
    }
    // Update is called once per frame
    void Update()
    {

        //for camera to constantly rotate
        //transform.Rotate(0, 0, tar_angle*rotateSpeed* Time.deltaTime);

        //rotate by stage
        transform.rotation = Quaternion.Lerp(transform.rotation,tar_rot,rotateSpeed);


        //move with the player
        float dif = _target.transform.position.x - transform.position.x;

        if (dif > 0.5f)
        {
          
            _moveSpeed = baseSpeed *fastFactor;

        }
        else if (-1< dif && dif < 0.5f)
        {
            _moveSpeed = baseSpeed;

        }
        else
        {
            _moveSpeed = baseSpeed * slowFactor;
        }
        _targetPos = new Vector3((transform.position.x + _moveSpeed * Time.deltaTime), _target.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, _targetPos, ref _velocity, speedSmoothTIme);
    }

    public IEnumerator ChangeCarmera(int ifFirst)
    {   
        if (ifFirst == 0)
        {
            ifFirst++;
            yield return new WaitForSeconds(10);
        }
        while (true)
        {
            rotateSpeed = Random.Range(0.01f,0.2f);
            int waitTime = Random.Range(3, 10);
            tar_angle = Random.Range(-120, 120);
            tar_rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, tar_angle);
            Debug.Log("trying to rotate cameara");
            yield return new WaitForSeconds(waitTime);
        }

    }
}

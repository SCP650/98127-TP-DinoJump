using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    public float moveSpeed = 2f;
    public float speedSmoothTIme = 0.2f;
    public float rotateSpeed = 0.1f;
    float tar_angle = 0;

    private Vector3 _velocity = Vector3.zero;
    private void Start()
    {
        StartCoroutine(ChangeCarmera());
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3((_target.position.x + moveSpeed*Time.deltaTime), _target.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref _velocity, speedSmoothTIme);
        //transform.rotation = Quaternion.Euler(Vector3.forward * Mathf.SmoothDampAngle(transform.rotation.z, tar_angle, ref rotateSmoothSpeed, rotateSmoothTIme));
        transform.Rotate(0, 0, tar_angle*rotateSpeed* Time.deltaTime);
    }

    public IEnumerator ChangeCarmera()
    {
        while (true)
        {
            rotateSpeed = Random.Range(-0.2f,0.2f);
            int waitTime = Random.Range(3, 10);
            tar_angle = Random.Range(-180, 180);
            Debug.Log("trying to transform cameara");
            yield return new WaitForSeconds(waitTime);


        }

    }
}

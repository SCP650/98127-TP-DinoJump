using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpForce = 2.0f;
    private Rigidbody2D _body;
    //Press botton player will move right
    private void Start()
    {
        _body = this.GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        float deltaX = speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x+deltaX, transform.position.y, transform.position.z) ;
    }
    //Press botton player will jump
    public void playerJump()
    {
        _body.AddForce(jumpForce * (Vector2.up), ForceMode2D.Impulse);
        

        transform.Rotate(0, 0, Random.Range(-90f, 90f));
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public GameObject stick;
    public float shootPower;
    Rigidbody ballRb;
    bool isShot = false;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        ballRb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShot)
        {
            transform.position = stick.transform.position;
            transform.position += new Vector3(0, 0.3f, 0);
        }
        else
        {

        }
        if (Input.GetKeyDown(KeyCode.Space) && !isShot)
        {
            Shoot();
            isShot = true;
        }
    }

    private void Shoot()
    {
        ballRb.AddForce(new Vector3(transform.position.x, 1, 0).normalized * shootPower);
        velocity = ballRb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Vertical"))
        {
            ballRb.velocity = new Vector3(-velocity.x,velocity.y,velocity.z);
            velocity = ballRb.velocity;
            /*
            collision.gameObject.SetActive(false);*/
        }
        if (collision.transform.tag.Equals("Horizontal"))
        {
            ballRb.velocity.Set(ballRb.velocity.x, -ballRb.velocity.y, ballRb.velocity.z);
        }
    }
}

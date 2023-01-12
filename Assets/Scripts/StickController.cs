using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class StickController : MonoBehaviour
{
    public float moveSpeed;
    float xMove;
    // Start is called before the first frame update
    void Start()
    {/*
        body= GetComponent<Rigidbody>();*/
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {/*
        body.velocity = new Vector3(xMove*moveSpeed*Time.deltaTime, 0, 0);*/
        float xPos = transform.position.x + xMove * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(Math.Clamp(xPos,-2,2),-4,0);
    }
}

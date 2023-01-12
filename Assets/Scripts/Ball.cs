using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float moveSpeed;
    public StickController stick;
    public bool isDead;

    Vector2 moveVec;
    bool isShot;

    // Start is called before the first frame update
    void Start()
    {
        moveVec= Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isShot && Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            isShot = true;
        }
    }
    private void FixedUpdate()
    {
        if (!isShot)
        {
            transform.position = stick.transform.position + new Vector3(0, 0.25f, 0);
        }
        else
        {
            transform.Translate(moveVec * moveSpeed * Time.deltaTime);
        }
    }

    private void Shoot()
    {
        moveVec = new Vector2(transform.position.x, 1).normalized;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Transform parent = collision.transform.parent;
        if (parent != null && parent.tag.Equals("Brick"))
        {
            parent.gameObject.SetActive(false);
        }
        if (collision.transform.tag.Equals("vReflect"))
        {
            moveVec = new Vector2(-moveVec.x, moveVec.y).normalized;
        }
        if (collision.transform.tag.Equals("hReflect"))
        {
            moveVec = new Vector2(moveVec.x, -moveVec.y).normalized;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Floor"))
        {
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float moveSpeed = 5f;
    public float jumpSpeed = 250f;

    private Rigidbody body;
    private bool spawned = false;

    private int moveDir = 0;
    private bool movingHorizontal;

    public void Spawn()
    {
        if (!spawned) {
            gameObject.SetActive(true);
            gameObject.AddComponent<Rigidbody>();
            body = GetComponent<Rigidbody>();
            spawned = true;
        }
    }

    private void Update()
    {
        if(movingHorizontal)
        {
            transform.Translate(new Vector3(moveDir, 0, 0) * moveSpeed * Time.deltaTime);
        }
    }

    public void StartMoveLeft()
    {
        if(spawned)
        {
            moveDir = -1;
            movingHorizontal = true;
        }
    }

    public void StartMoveRight()
    {
        if (spawned)
        {
            moveDir = 1;
            movingHorizontal = true;
        }
    }

    public void StopMoving()
    {
        moveDir = 0;
        movingHorizontal = false;
    }

    public void Jump()
    {
        if (spawned)
            body.AddForce(Vector3.up * jumpSpeed);
    }
}

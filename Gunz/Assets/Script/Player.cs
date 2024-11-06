using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerrRigid;
    public float walkSpeed;
    public Transform playerTrans;

    void Start()
    {
        
    }

    // 물리처리 연산을 위해 주기적으로 호출 
    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            playerrRigid.velocity = (transform.forward + -transform.right).normalized * walkSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            playerrRigid.velocity = (transform.forward+ transform.right).normalized * walkSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            playerrRigid.velocity = (-transform.forward + -transform.right).normalized * walkSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            playerrRigid.velocity = (-transform.forward + transform.right).normalized * walkSpeed * Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerrRigid.velocity = transform.forward * walkSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                playerrRigid.velocity = -transform.forward * walkSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                playerrRigid.velocity = transform.right * walkSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {
                playerrRigid.velocity = -transform.right * walkSpeed * Time.deltaTime;
            }
        }
    }

    // 매 프레임마다 호출되며 게임 로직 및 애니메이션 동작 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("forward");
            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("forward");

            if(!Input.anyKey)
                playerAnim.SetTrigger("idle");
            else
            {
                playerAnim.ResetTrigger("idle");

                if(Input.GetKey(KeyCode.A))
                    playerAnim.SetTrigger("left");

                if(Input.GetKey(KeyCode.D))
                    playerAnim.SetTrigger("right");
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("back");
            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("back");
            if (!Input.anyKey)
                playerAnim.SetTrigger("idle");
            else
            {
                playerAnim.ResetTrigger("idle");

                if (Input.GetKey(KeyCode.A))
                    playerAnim.SetTrigger("left");

                if (Input.GetKey(KeyCode.D))
                    playerAnim.SetTrigger("right");
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if(!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
                playerAnim.SetTrigger("left");

            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnim.ResetTrigger("left");
            if (!Input.anyKey)
                playerAnim.SetTrigger("idle");
            else
                playerAnim.ResetTrigger("idle");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
                playerAnim.SetTrigger("right");
            playerAnim.ResetTrigger("idle");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.ResetTrigger("right");
            if (!Input.anyKey)
                playerAnim.SetTrigger("idle");
            else
                playerAnim.ResetTrigger("idle");
        }
    }
}

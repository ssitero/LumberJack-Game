using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour


{
    readonly float speed = 5;
    readonly float rotSpeed = 100;
    readonly float gravity = 100;
    float rot = 0f;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;
   
    void Start()
    {
        controller = GetComponent < CharacterController > ();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        GetInput();
    }

    void Movement()
    {
        if (controller.isGrounded)
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                if (anim.GetBool("attacking") == true)
                {
                    return;
                }
                else
                {
                    anim.SetBool("running", true);
                    anim.SetInteger("condition", 1);
                    moveDir = new Vector3(0, 0, 1);
                    moveDir *= speed;
                    moveDir = transform.TransformDirection(moveDir);
                }
            }

            if (Input.GetAxisRaw("Vertical") == 0)
            {
                anim.SetBool("running", false);
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }

            if (Input.GetAxisRaw("Vertical") < 0)
            {
                if (anim.GetBool("attacking") == true)
                {
                    return;
                }
                else
                {
                    anim.SetBool("running", true);
                    anim.SetInteger("condition", 1);
                    moveDir = new Vector3(0, 0, -1);
                    moveDir *= speed;
                    moveDir = transform.TransformDirection(moveDir);
                }
            }
        }

        rot += Input.GetAxisRaw("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    void GetInput()
    {
        if (controller.isGrounded)
        {
            if (Input.GetButton("Fire1"))
            {
                if (anim.GetBool("running") != true)
                {
                    Attacking();
                }
                else
                {
                    anim.SetBool("running", false);
                    anim.SetInteger("condition", 0);
                }
            }
        }
    }

    void Attacking()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        anim.SetBool("attacking", true);
        anim.SetInteger("condition", 2);
        yield return new WaitForSeconds(0.5f);
        anim.SetInteger("condition", 0);
        anim.SetBool("attacking", false);
    }
}

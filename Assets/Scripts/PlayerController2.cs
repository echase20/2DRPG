using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController2 : MonoBehaviour
{
    public float speed;
    private Vector2 input;
    private bool isMoving;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    public void Update()
    {
        if (!isMoving) 
        { 
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
            if (input.x != 0) input.y = 0;
            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                isMoving = true;
                Vector3 moveDirection = new Vector3(input.x, input.y, 0f);

                transform.position += moveDirection * speed * Time.deltaTime;
            }
        }
        animator.SetBool("isMoving", isMoving);
        isMoving = false;
    }
}


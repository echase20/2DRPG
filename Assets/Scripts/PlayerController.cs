using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 input;
    private bool isMoving;
    private Animator animator;

    private Vector2 lastmove;

    public LayerMask solidObjects;

    public LayerMask interactableObjects;

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
                var targetPos = transform.position;
                targetPos.x += input.x * speed * Time.deltaTime;
                targetPos.y += input.y * speed * Time.deltaTime;
                Vector3 moveDirection = new Vector3(input.x, input.y, 0f);
                if (input.x > 0)
                {
                    lastmove.x = 1;
                    lastmove.y = 0;
                }
                else if (input.x < 0)
                {
                    lastmove.x = -1;
                    lastmove.y = 0;
                }
                else if (input.y > 0)
                {
                    lastmove.y = 1;
                    lastmove.x = 0;
                }
                else if (input.y < 0)
                {
                    lastmove.y = -1;
                    lastmove.x = 0;
                }

                
                if (isWalkable(targetPos))
                    transform.position += moveDirection * speed * Time.deltaTime;
                    
            }
        }
        animator.SetBool("isMoving", isMoving);
        isMoving = false;

        if (Input.GetKeyDown(KeyCode.Z))
            Interact();
    }
    void Interact() {
        var lookdirection = new Vector3(lastmove.x, lastmove.y);
        var whereLooking = transform.position + lookdirection;

        var collider = Physics2D.OverlapCircle(whereLooking, 0.2f, interactableObjects);
        if (collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
        
    }


    private bool isWalkable(Vector3 targetPos)
    {

        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjects | interactableObjects) != null)
        {
            return false;
        }
        return true;
        
    }
    
}


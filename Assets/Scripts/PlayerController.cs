using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    //public allows it to be changed in the unity editor without touching the code
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    private SpriteRenderer spriteRenderer;

    private Vector2 movementInput;

    private Rigidbody2D rb;

    private Animator animator;

   

    


    //raycast sends out a prediction to detect if there's any walls or anything for thep layer to interact with before moving
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate ()
    {
        
        //if movmenet is 0, dont move.
        if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);
            if (!success)
            {
                success = TryMove(new Vector2(movementInput.x, 0)); //checks if we can move left/right

                if (!success)
                {
                    success = TryMove(new Vector2(0, movementInput.y)); //checks if we can move up down
                    
                    //all of this lets us slide across collision object
                }
            }

            animator.SetBool("isMoving", success);
        } else {
            animator.SetBool("isMoving", false);
        }

        //set direction of sprite
        if(movementInput.x < 0) //trying to move left
        {
            spriteRenderer.flipX = true;
        } else if (movementInput.x > 0) //trying to move right
        {
            spriteRenderer.flipX = false;

        }

    }

    private bool TryMove(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            //check for collisions
            int count = rb.Cast(

                direction,  //x and y values that respresent the direciton to look for collisions
                movementFilter, //setting that determines where a collsiion can occur
                castCollisions, // list of collisions to store the found ones until after the cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); //the amount to cast equal to the movment plus an offset

            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime); //fixed delta time normalizes movement to frames
                return true;
            }
            else
            {
                return false;
            }
        } else { return false; }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();

        if (movementInput != Vector2.zero)
        {
            //feeds movement inputs to animator
            animator.SetFloat("XInput", movementInput.x);
            animator.SetFloat("YInput", movementInput.y);
        }
    }

    

   

}

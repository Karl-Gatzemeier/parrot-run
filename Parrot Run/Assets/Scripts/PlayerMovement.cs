
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private float forwardForce;
    [SerializeField] private int multiJumpCount;
    private float forwardForceVel;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider2d;
    public Animator animator;
    private int jump_count = 0;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void Jump()
    {
        //Jump using Spacebar
        if ((IsGrounded() || jump_count + 1 < multiJumpCount) && Input.GetKeyDown(KeyCode.Space))
        {
            jump_count = jump_count + 1;
            if(jump_count >= multiJumpCount || IsGrounded()) jump_count = 0;
            // is player in the middle of the screen?
            if (transform.position.x < 0)
            {
                //player is left to the middle -> he can jump foreward to the middle
                forwardForceVel = forwardForce;
            }
            else
            {
                // player is in the middle -> he cant jump further
                forwardForceVel = 0f;
            }

            body.velocity = new Vector2(forwardForceVel, jumpSpeed);
            //Set params for jump animation
            animator.SetBool("isJumping", true);
            animator.SetFloat("y_Velocity", Mathf.Abs(body.velocity.y));

        }
        else
        {
            //Set params for jump animation
            animator.SetBool("isJumping", false);
            animator.SetFloat("y_Velocity", Mathf.Abs(body.velocity.y));
        }
    }

    private bool IsGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D raycastHit2d = Physics2D.Raycast(boxCollider2d.bounds.center,Vector2.down,boxCollider2d.bounds.extents.y + extraHeight,platformLayerMask);
        
        return raycastHit2d.collider != null;
    }
}


    

       


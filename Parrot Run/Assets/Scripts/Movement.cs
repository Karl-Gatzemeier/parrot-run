
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    [SerializeField] private LayerMask platformLayerMask;
    private float forewardForce;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider2d;
    public Animator animator;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

   
    // Update is called once per frame
    void Update()
    {
        //Jump using Spacebar
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
           // is player in the middle of the screen?
            if(transform.position.x < 0)
            {
                //player is left to the middle -> he can jump foreward to the middle
                forewardForce = 1f;
            } else
            {
                // player is in the middle -> he cant jump further
                forewardForce = 0f;
            }

            body.velocity = new Vector2(forewardForce, jumpSpeed);
            //Set params for jump animation
            animator.SetBool("isJumping", true);
            animator.SetFloat("y_Velocity", Mathf.Abs(body.velocity.y));

        }
        else{
            //Set params for jump animation
            animator.SetBool("isJumping", false);
            animator.SetFloat("y_Velocity", Mathf.Abs(body.velocity.y));
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
        return raycastHit2d.collider != null;
    }
}

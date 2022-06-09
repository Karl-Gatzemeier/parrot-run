
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float runningSpeed;

    private Rigidbody2D body;
    public Animator animator;

    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

   
    // Update is called once per frame
    void Update()
    {

        //Constant forced right movement
        body.velocity = new Vector2(runningSpeed, body.velocity.y);

        
        //Animate Jump
        
        //Jump using Spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
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
}

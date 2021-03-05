using UnityEngine;

public class SimpleSideController : MonoBehaviour
{

    public float moveSpeed = 10.0f;

    public float jumpForce = 300.0f;

    public bool isGrounded = false;

    public float bulletForce = 50.0f;

    Rigidbody2D blahblah;

    Animator animator;

    SpriteRenderer spriteRenderer;

    public GameObject spawnPoint;
    public GameObject energyBall;
    public bool fireForward = true;
    private bool jumped = false;
    public bool shoot = false;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        blahblah = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // What Moves Us
        float horizontalInput = joystick.Horizontal;
        //Get the value of the Horizontal input axis.

        transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);

        if (horizontalInput > 0) 
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = false;
            fireForward = true;
        } 
        else if (horizontalInput < 0) 
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = true;
            fireForward = false;
        } 
        else 
        {
            animator.SetBool("isRunning", false);
        }

        if (shoot) 
        {
            animator.SetTrigger("IsAttack");
            shoot = false;
            // now instantiate the ball and propel forward
            FireEnergyBall();
        }
    }

    public void setShoot() {
        shoot = true;
    }

    void FixedUpdate() 
    {
        float verticalInput = joystick.Vertical;
        if (verticalInput >= .5f && isGrounded && !jumped) 
        {
            blahblah.AddForce(transform.up * jumpForce);
            animator.SetBool("isJumping", true);
            jumped = true;
        }

        
    }

    void FireEnergyBall() 
    {
        // the Bullet instantiation happens here
        GameObject brandNewPewPew;
        brandNewPewPew = Instantiate(energyBall, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
 
        // get the Rigidbody2D component from the instantiated Bullet and control it
        Rigidbody2D tempRigidBody;
        tempRigidBody = brandNewPewPew.GetComponent<Rigidbody2D>();
 
        // tell the bullet to be "pushed" by an amount set by bulletForce 
        if (fireForward == true) {
            // fireForward is fire to the right
            tempRigidBody.AddForce(transform.right * bulletForce);
        } else {
            // fire left, a.k.a., "negative-right"
            tempRigidBody.AddForce(-transform.right * bulletForce);
        }
        
 
        // basic Clean Up, set the Bullets to self destruct after 5 Seconds
        Destroy(brandNewPewPew, 5.0f);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Platform") 
        {
            isGrounded = true;
            jumped = false;
            animator.SetBool("isJumping", false);
        }
    }

    void OnExit2D(Collision2D other) {
        if (other.gameObject.tag == "Platform") 
        {
            isGrounded = false;
        }
    }

}
